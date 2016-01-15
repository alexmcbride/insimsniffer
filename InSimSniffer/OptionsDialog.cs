using System;
using System.IO;
using System.Windows.Forms;
using InSimSniffer.Properties;

namespace InSimSniffer {
    public partial class OptionsDialog : Form {
        private Settings settings = Settings.Default;

        public OptionsDialog() {
            InitializeComponent();

            insimPortNumericUpDown.Maximum = UInt16.MaxValue;
            updateIntervalNumericUpDown.Maximum = UInt16.MaxValue;

            hostAddressIpControl.IPAddress = settings.HostAddress;
            insimPortNumericUpDown.Value = settings.InSimPort;
            adminPasswordTextBox.Text = settings.AdminPassword;

            enableMciUpdatesCheckBox.Checked = settings.EnableMciUpdates;
            enableNlpUpdatesCheckBox.Checked = settings.EnableNlpUpdates;
            updateIntervalNumericUpDown.Value = settings.UpdateInterval;

            updatesCheckedListBox.BeginUpdate();
            updatesCheckedListBox.Items.Add("CON", settings.EnableConUpdates);
            updatesCheckedListBox.Items.Add("HLV", settings.EnableHlvUpdates);
            updatesCheckedListBox.Items.Add("OBH", settings.EnableObhUpdates);
            updatesCheckedListBox.Items.Add("AXM_EDIT", settings.EnableAxmEditUpdates);
            updatesCheckedListBox.Items.Add("AXM_LOAD", settings.EnableAxmLoadUpdates);
            updatesCheckedListBox.EndUpdate();

            lfsExeLocationTextBox.Text = settings.LfsExePath;
            autoConnectCheckBox.Checked = settings.AutoConnect;

            autoClearCheckBox.Checked = settings.AutoClearPackets;
            minimizeToTrayCheckBox.Checked = settings.MinimiseToNotificationTray;
        }

        private void OnSaveButtonClick(object sender, EventArgs e) {
            // Reset minimise message.
            if (minimizeToTrayCheckBox.Checked && !settings.MinimiseToNotificationTray) {
                settings.ShowMinimisedMessage = true;
            }

            settings.HostAddress = hostAddressIpControl.IPAddress;
            settings.InSimPort = (ushort)insimPortNumericUpDown.Value;
            settings.AdminPassword = adminPasswordTextBox.Text;

            settings.EnableMciUpdates = enableMciUpdatesCheckBox.Checked;
            settings.EnableNlpUpdates = enableNlpUpdatesCheckBox.Checked;
            settings.UpdateInterval = (ushort)updateIntervalNumericUpDown.Value;

            // Bit crappy, but what the heck.
            settings.EnableConUpdates = updatesCheckedListBox.GetItemChecked(0);
            settings.EnableHlvUpdates = updatesCheckedListBox.GetItemChecked(1);
            settings.EnableObhUpdates = updatesCheckedListBox.GetItemChecked(2);
            settings.EnableAxmEditUpdates = updatesCheckedListBox.GetItemChecked(3);
            settings.EnableAxmLoadUpdates = updatesCheckedListBox.GetItemChecked(4);

            settings.LfsExePath = lfsExeLocationTextBox.Text;
            settings.AutoConnect = autoConnectCheckBox.Checked;

            settings.AutoClearPackets = autoClearCheckBox.Checked;
            settings.MinimiseToNotificationTray = minimizeToTrayCheckBox.Checked;

            settings.Save();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnLfsExeBrowseButtonClick(object sender, EventArgs e) {
            string lfsExePath = lfsExeLocationTextBox.Text;

            using (OpenFileDialog dlg = new OpenFileDialog()) {
                dlg.Title = StringResources.OptionsLfsExeBrowseDialogTitle;
                dlg.Filter = StringResources.OptionsLfsExeBrowseDialogFilter;
                dlg.CheckFileExists = true;
                dlg.CheckPathExists = true;

                if (!String.IsNullOrEmpty(lfsExePath)) {
                    dlg.InitialDirectory = Path.GetDirectoryName(lfsExePath);
                    dlg.FileName = Path.GetFileName(lfsExePath);
                }

                if (dlg.ShowDialog(this) == DialogResult.OK) {
                    lfsExeLocationTextBox.Text = dlg.FileName;
                }
            }
        }

        private void OnEnableMciUpatesCheckBoxCheckedChanged(object sender, EventArgs e) {
            updateIntervalNumericUpDown.Enabled = enableMciUpdatesCheckBox.Checked || enableNlpUpdatesCheckBox.Checked;

            if (enableMciUpdatesCheckBox.Checked) {
                enableNlpUpdatesCheckBox.Checked = false;
            }
        }

        private void OnEnableNlpUpdatesCheckBoxCheckedChanged(object sender, EventArgs e) {
            updateIntervalNumericUpDown.Enabled = enableMciUpdatesCheckBox.Checked || enableNlpUpdatesCheckBox.Checked;

            if (enableNlpUpdatesCheckBox.Checked) {
                enableMciUpdatesCheckBox.Checked = false;
            }
        }
    }
}
