using System;
using System.Windows.Forms;
using System.Globalization;

namespace InSimSniffer {
    public partial class IPControl : UserControl {
        public string IPAddress {
            get {
                return String.Format(
                    "{0}.{1}.{2}.{3}",
                    ip1TextBox.Text,
                    ip2TextBox.Text,
                    ip3TextBox.Text,
                    ip4TextBox.Text);
            }

            set {
                if (value == null) {
                    throw new ArgumentNullException("value");
                }

                string[] tokens = value.Split('.');
                ip1TextBox.Text = tokens[0];
                ip2TextBox.Text = tokens[1];
                ip3TextBox.Text = tokens[2];
                ip4TextBox.Text = tokens[3];
            }
        }

        public IPControl() {
            InitializeComponent();
        }

        private void OnIPTextBoxKeyDown(object sender, KeyEventArgs e) {
            // Filter key presses to allow only 0-9, backspace and delete.
            if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete) {
                e.SuppressKeyPress = e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9;
            }
        }

        private void OnIPTextBoxLeave(object sender, EventArgs e) {
            // Reset value to 0 if no value entered.
            TextBox ipTextBox = (TextBox)sender;
            if (String.IsNullOrWhiteSpace(ipTextBox.Text)) {
                ipTextBox.Text = Int32.MinValue.ToString();
            }
        }
    }
}
