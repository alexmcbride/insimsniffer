using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InSimSniffer.Library;
using InSimSniffer.Properties;

namespace InSimSniffer {
    public partial class MainForm : Form {
        private Settings settings = Settings.Default;
        private SnifferClient client;
        private Graphics graphics;
        private List<SniffedPacket> packets = new List<SniffedPacket>();

        public MainForm(IEnumerable<string> commandLineArgs) {
            InitializeComponent();
            LoadWindowState();
            LoadSettings();
            InitialiseSniffer();
            UpdateFormTitle();
            graphics = CreateGraphics(); // Graphics used for measuring text.
            HandleCommandLineArgs(commandLineArgs);

            // Helpers for sorting ListView columns.
            detailsListView.ColumnSorter = new DetailsColumnSorter();
            packetsListView.ColumnSorter = new PacketsColumnSorter();

            // Hook these up here so they don't get spammed on startup.
            Resize += OnMainFormResize;

            ActiveControl = packetsListView;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }

                if (client != null) {
                    client.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        private void DoInvoke(Action action) {
            if (InvokeRequired) {
                Invoke(action);
            }
            else {
                action();
            }
        }

        private void DoBeginInvoke(Action action) {
            if (InvokeRequired) {
                BeginInvoke(action);
            }
            else {
                action();
            }
        }

        private void LoadSettings() {
            if (settings.AlwaysOnTop) {
                ToggleAlwaysOnTop();
            }

            if (settings.Transparent) {
                ToogleTransparency();
            }
        }

        private void SaveSettings() {

        }

        protected override void OnClosed(EventArgs e) {
            SaveSettings();

            base.OnClosed(e);
        }

        private void OnMainFormResize(object sender, EventArgs e) {
            SaveWindowState();

            if (WindowState == FormWindowState.Minimized && settings.MinimiseToNotificationTray) {
                MinimizeToTray();
            }
        }

        public void LoadWindowState() {
            if (settings.WindowMaximised) {
                WindowState = FormWindowState.Maximized;
            }
            ClientSize = settings.WindowSize;
        }

        public void SaveWindowState() {
            settings.WindowMaximised = WindowState == FormWindowState.Maximized;
            if (WindowState == FormWindowState.Normal) {
                settings.WindowSize = ClientSize;
            }
        }

        public void RestoreWindowState() {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            Activate();
        }

        public void MinimizeToTray() {
            Hide();
            notifyIcon.Visible = true;

            if (settings.ShowMinimisedMessage) {
                settings.ShowMinimisedMessage = false;
                ShowNotifyMessage(StringResources.MinimizedToTrayNotifyMessage, Program.Name);
            }
        }

        private void OnNotifyIconMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                RestoreWindowState();
            }
        }

        private void OnNotifyIconBalloonTipClicked(object sender, EventArgs e) {
            RestoreWindowState();
        }

        private void OnNotifyRestoreMenuItemClick(object sender, EventArgs e) {
            RestoreWindowState();
        }

        private void ShowNotifyMessage(string message, params object[] args) {
            ShowNotifyMessage(ToolTipIcon.Info, message, args);
        }

        private void ShowNotifyMessage(ToolTipIcon icon, string message, params object[] args) {
            if (notifyIcon.Visible) {
                message = String.Format(message, args);
                notifyIcon.ShowBalloonTip(10, Program.Name, message, icon);
            }
        }

        private void SetStatus(string message, params object[] args) {
            statusLabel.Text = message = String.Format(message, args);
        }

        private void UpdateFormTitle() {
            string title = GetFormTitle();
            Text = title;
            notifyIcon.Text = title;
        }

        private string GetFormTitle() {
            if (client.IsConnected && client.IsPaused) {
                return String.Format(StringResources.MainFormTitlePaused, Program.Name);
            }
            else if (client.IsConnected && client.IsHostConnected) {
                return String.Format(StringResources.MainFormTitleHostName, Program.Name, client.HostName);
            }
            else if (client.IsConnected) {
                return String.Format(StringResources.MainFormTitleConnected, Program.Name);
            }
            return Program.Name;
        }

