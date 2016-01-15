using System;
using System.Windows.Forms;

namespace InSimSniffer {
    public static class ExtensionMethods {
        public static void ScrollToEnd(this TextBoxBase textBox) {
            if (textBox == null) {
                throw new ArgumentNullException("textBox");
            }

            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }

        public static string ToShortTimeString(this TimeSpan timeSpan) {
            if (timeSpan.Hours > 0) {
                return timeSpan.ToString(@"h\:mm\:ss\.fff");
            }
            return timeSpan.ToString(@"m\:ss\.fff");
        }

        public static void CheckAll(this CheckedListBox checkedListBox, bool check) {
            if (checkedListBox == null) {
                throw new ArgumentNullException("checkedListBox");
            }

            checkedListBox.BeginUpdate();
            for (int i = 0; i < checkedListBox.Items.Count; i++) {
                checkedListBox.SetItemChecked(i, check);
            }
            checkedListBox.EndUpdate();
        }
    }
}
