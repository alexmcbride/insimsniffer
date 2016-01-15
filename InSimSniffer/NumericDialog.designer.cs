namespace InSimSniffer {
    partial class NumericDialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumericDialog));
            this.mainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.captionLabel = new System.Windows.Forms.Label();
            this.valueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.mainTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).BeginInit();
            this.buttonsFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTablePanel
            // 
            resources.ApplyResources(this.mainTablePanel, "mainTablePanel");
            this.mainTablePanel.Controls.Add(this.captionLabel, 0, 0);
            this.mainTablePanel.Controls.Add(this.valueNumericUpDown, 0, 1);
            this.mainTablePanel.Controls.Add(this.buttonsFlowPanel, 0, 2);
            this.mainTablePanel.Name = "mainTablePanel";
            // 
            // captionLabel
            // 
            resources.ApplyResources(this.captionLabel, "captionLabel");
            this.captionLabel.Name = "captionLabel";
            // 
            // valueNumericUpDown
            // 
            resources.ApplyResources(this.valueNumericUpDown, "valueNumericUpDown");
            this.valueNumericUpDown.Name = "valueNumericUpDown";
            // 
            // buttonsFlowPanel
            // 
            resources.ApplyResources(this.buttonsFlowPanel, "buttonsFlowPanel");
            this.buttonsFlowPanel.Controls.Add(this.cancelButton);
            this.buttonsFlowPanel.Controls.Add(this.okButton);
            this.buttonsFlowPanel.Name = "buttonsFlowPanel";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OnOkButtonClick);
            // 
            // NumericDialogEx
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.mainTablePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NumericDialogEx";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.mainTablePanel.ResumeLayout(false);
            this.mainTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).EndInit();
            this.buttonsFlowPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTablePanel;
        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.NumericUpDown valueNumericUpDown;
        private System.Windows.Forms.FlowLayoutPanel buttonsFlowPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}