        private void HandleCommandLineArgs(IEnumerable<string> commandLineArgs) {
            foreach (string arg in commandLineArgs) {
                string[] tokens = arg.Split('=');
                if (tokens.Length == 2) {
                    // Connect on startup.
                    if (tokens[0].Equals("/connect", StringComparison.InvariantCultureIgnoreCase) &&
                        tokens[1].Equals("true", StringComparison.InvariantCultureIgnoreCase)) {
                        Connect();
                    }

                    // Minimize on startup.
                    if (tokens[0].Equals("/minimize", StringComparison.InvariantCultureIgnoreCase) &&
                        tokens[1].Equals("true", StringComparison.InvariantCultureIgnoreCase)) {
                        WindowState = FormWindowState.Minimized;
                    }
                }
            }
        }

        private void OnFileMenuDropDownOpening(object sender, EventArgs e) {
            fileClearMenuItem.Enabled = packets.Any();
            fileExportMenuItem.Enabled = !client.IsConnected && packets.Any();
            fileImportMenuItem.Enabled = !client.IsConnected;
        }

        private void OnFileMenuDropDownClosed(object sender, EventArgs e) {
            fileClearMenuItem.Enabled = true;
            fileExportMenuItem.Enabled = true;
            fileImportMenuItem.Enabled = true;
        }

        private void OnFileClearMenuItemClick(object sender, EventArgs e) {
            Clear();
        }

        private void Clear() {
            if (packets.Any()) {
                client.Clear();
                packets.Clear();
                packetsListView.Items.Clear();
                detailsListView.Items.Clear();
            }
        }

        private void OnFileExportMenuItemClick(object sender, EventArgs e) {
            if (client.IsConnected || !packets.Any()) {
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog()) {
                dlg.Title = StringResources.ExportDialogTitle;
                dlg.Filter = StringResources.ExportDialogFilter;
                dlg.AddExtension = true;
                dlg.FilterIndex = settings.ExportFilterIndex;
                dlg.InitialDirectory = settings.ExportPath;
                dlg.FileName = Exporter.CreateExportFileName();

                if (dlg.ShowDialog(this) == DialogResult.OK) {
                    Export(dlg.FileName);

                    settings.ExportFilterIndex = dlg.FilterIndex;
                    settings.ExportPath = Path.GetDirectoryName(dlg.FileName);
                }
            }
        }

        private void Export(string path) {
            try {
                Cursor = Cursors.WaitCursor;

                Exporter.Export(path, packets);

                Dialog.ShowInfo(
                     StringResources.ExportSuccessDialogTitle,
                     StringResources.ExportSuccessDialogMessage,
                     path);
            }
            catch (Exception ex) {
                Dialog.ShowError(
                    StringResources.ExportErrorDialogTitle,
                    StringResources.ExportErrorDialogMessage,
                    ex.Message);
            }
            finally {
                Cursor = null;
            }
        }

        private void OnFileImportMenuItemClick(object sender, EventArgs e) {
            if (client.IsConnected) {
                return;
            }

            using (OpenFileDialog dlg = new OpenFileDialog()) {
                dlg.Title = StringResources.ImportDialogTitle;
                dlg.Filter = StringResources.ImportDialogFilter;
                dlg.AddExtension = true;
                dlg.Multiselect = false;
                dlg.CheckFileExists = true;
                dlg.InitialDirectory = settings.ExportPath;

                if (dlg.ShowDialog(this) == DialogResult.OK) {
                    Import(dlg.FileName);

                    settings.ExportPath = Path.GetDirectoryName(dlg.FileName);
                }
            }
        }

        private void Import(string path) {
            try {
                Cursor = Cursors.WaitCursor;

                // Import packets.
                List<SniffedPacket> packets = Exporter.Import(path).ToList();

                // Update packets list.
                this.packets.AddRange(packets);

                // Update UI.
                packetsListView.Items.AddRange(BuildPacketListViewItems(packets).ToArray());
                SetStatus(StringResources.ImportSuccessStatusMessage, packets.Count);
            }
            catch (Exception ex) {
                Dialog.ShowError(
                    StringResources.ImportErrorDialogTitle,
                    StringResources.ImportErrorDialogMessage,
                    ex.Message);
            }
            finally {
                Cursor = null;
            }
        }

        private void OnFileExitMenuItemClick(object sender, EventArgs e) {
            Close();
        }

