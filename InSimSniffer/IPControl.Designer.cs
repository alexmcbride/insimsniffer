namespace InSimSniffer {
    partial class IPControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPControl));
            this.ip1TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ip2TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ip3TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ip4TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ip1TextBox
            // 
            resources.ApplyResources(this.ip1TextBox, "ip1TextBox");
            this.ip1TextBox.Name = "ip1TextBox";
            this.ip1TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnIPTextBoxKeyDown);
            this.ip1TextBox.Leave += new System.EventHandler(this.OnIPTextBoxLeave);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ip2TextBox
            // 
            resources.ApplyResources(this.ip2TextBox, "ip2TextBox");
            this.ip2TextBox.Name = "ip2TextBox";
            this.ip2TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnIPTextBoxKeyDown);
            this.ip2TextBox.Leave += new System.EventHandler(this.OnIPTextBoxLeave);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ip3TextBox
            // 
            resources.ApplyResources(this.ip3TextBox, "ip3TextBox");
            this.ip3TextBox.Name = "ip3TextBox";
            this.ip3TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnIPTextBoxKeyDown);
            this.ip3TextBox.Leave += new System.EventHandler(this.OnIPTextBoxLeave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // ip4TextBox
            // 
            resources.ApplyResources(this.ip4TextBox, "ip4TextBox");
            this.ip4TextBox.Name = "ip4TextBox";
            this.ip4TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnIPTextBoxKeyDown);
            this.ip4TextBox.Leave += new System.EventHandler(this.OnIPTextBoxLeave);
            // 
            // IPControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ip4TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ip3TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ip2TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ip1TextBox);
            this.Name = "IPControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ip1TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip2TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ip3TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ip4TextBox;
    }
}
