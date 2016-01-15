using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace InSimSniffer {
    public static class Program {
        public static string Name {
            get { return new AssemblyName(typeof(Program).Assembly.FullName).Name; }
        }

        public static Version Version {
            get { return new AssemblyName(typeof(Program).Assembly.FullName).Version; }
        }

        public static string StartupPath {
            get { return Application.StartupPath; }
        }

        [STAThread]
        private static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if !DEBUG
            // When not debugging we want exceptions caught by the exception handler.
            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;
            Application.ThreadException += OnApplicationThreadException;
#endif

            // Start main app.
            new SnifferApp().Run(args);
        }

        private static void OnApplicationThreadException(object sender, ThreadExceptionEventArgs e) {
            ManageUnhandledException(e.Exception);
        }

        private static void OnCurrentDomainUnhandledException(object sender, System.UnhandledExceptionEventArgs e) {
            ManageUnhandledException((Exception)e.ExceptionObject);
        }

        private static void ManageUnhandledException(Exception exception) {
            using (ExceptionDialog dlg = new ExceptionDialog(exception)) {
                try {
                    // Try run as app otherwise show as dialog.
                    try {
                        Application.Run(dlg);
                    }
                    catch (InvalidOperationException) {
                        dlg.ShowDialog();
                    }
                }
                catch (Exception ex) {
                    // Something very bad has happened...
                    Dialog.ShowError(
                        StringResources.StartupCriticalErrorDialogTitle,
                        StringResources.StartupCriticalErrorDialogMessage,
                        ex.Message);
                }
                finally {
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
    }
}
