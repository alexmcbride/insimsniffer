namespace InSimSniffer {
    partial class OptionsDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.optionsTable = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.optionsTabControl = new System.Windows.Forms.TabControl();
            this.insimTabPage = new System.Windows.Forms.TabPage();
            this.insimTable = new System.Windows.Forms.TableLayoutPanel();
            this.connectionGroupBox = new System.Windows.Forms.GroupBox();
            this.connectionTable = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.adminPasswordTextBox = new System.Windows.Forms.TextBox();
            this.insimPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.updateIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.enableMciUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.enableNlpUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updatesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.generalTable = new System.Windows.Forms.TableLayoutPanel();
            this.launchLfsGroupBox = new System.Windows.Forms.GroupBox();
            this.launchLfsTable = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lfsExeBrowseButton = new System.Windows.Forms.Button();
            this.lfsExeLocationTextBox = new System.Windows.Forms.TextBox();
            this.autoConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.miscellaneousGroupBox = new System.Windows.Forms.GroupBox();
            this.miscellaneousTable = new System.Windows.Forms.TableLayoutPanel();
            this.minimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.autoClearCheckBox = new System.Windows.Forms.CheckBox();
            this.hostAddressIpControl = new InSimSniffer.IPControl();
            this.optionsTable.SuspendLayout();
            this.buttonsFlowPanel.SuspendLayout();
            this.optionsTabControl.SuspendLayout();
            this.insimTabPage.SuspendLayout();
            this.insimTable.SuspendLayout();
            this.connectionGroupBox.SuspendLayout();
            this.connectionTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insimPortNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.generalTable.SuspendLayout();
            this.launchLfsGroupBox.SuspendLayout();
            this.launchLfsTable.SuspendLayout();
            this.miscellaneousGroupBox.SuspendLayout();
            this.miscellaneousTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsTable
            // 
            resources.ApplyResources(this.optionsTable, "optionsTable");
            this.optionsTable.Controls.Add(this.buttonsFlowPanel, 0, 1);
            this.optionsTable.Controls.Add(this.optionsTabControl, 0, 0);
            this.optionsTable.Name = "optionsTable";
            // 
            // buttonsFlowPanel
            // 
            resources.ApplyResources(this.buttonsFlowPanel, "buttonsFlowPanel");
            this.buttonsFlowPanel.Controls.Add(this.cancelButton);
            this.buttonsFlowPanel.Controls.Add(this.saveButton);
            this.buttonsFlowPanel.Name = "buttonsFlowPanel";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // optionsTabControl
            // 
            this.optionsTabControl.Controls.Add(this.insimTabPage);
            this.optionsTabControl.Controls.Add(this.generalTabPage);
            resources.ApplyResources(this.optionsTabControl, "optionsTabControl");
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.SelectedIndex = 0;
            // 
            // insimTabPage
            // 
            this.insimTabPage.Controls.Add(this.insimTable);
            resources.ApplyResources(this.insimTabPage, "insimTabPage");
            this.insimTabPage.Name = "insimTabPage";
            this.insimTabPage.UseVisualStyleBackColor = true;
            // 
            // insimTable
            // 
            resources.ApplyResources(this.insimTable, "insimTable");
            this.insimTable.Controls.Add(this.connectionGroupBox, 0, 0);
            this.insimTable.Controls.Add(this.groupBox1, 0, 1);
            this.insimTable.Controls.Add(this.groupBox2, 0, 2);
            this.insimTable.Name = "insimTable";
            // 
            // connectionGroupBox
            // 
            resources.ApplyResources(this.connectionGroupBox, "connectionGroupBox");
            this.connectionGroupBox.Controls.Add(this.connectionTable);
            this.connectionGroupBox.Name = "connectionGroupBox";
            this.connectionGroupBox.TabStop = false;
            // 
            // connectionTable
            // 
            resources.ApplyResources(this.connectionTable, "connectionTable");
            this.connectionTable.Controls.Add(this.label1, 0, 0);
            this.connectionTable.Controls.Add(this.label2, 0, 1);
            this.connectionTable.Controls.Add(this.label3, 0, 2);
            this.connectionTable.Controls.Add(this.adminPasswordTextBox, 1, 2);
            this.connectionTable.Controls.Add(this.insimPortNumericUpDown, 1, 1);
            this.connectionTable.Controls.Add(this.hostAddressIpControl, 1, 0);
            this.connectionTable.Name = "connectionTable";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // adminPasswordTextBox
            // 
            resources.ApplyResources(this.adminPasswordTextBox, "adminPasswordTextBox");
            this.adminPasswordTextBox.Name = "adminPasswordTextBox";
            // 
            // insimPortNumericUpDown
            // 
            resources.ApplyResources(this.insimPortNumericUpDown, "insimPortNumericUpDown");
            this.insimPortNumericUpDown.Name = "insimPortNumericUpDown";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.enableMciUpdatesCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.enableNlpUpdatesCheckBox, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.updateIntervalNumericUpDown);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // updateIntervalNumericUpDown
            // 
            resources.ApplyResources(this.updateIntervalNumericUpDown, "updateIntervalNumericUpDown");
            this.updateIntervalNumericUpDown.Name = "updateIntervalNumericUpDown";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // enableMciUpdatesCheckBox
            // 
            resources.ApplyResources(this.enableMciUpdatesCheckBox, "enableMciUpdatesCheckBox");
            this.enableMciUpdatesCheckBox.Name = "enableMciUpdatesCheckBox";
            this.enableMciUpdatesCheckBox.UseVisualStyleBackColor = true;
            this.enableMciUpdatesCheckBox.CheckedChanged += new System.EventHandler(this.OnEnableMciUpatesCheckBoxCheckedChanged);
            // 
            // enableNlpUpdatesCheckBox
            // 
            resources.ApplyResources(this.enableNlpUpdatesCheckBox, "enableNlpUpdatesCheckBox");
            this.enableNlpUpdatesCheckBox.Name = "enableNlpUpdatesCheckBox";
            this.enableNlpUpdatesCheckBox.UseVisualStyleBackColor = true;
            this.enableNlpUpdatesCheckBox.CheckedChanged += new System.EventHandler(this.OnEnableNlpUpdatesCheckBoxCheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updatesCheckedListBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // updatesCheckedListBox
            // 
            this.updatesCheckedListBox.CheckOnClick = true;
            resources.ApplyResources(this.updatesCheckedListBox, "updatesCheckedListBox");
            this.updatesCheckedListBox.FormattingEnabled = true;
            this.updatesCheckedListBox.Name = "updatesCheckedListBox";
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.generalTable);
            resources.ApplyResources(this.generalTabPage, "generalTabPage");
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // generalTable
            // 
            resources.ApplyResources(this.generalTable, "generalTable");
            this.generalTable.Controls.Add(this.launchLfsGroupBox, 0, 0);
            this.generalTable.Controls.Add(this.miscellaneousGroupBox, 0, 1);
            this.generalTable.Name = "generalTable";
            // 
            // launchLfsGroupBox
            // 
            this.launchLfsGroupBox.Controls.Add(this.launchLfsTable);
            resources.ApplyResources(this.launchLfsGroupBox, "launchLfsGroupBox");
            this.launchLfsGroupBox.Name = "launchLfsGroupBox";
            this.launchLfsGroupBox.TabStop = false;
            // 
            // launchLfsTable
            // 
            resources.ApplyResources(this.launchLfsTable, "launchLfsTable");
            this.launchLfsTable.Controls.Add(this.label6, 0, 0);
            this.launchLfsTable.Controls.Add(this.lfsExeBrowseButton, 2, 0);
            this.launchLfsTable.Controls.Add(this.lfsExeLocationTextBox, 1, 0);
            this.launchLfsTable.Controls.Add(this.autoConnectCheckBox, 0, 1);
            this.launchLfsTable.Name = "launchLfsTable";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // lfsExeBrowseButton
            // 
            resources.ApplyResources(this.lfsExeBrowseButton, "lfsExeBrowseButton");
            this.lfsExeBrowseButton.Image = global::InSimSniffer.Properties.Resources.Browse;
            this.lfsExeBrowseButton.Name = "lfsExeBrowseButton";
            this.lfsExeBrowseButton.UseVisualStyleBackColor = true;
            this.lfsExeBrowseButton.Click += new System.EventHandler(this.OnLfsExeBrowseButtonClick);
            // 
            // lfsExeLocationTextBox
            // 
            resources.ApplyResources(this.lfsExeLocationTextBox, "lfsExeLocationTextBox");
            this.lfsExeLocationTextBox.Name = "lfsExeLocationTextBox";
            this.lfsExeLocationTextBox.ReadOnly = true;
            // 
            // autoConnectCheckBox
            // 
            resources.ApplyResources(this.autoConnectCheckBox, "autoConnectCheckBox");
            this.launchLfsTable.SetColumnSpan(this.autoConnectCheckBox, 3);
            this.autoConnectCheckBox.Name = "autoConnectCheckBox";
            this.autoConnectCheckBox.UseVisualStyleBackColor = true;
            // 
            // miscellaneousGroupBox
            // 
            this.miscellaneousGroupBox.Controls.Add(this.miscellaneousTable);
            resources.ApplyResources(this.miscellaneousGroupBox, "miscellaneousGroupBox");
            this.miscellaneousGroupBox.Name = "miscellaneousGroupBox";
            this.miscellaneousGroupBox.TabStop = false;
            // 
            // miscellaneousTable
            // 
            resources.ApplyResources(this.miscellaneousTable, "miscellaneousTable");
            this.miscellaneousTable.Controls.Add(this.minimizeToTrayCheckBox, 0, 0);
            this.miscellaneousTable.Controls.Add(this.autoClearCheckBox, 0, 1);
            this.miscellaneousTable.Name = "miscellaneousTable";
            // 
            // minimizeToTrayCheckBox
            // 
            resources.ApplyResources(this.minimizeToTrayCheckBox, "minimizeToTrayCheckBox");
            this.minimizeToTrayCheckBox.Name = "minimizeToTrayCheckBox";
            this.minimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoClearCheckBox
            // 
            resources.ApplyResources(this.autoClearCheckBox, "autoClearCheckBox");
            this.autoClearCheckBox.Name = "autoClearCheckBox";
            this.autoClearCheckBox.UseVisualStyleBackColor = true;
            // 
            // hostAddressIpControl
            // 
            resources.ApplyResources(this.hostAddressIpControl, "hostAddressIpControl");
            this.hostAddressIpControl.IPAddress = "127.0.0.1";
            this.hostAddressIpControl.Name = "hostAddressIpControl";
            // 
            // OptionsDialog
            // 
            this.AcceptButton = this.saveButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.optionsTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowInTaskbar = false;
            this.optionsTable.ResumeLayout(false);
            this.optionsTable.PerformLayout();
            this.buttonsFlowPanel.ResumeLayout(false);
            this.optionsTabControl.ResumeLayout(false);
            this.insimTabPage.ResumeLayout(false);
            this.insimTable.ResumeLayout(false);
            this.insimTable.PerformLayout();
            this.connectionGroupBox.ResumeLayout(false);
            this.connectionGroupBox.PerformLayout();
            this.connectionTable.ResumeLayout(false);
            this.connectionTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insimPortNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTable.ResumeLayout(false);
            this.launchLfsGroupBox.ResumeLayout(false);
            this.launchLfsGroupBox.PerformLayout();
            this.launchLfsTable.ResumeLayout(false);
            this.launchLfsTable.PerformLayout();
            this.miscellaneousGroupBox.ResumeLayout(false);
            this.miscellaneousGroupBox.PerformLayout();
            this.miscellaneousTable.ResumeLayout(false);
            this.miscellaneousTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel optionsTable;
        private System.Windows.Forms.FlowLayoutPanel buttonsFlowPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabControl optionsTabControl;
        private System.Windows.Forms.TabPage insimTabPage;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TableLayoutPanel generalTable;
        private System.Windows.Forms.GroupBox launchLfsGroupBox;
        private System.Windows.Forms.TableLayoutPanel launchLfsTable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button lfsExeBrowseButton;
        private System.Windows.Forms.TextBox lfsExeLocationTextBox;
        private System.Windows.Forms.CheckBox autoConnectCheckBox;
        private System.Windows.Forms.GroupBox miscellaneousGroupBox;
        private System.Windows.Forms.TableLayoutPanel miscellaneousTable;
        private System.Windows.Forms.CheckBox minimizeToTrayCheckBox;
        private System.Windows.Forms.CheckBox autoClearCheckBox;
        private System.Windows.Forms.TableLayoutPanel insimTable;
        private System.Windows.Forms.GroupBox connectionGroupBox;
        private System.Windows.Forms.TableLayoutPanel connectionTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox adminPasswordTextBox;
        private System.Windows.Forms.NumericUpDown insimPortNumericUpDown;
        private IPControl hostAddressIpControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown updateIntervalNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox enableMciUpdatesCheckBox;
        private System.Windows.Forms.CheckBox enableNlpUpdatesCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox updatesCheckedListBox;
    }
}