        private void OnInSimMenuDropDownOpening(object sender, EventArgs e) {
            insimOptionsMenuItem.Enabled = !client.IsConnected;
            insimConnectMenuItem.Enabled = !client.IsConnected;
            insimDisconnectMenuItem.Enabled = client.IsConnected;
            insimPauseMenuItem.Enabled = client.IsConnected;
            insimLaunchLfsMenuItem.Enabled = !client.IsConnected;
        }

        private void OnInSimMenuDropDownClosed(object sender, EventArgs e) {
            insimOptionsMenuItem.Enabled = true;
            insimConnectMenuItem.Enabled = true;
            insimDisconnectMenuItem.Enabled = true;
            insimPauseMenuItem.Enabled = true;
            insimLaunchLfsMenuItem.Enabled = true;
        }

        private void OnInSimOptionsMenuItemClick(object sender, EventArgs e) {
            if (!client.IsConnected) {
                using (OptionsDialog dlg = new OptionsDialog()) {
                    dlg.ShowDialog(this);
                }
            }
        }

        private void OnInSimConnectMenuItemClick(object sender, EventArgs e) {
            if (!client.IsConnected) {
                Connect();
            }
        }

        private void Connect() {
            try {
                Cursor = Cursors.WaitCursor;
                SetStatus(StringResources.InSimInitializingStatusMessage);

                client.Initialize(new SnifferSettings {
                    Host = settings.HostAddress,
                    Port = settings.InSimPort,
                    Admin = settings.AdminPassword,
                    EnableMci = settings.EnableMciUpdates,
                    EnableNlp = settings.EnableNlpUpdates,
                    EnableCon = settings.EnableConUpdates,
                    EnableObh = settings.EnableObhUpdates,
                    EnableHlv = settings.EnableHlvUpdates,
                    EnableAxmEdit = settings.EnableAxmEditUpdates,
                    EnableAxmLoad = settings.EnableAxmLoadUpdates,
                    Interval = settings.UpdateInterval,
                    Name = String.Format("^7{0}", Program.Name),
                });

                SetStatus(StringResources.InSimInitializedStatusMessage);
                if (settings.AutoClearPackets) {
                    Clear();
                }

                UpdateFormTitle();
            }
            catch (Exception ex) {
                SetStatus(StringResources.InSimInitializeFailedStatusMessage);
                Dialog.ShowError(StringResources.InSimInitializeFailedDialogTitle, StringResources.InSimErrorDialogMessage, ex.Message);
            }
            finally {
                Cursor = null;
            }
        }

        private void OnInSimDisconnectMenuItemClick(object sender, EventArgs e) {
            if (client.IsConnected) {
                client.Disconnect();
            }
        }

        private void OnInSimPauseMenuItemClick(object sender, EventArgs e) {
            if (client.IsConnected) {
                client.IsPaused = !client.IsPaused;
            }
        }

        private void InitialiseSniffer() {
            client = new SnifferClient();
            client.ConnectionClosed += OnSnifferClientConnectionClosed;
            client.HostChanged += OnSnifferClientHostChanged;
            client.PauseChanged += OnSnifferClientPauseChanged;
            client.InSimError += OnSnifferClientInSimError;
            client.PacketSniffed += OnSnifferClientPacketSniffed;
        }

        private void OnSnifferClientConnectionClosed(object sender, InSimCloseEventArgs e) {
            DoBeginInvoke(() => {
                UpdateFormTitle();
                insimPauseMenuItem.Checked = false;

                if (e.Reason == InSimCloseReason.Close) {
                    SetStatus(StringResources.InSimDisconnectedStatusMessage);
                }
                else if (e.Reason == InSimCloseReason.Lost) {
                    SetStatus(StringResources.InSimLostStatusMessage);
                    ShowNotifyMessage(ToolTipIcon.Error, StringResources.InSimLostNotifyMessage);
                }
            });
        }

        private void OnSnifferClientPauseChanged(object sender, EventArgs e) {
            insimPauseMenuItem.Checked = !insimPauseMenuItem.Checked;
            SetStatus(client.IsPaused ? StringResources.InSimPausedStatusMessage : StringResources.InSimUnpausedStatusMessage);
            UpdateFormTitle();
        }

