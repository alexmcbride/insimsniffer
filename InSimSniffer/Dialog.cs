using System;
using System.Windows.Forms;

namespace InSimSniffer {
    public static class Dialog {
        public static Form Owner { get; set; }

        public static DialogResult ShowError(string caption, string message, params object[] args) {
            return MessageBox.Show(
                Owner,
                String.Format(message, args),
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static DialogResult ShowInfo(string caption, string message, params object[] args) {
            return MessageBox.Show(
                Owner,
                String.Format(message, args),
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static bool ShowYesNo(string caption, string message, params object[] args) {
            return MessageBox.Show(
                Owner,
                String.Format(message, args),
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
