using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace InSimSniffer {
    public partial class ExceptionDialog : Form {
        private const string LogFile = "Log.txt";

        public ExceptionDialog(Exception exception)
            : base() {
            if (exception == null) {
                throw new ArgumentNullException("exception");
            }

            InitializeComponent();

            messageTextBox.Text = GetExceptionText(exception);

            ActiveControl = exitButton;
        }

        private static string GetExceptionText(Exception exception) {
            StringBuilder text = new StringBuilder();
            text.AppendFormat(StringResources.ExceptionDialogVersionText, Program.Version, Environment.NewLine);
            text.AppendFormat(StringResources.ExceptionDialogDateText, DateTime.Now, Environment.NewLine);
            text.AppendFormat(StringResources.ExceptionDialogOSText, Environment.OSVersion.VersionString, Environment.NewLine);
            text.AppendFormat(StringResources.ExceptionDialogCultureText, Thread.CurrentThread.CurrentUICulture, Environment.NewLine);
            text.AppendFormat(StringResources.ExceptionDialogExceptionText, exception.GetType().Name, Environment.NewLine);
            text.AppendFormat(StringResources.ExceptionDialogMessageText, exception.Message, Environment.NewLine);
            text.AppendFormat(StringResources.ExceptionDialogSourceText, exception.Source, Environment.NewLine);
            text.AppendFormat(StringResources.ExceptionDialogTargetText, exception.TargetSite, Environment.NewLine);
            text.AppendFormat(StringResources.ExceptionDialogStackTraceText, exception.StackTrace, Environment.NewLine);
            text.AppendFormat(StringResources.ExceptionDialogInnerExceptionText, exception.InnerException, Environment.NewLine);
            return text.ToString();
        }

        private void OnCopyButtonClick(object sender, EventArgs e) {
            Clipboard.SetText(messageTextBox.Text, TextDataFormat.Text);
        }

        private void OnLogButtonClick(object sender, EventArgs e) {
            try {
                string path = Path.Combine(Program.StartupPath, LogFile);

                using (StreamWriter writer = new StreamWriter(path)) {
                    writer.Write(messageTextBox.Text);
                }

                Dialog.ShowInfo(
                    StringResources.ExceptionLogSuccessDialogTitle,
                    StringResources.ExceptionLogSuccessDialogMessage,
                    path);
            }
            catch (IOException ex) {
                Dialog.ShowError(
                    StringResources.ExceptionLogFailedDialogTitle,
                    StringResources.ExceptionLogFailedDialogMessage,
                    ex.Message);
            }
        }

        private void OnExitButtonClick(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