        private void OnSnifferClientInSimError(object sender, ErrorEventArgs e) {
            DoBeginInvoke(() => {
                UpdateFormTitle();
                SetStatus(StringResources.InSimLostStatusMessage);
                Dialog.ShowError(
                    StringResources.InSimErrorDialogTitle,
                    StringResources.InSimErrorDialogMessage,
                    e.GetException().Message);
            });
        }

        private void OnSnifferClientHostChanged(object sender, EventArgs e) {
            UpdateFormTitle();
        }

        private void OnSnifferClientPacketSniffed(object sender, PacketEventArgs e) {
            packets.Add(e.Packet);

            DoBeginInvoke(() => {
                if (PacketContainsFilterTerm(e.Packet)) {
                    ListViewItem item = BuildPacketListViewItem(e.Packet);
                    packetsListView.Items.Add(item);
                }
            });
        }

        private static ListViewItem BuildPacketListViewItem(SniffedPacket packet) {
            ListViewItem item = new ListViewItem(packet.PacketType);
            item.Tag = packet;
            item.SubItems.Add(packet.ElapsedTime.ToShortTimeString());
            return item;
        }

        private IEnumerable<ListViewItem> BuildPacketListViewItems(IEnumerable<SniffedPacket> packets) {
            return packets.Where(p => PacketContainsFilterTerm(p)).Select(p => BuildPacketListViewItem(p));
        }

        private void OnPacketsListViewItemSelected(object sender, EventArgs e) {
            const float DefaultValueWidth = 140;
            const float ValueWidthDeadzone = 20;

            SniffedPacket packet = (SniffedPacket)packetsListView.SelectedItem.Tag;
            float maxValueWidth = DefaultValueWidth;

            ListViewItem[] items = new ListViewItem[packet.Values.Count];
            for (int i = 0; i < items.Length; i++) {
                string value = packet.Values[i].Value.ToString();

                items[i] = new ListViewItem(packet.Values[i].Name);
                items[i].SubItems.Add(value);
                items[i].SubItems.Add(packet.Values[i].Information);
                items[i].Tag = packet.Values[i];

                float valueWidth = graphics.MeasureString(value, detailsListView.Font).Width;
                maxValueWidth = valueWidth > maxValueWidth ? valueWidth : maxValueWidth;
            }

            detailsListView.Items.AddRange(items);
            valueColumnHeader.Width = (int)(maxValueWidth + ValueWidthDeadzone);
        }

        private void OnPacketsListViewItemDeselected(object sender, EventArgs e) {
            detailsListView.Items.Clear();
        }

        private void OnFilterTextBoxFiltered(object sender, EventArgs e) {
            packetsListView.Items.Clear();
            ListViewItem[] items = BuildPacketListViewItems(packets).ToArray();
            packetsListView.Items.AddRange(items.ToArray());
        }

        private bool PacketContainsFilterTerm(SniffedPacket packet) {
            if (filterTextBox.HasFilterTerms) {
                return (from s in filterTextBox.FilterTerms
                        where packet.PacketType.IndexOf(s, StringComparison.OrdinalIgnoreCase) > -1
                        select s).Any();
            }
            return true;
        }

        private void OnInSimLaunchLfsMenuItemClick(object sender, EventArgs e) {
            if (client.IsConnected) {
                return;
            }

            if (!File.Exists(settings.LfsExePath)) {
                Dialog.ShowError(StringResources.LaunchLfsFailedDialogTitle, StringResources.LaunchLfsFailedDialogMessage);
                return;
            }

            LfsLaunchHelper lfs = null;
            try {
                lfs = new LfsLaunchHelper(settings.LfsExePath);
                lfs.Launch(settings.InSimPort);

                if (settings.AutoConnect) {
                    lfs.WaitForIdle();

                    Connect();
                }
            }
            catch (InvalidOperationException) {
                // Thrown when LFS is set to run as adminstrator. Prompt user to connect manually.
                if (Dialog.ShowYesNo(
                    StringResources.LaunchLfsAutoConnectFailedDialogTitle,
                    StringResources.LaunchLfsAutoConnectFailedDialogMessage)) {
                    Connect();
                }
            }
            catch (Exception ex) {
                Dialog.ShowError(
                    StringResources.LaunchLfsFailedDialogTitle,
                    StringResources.LaunchLfsFailedDialogErrorMessage,
                    ex.Message);
            }
            finally {
                if (lfs != null) {
                    lfs.Dispose();
                }
            }
        }

