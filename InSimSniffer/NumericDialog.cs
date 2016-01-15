using System;
using System.Windows.Forms;

namespace InSimSniffer {
    public partial class NumericDialog : Form {
        private long originalValue;

        public string Title {
            get {
                return Text;
            }

            set {
                Text = value;
            }
        }

        public string Caption {
            get {
                return captionLabel.Text;
            }

            set {
                captionLabel.Text = value;
            }
        }

        public long Value {
            get {
                return (long)valueNumericUpDown.Value;
            }

            set {
                originalValue = value;
                valueNumericUpDown.Value = value;
            }
        }

        public decimal Maximum {
            get {
                return valueNumericUpDown.Maximum;
            }

            set {
                valueNumericUpDown.Maximum = value;
            }
        }

        public decimal Minimum {
            get {
                return valueNumericUpDown.Minimum;
            }

            set {
                valueNumericUpDown.Minimum = value;
            }
        }

        public NumericDialog() {
            InitializeComponent();

            ActiveControl = valueNumericUpDown;
        }

        private void OnOkButtonClick(object sender, EventArgs e) {
            if (valueNumericUpDown.Value != originalValue) {
                DialogResult = DialogResult.OK;
            }
            else {
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }
    }
}
