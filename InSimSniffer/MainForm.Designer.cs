namespace InSimSniffer {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.packetsTabPage = new System.Windows.Forms.TabPage();
            this.packetsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.packetsListView = new InSimSniffer.BaseListView();
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.elapsedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.packetsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.packetsDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterTextBox = new InSimSniffer.FilterTextBox();
            this.detailsListView = new InSimSniffer.BaseListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.informationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.detailsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileClearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileImportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inSimMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.insimOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.insimConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insimDisconnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.insimPauseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.insimLaunchLfsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestMenu = new InSimSniffer.RequestMenu();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAlwaysOnTopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.helpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.nofityIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyRestoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.packetsTabPage.SuspendLayout();
            this.packetsTableLayoutPanel.SuspendLayout();
            this.packetsMenu.SuspendLayout();
            this.detailsMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.nofityIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabControl);
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.detailsListView);
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.packetsTabPage);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.TabStop = false;
            // 
            // packetsTabPage
            // 
            this.packetsTabPage.Controls.Add(this.packetsTableLayoutPanel);
            resources.ApplyResources(this.packetsTabPage, "packetsTabPage");
            this.packetsTabPage.Name = "packetsTabPage";
            this.packetsTabPage.UseVisualStyleBackColor = true;
            // 
            // packetsTableLayoutPanel
            // 
            resources.ApplyResources(this.packetsTableLayoutPanel, "packetsTableLayoutPanel");
            this.packetsTableLayoutPanel.Controls.Add(this.packetsListView, 0, 1);
            this.packetsTableLayoutPanel.Controls.Add(this.filterTextBox, 0, 0);
            this.packetsTableLayoutPanel.Name = "packetsTableLayoutPanel";
            // 
            // packetsListView
            // 
            this.packetsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.typeColumnHeader,
            this.elapsedColumnHeader});
            this.packetsListView.ColumnSorter = null;
            this.packetsListView.ContextMenuStrip = this.packetsMenu;
            resources.ApplyResources(this.packetsListView, "packetsListView");
            this.packetsListView.FullRowSelect = true;
            this.packetsListView.HideSelection = false;
            this.packetsListView.MultiSelect = false;
            this.packetsListView.Name = "packetsListView";
            this.packetsListView.OwnerDraw = true;
            this.packetsListView.UseCompatibleStateImageBehavior = false;
            this.packetsListView.View = System.Windows.Forms.View.Details;
            this.packetsListView.ItemSelected += new System.EventHandler(this.OnPacketsListViewItemSelected);
            this.packetsListView.ItemDeselected += new System.EventHandler(this.OnPacketsListViewItemDeselected);
            this.packetsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnPacketsListViewKeyDown);
            // 
            // typeColumnHeader
            // 
            resources.ApplyResources(this.typeColumnHeader, "typeColumnHeader");
            // 
            // elapsedColumnHeader
            // 
            resources.ApplyResources(this.elapsedColumnHeader, "elapsedColumnHeader");
            // 
            // packetsMenu
            // 
            this.packetsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.packetsDeleteMenuItem});
            this.packetsMenu.Name = "packetsContextMenuStrip";
            resources.ApplyResources(this.packetsMenu, "packetsMenu");
            // 
            // packetsDeleteMenuItem
            // 
            this.packetsDeleteMenuItem.Name = "packetsDeleteMenuItem";
            resources.ApplyResources(this.packetsDeleteMenuItem, "packetsDeleteMenuItem");
            this.packetsDeleteMenuItem.Click += new System.EventHandler(this.OnPacketsDeleteMenuItemClick);
            // 
            // filterTextBox
            // 
            resources.ApplyResources(this.filterTextBox, "filterTextBox");
            this.filterTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Filtered += new System.EventHandler(this.OnFilterTextBoxFiltered);
            // 
            // detailsListView
            // 
            this.detailsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader,
            this.informationColumnHeader});
            this.detailsListView.ColumnSorter = null;
            this.detailsListView.ContextMenuStrip = this.detailsMenu;
            resources.ApplyResources(this.detailsListView, "detailsListView");
            this.detailsListView.FullRowSelect = true;
            this.detailsListView.HideSelection = false;
            this.detailsListView.Name = "detailsListView";
            this.detailsListView.OwnerDraw = true;
            this.detailsListView.UseCompatibleStateImageBehavior = false;
            this.detailsListView.View = System.Windows.Forms.View.Details;
            // 
            // nameColumnHeader
            // 
            resources.ApplyResources(this.nameColumnHeader, "nameColumnHeader");
            // 
            // valueColumnHeader
            // 
            resources.ApplyResources(this.valueColumnHeader, "valueColumnHeader");
            // 
            // informationColumnHeader
            // 
            resources.ApplyResources(this.informationColumnHeader, "informationColumnHeader");
            // 
            // detailsMenu
            // 
            this.detailsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsCopyMenuItem});
            this.detailsMenu.Name = "detailsMenu";
            resources.ApplyResources(this.detailsMenu, "detailsMenu");
            // 
            // detailsCopyMenuItem
            // 
            this.detailsCopyMenuItem.Name = "detailsCopyMenuItem";
            resources.ApplyResources(this.detailsCopyMenuItem, "detailsCopyMenuItem");
            this.detailsCopyMenuItem.Click += new System.EventHandler(this.OnDetailsCopyMenuItemClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.inSimMenu,
            this.requestMenu,
            this.viewMenu,
            this.helpMenu});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileClearMenuItem,
            this.toolStripSeparator4,
            this.fileExportMenuItem,
            this.fileImportMenuItem,
            this.toolStripSeparator5,
            this.fileExitMenuItem});
            this.fileMenu.Name = "fileMenu";
            resources.ApplyResources(this.fileMenu, "fileMenu");
            this.fileMenu.DropDownClosed += new System.EventHandler(this.OnFileMenuDropDownClosed);
            this.fileMenu.DropDownOpening += new System.EventHandler(this.OnFileMenuDropDownOpening);
            // 
            // fileClearMenuItem
            // 
            resources.ApplyResources(this.fileClearMenuItem, "fileClearMenuItem");
            this.fileClearMenuItem.Name = "fileClearMenuItem";
            this.fileClearMenuItem.Click += new System.EventHandler(this.OnFileClearMenuItemClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // fileExportMenuItem
            // 
            this.fileExportMenuItem.Image = global::InSimSniffer.Properties.Resources.DoorOut;
            this.fileExportMenuItem.Name = "fileExportMenuItem";
            resources.ApplyResources(this.fileExportMenuItem, "fileExportMenuItem");
            this.fileExportMenuItem.Click += new System.EventHandler(this.OnFileExportMenuItemClick);
            // 
            // fileImportMenuItem
            // 
            this.fileImportMenuItem.Image = global::InSimSniffer.Properties.Resources.DoorIn;
            this.fileImportMenuItem.Name = "fileImportMenuItem";
            resources.ApplyResources(this.fileImportMenuItem, "fileImportMenuItem");
            this.fileImportMenuItem.Click += new System.EventHandler(this.OnFileImportMenuItemClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            resources.ApplyResources(this.fileExitMenuItem, "fileExitMenuItem");
            this.fileExitMenuItem.Click += new System.EventHandler(this.OnFileExitMenuItemClick);
            // 
            // inSimMenu
            // 
            this.inSimMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insimOptionsMenuItem,
            this.toolStripSeparator1,
            this.insimConnectMenuItem,
            this.insimDisconnectMenuItem,
            this.toolStripSeparator2,
            this.insimPauseMenuItem,
            this.toolStripSeparator3,
            this.insimLaunchLfsMenuItem});
            this.inSimMenu.Name = "inSimMenu";
            resources.ApplyResources(this.inSimMenu, "inSimMenu");
            this.inSimMenu.DropDownClosed += new System.EventHandler(this.OnInSimMenuDropDownClosed);
            this.inSimMenu.DropDownOpening += new System.EventHandler(this.OnInSimMenuDropDownOpening);
            // 
            // insimOptionsMenuItem
            // 
            resources.ApplyResources(this.insimOptionsMenuItem, "insimOptionsMenuItem");
            this.insimOptionsMenuItem.Name = "insimOptionsMenuItem";
            this.insimOptionsMenuItem.Click += new System.EventHandler(this.OnInSimOptionsMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // insimConnectMenuItem
            // 
            resources.ApplyResources(this.insimConnectMenuItem, "insimConnectMenuItem");
            this.insimConnectMenuItem.Name = "insimConnectMenuItem";
            this.insimConnectMenuItem.Click += new System.EventHandler(this.OnInSimConnectMenuItemClick);
            // 
            // insimDisconnectMenuItem
            // 
            this.insimDisconnectMenuItem.Image = global::InSimSniffer.Properties.Resources.Disconnect;
            this.insimDisconnectMenuItem.Name = "insimDisconnectMenuItem";
            resources.ApplyResources(this.insimDisconnectMenuItem, "insimDisconnectMenuItem");
            this.insimDisconnectMenuItem.Click += new System.EventHandler(this.OnInSimDisconnectMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // insimPauseMenuItem
            // 
            this.insimPauseMenuItem.Image = global::InSimSniffer.Properties.Resources.Pause;
            this.insimPauseMenuItem.Name = "insimPauseMenuItem";
            resources.ApplyResources(this.insimPauseMenuItem, "insimPauseMenuItem");
            this.insimPauseMenuItem.Click += new System.EventHandler(this.OnInSimPauseMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // insimLaunchLfsMenuItem
            // 
            this.insimLaunchLfsMenuItem.Image = global::InSimSniffer.Properties.Resources.Lfs;
            this.insimLaunchLfsMenuItem.Name = "insimLaunchLfsMenuItem";
            resources.ApplyResources(this.insimLaunchLfsMenuItem, "insimLaunchLfsMenuItem");
            this.insimLaunchLfsMenuItem.Click += new System.EventHandler(this.OnInSimLaunchLfsMenuItemClick);
            // 
            // requestMenu
            // 
            this.requestMenu.Name = "requestMenu";
            resources.ApplyResources(this.requestMenu, "requestMenu");
            this.requestMenu.TinyRequest += new System.EventHandler<InSimSniffer.TinyRequestEventArgs>(this.OnRequestTinyMenuItemClick);
            this.requestMenu.SmallRequest += new System.EventHandler<InSimSniffer.SmallRequestEventArgs>(this.OnRequestSmallMenuItemRequest);
            this.requestMenu.DropDownOpening += new System.EventHandler(this.OnRequestMenuDropDownOpening);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAlwaysOnTopMenuItem,
            this.viewTransparentMenuItem});
            this.viewMenu.Name = "viewMenu";
            resources.ApplyResources(this.viewMenu, "viewMenu");
            // 
            // viewAlwaysOnTopMenuItem
            // 
            this.viewAlwaysOnTopMenuItem.Name = "viewAlwaysOnTopMenuItem";
            resources.ApplyResources(this.viewAlwaysOnTopMenuItem, "viewAlwaysOnTopMenuItem");
            this.viewAlwaysOnTopMenuItem.Click += new System.EventHandler(this.OnViewAlwaysOnTopMenuItemClick);
            // 
            // viewTransparentMenuItem
            // 
            this.viewTransparentMenuItem.Name = "viewTransparentMenuItem";
            resources.ApplyResources(this.viewTransparentMenuItem, "viewTransparentMenuItem");
            this.viewTransparentMenuItem.Click += new System.EventHandler(this.OnViewTransparentMenuItemClick);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpUpdateMenuItem,
            this.toolStripSeparator7,
            this.helpAboutMenuItem});
            this.helpMenu.Name = "helpMenu";
            resources.ApplyResources(this.helpMenu, "helpMenu");
            // 
            // helpUpdateMenuItem
            // 
            this.helpUpdateMenuItem.Image = global::InSimSniffer.Properties.Resources.Transmit;
            this.helpUpdateMenuItem.Name = "helpUpdateMenuItem";
            resources.ApplyResources(this.helpUpdateMenuItem, "helpUpdateMenuItem");
            this.helpUpdateMenuItem.Click += new System.EventHandler(this.OnHelpUpdateMenuItemClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // helpAboutMenuItem
            // 
            resources.ApplyResources(this.helpAboutMenuItem, "helpAboutMenuItem");
            this.helpAboutMenuItem.Name = "helpAboutMenuItem";
            this.helpAboutMenuItem.Click += new System.EventHandler(this.OnHelpAboutMenuItemClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.nofityIconMenu;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.OnNotifyIconBalloonTipClicked);
            this.notifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnNotifyIconMouseDown);
            // 
            // nofityIconMenu
            // 
            this.nofityIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyRestoreMenuItem,
            this.toolStripSeparator6,
            this.notifyExitMenuItem});
            this.nofityIconMenu.Name = "nofityIconContextMenuStrip";
            resources.ApplyResources(this.nofityIconMenu, "nofityIconMenu");
            // 
            // notifyRestoreMenuItem
            // 
            this.notifyRestoreMenuItem.Name = "notifyRestoreMenuItem";
            resources.ApplyResources(this.notifyRestoreMenuItem, "notifyRestoreMenuItem");
            this.notifyRestoreMenuItem.Click += new System.EventHandler(this.OnNotifyRestoreMenuItemClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // notifyExitMenuItem
            // 
            this.notifyExitMenuItem.Name = "notifyExitMenuItem";
            resources.ApplyResources(this.notifyExitMenuItem, "notifyExitMenuItem");
            this.notifyExitMenuItem.Click += new System.EventHandler(this.OnFileExitMenuItemClick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.packetsTabPage.ResumeLayout(false);
            this.packetsTableLayoutPanel.ResumeLayout(false);
            this.packetsTableLayoutPanel.PerformLayout();
            this.packetsMenu.ResumeLayout(false);
            this.detailsMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.nofityIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip packetsMenu;
        private System.Windows.Forms.ToolStripMenuItem packetsDeleteMenuItem;
        private System.Windows.Forms.ContextMenuStrip nofityIconMenu;
        private System.Windows.Forms.ToolStripMenuItem notifyRestoreMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem notifyExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileClearMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem fileExportMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inSimMenu;
        private System.Windows.Forms.ToolStripMenuItem insimOptionsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem insimConnectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insimDisconnectMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem insimPauseMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem insimLaunchLfsMenuItem;
        private RequestMenu requestMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem viewAlwaysOnTopMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTransparentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem helpAboutMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ContextMenuStrip detailsMenu;
        private System.Windows.Forms.ToolStripMenuItem detailsCopyMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage packetsTabPage;
        private System.Windows.Forms.TableLayoutPanel packetsTableLayoutPanel;
        private BaseListView packetsListView;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.ColumnHeader elapsedColumnHeader;
        private BaseListView detailsListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.ColumnHeader informationColumnHeader;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem helpUpdateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileImportMenuItem;
        private FilterTextBox filterTextBox;
    }
}