        private void OnPacketsDeleteMenuItemClick(object sender, EventArgs e) {
            DeletePackets();
        }

        private void OnPacketsListViewKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                DeletePackets();
            }
        }

        private void DeletePackets() {
            foreach (ListViewItem item in packetsListView.SelectedItems) {
                SniffedPacket packet = (SniffedPacket)item.Tag;
                packets.Remove(packet);
                packetsListView.Items.Remove(item);
            }
        }

        private void OnRequestMenuDropDownOpening(object sender, EventArgs e) {
            requestMenu.Enabled = client.IsConnected;
        }

        private void OnRequestTinyMenuItemClick(object sender, TinyRequestEventArgs e) {
            try {
                client.Request(e.Tiny);
            }
            catch (Exception ex) {
                Dialog.ShowError(
                    String.Format(StringResources.RequestFailedDialogTitle, e.Tiny),
                    StringResources.RequestFailedDialogMessage,
                    ex.Message);
            }
        }

        private void OnRequestSmallMenuItemRequest(object sender, SmallRequestEventArgs e) {
            try {
                using (NumericDialog dlg = new NumericDialog()) {
                    dlg.Title = String.Format(StringResources.RequestSmallDialogTitle, e.Small);
                    dlg.Caption = StringResources.RequestSmallDialogCaption;
                    dlg.Value = 0;
                    dlg.Minimum = 0;
                    dlg.Maximum = UInt32.MaxValue;

                    if (dlg.ShowDialog(this) == DialogResult.OK) {
                        client.Request(e.Small, dlg.Value);
                    }
                }
            }
            catch (Exception ex) {
                Dialog.ShowError(
                    String.Format(StringResources.RequestFailedDialogTitle, e.Small),
                    StringResources.RequestFailedDialogMessage,
                    ex.Message);
            }
        }

        private void OnViewAlwaysOnTopMenuItemClick(object sender, EventArgs e) {
            ToggleAlwaysOnTop();
        }

        public void ToggleAlwaysOnTop() {
            TopMost = !TopMost;
            settings.AlwaysOnTop = TopMost;
            viewAlwaysOnTopMenuItem.Checked = !viewAlwaysOnTopMenuItem.Checked;
        }

        private void OnViewTransparentMenuItemClick(object sender, EventArgs e) {
            ToogleTransparency();
        }

        private void ToogleTransparency() {
            const double TransparencyAmount = 0.78;

            if (Opacity == 1) {
                Opacity = TransparencyAmount;
                settings.Transparent = true;
            }
            else {
                Opacity = 1;
                settings.Transparent = false;
            }

            viewTransparentMenuItem.Checked = !viewTransparentMenuItem.Checked;
        }

        private void OnHelpUpdateMenuItemClick(object sender, EventArgs e) {
            try {
                Cursor = Cursors.WaitCursor;

                UpdateInfo update = UpdateInfo.Download();

                if (update.Version > Program.Version) {
                    if (Dialog.ShowYesNo(StringResources.UpdateAvailableDialogTitle, StringResources.UpdateAvailableDialogMessage, update.Version)) {
                        Process.Start(update.Url.ToString());
                    }
                }
                else {
                    Dialog.ShowInfo(StringResources.UpdateNotAvailableDialogTitle, StringResources.UpdateNotAvailableDialogMessage);
                }
            }
            catch (Exception ex) {
                Dialog.ShowError(StringResources.UpdateErrorDialogTitle, StringResources.UpdateErrorDialogMessage, ex.Message);
            }
            finally {
                Cursor = null;
            }
        }

        private void OnHelpAboutMenuItemClick(object sender, EventArgs e) {
            using (AboutDialog dlg = new AboutDialog()) {
                dlg.ShowDialog(this);
            }
        }

        private void OnDetailsCopyMenuItemClick(object sender, EventArgs e) {
            detailsListView.CopyToClipboard();
        }
    }
}
