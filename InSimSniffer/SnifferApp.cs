using System;
using InSimSniffer.Properties;
using Microsoft.VisualBasic.ApplicationServices;

namespace InSimSniffer {
    public class SnifferApp : WindowsFormsApplicationBase {
        private Settings settings = Settings.Default;

        public SnifferApp()
            : base() {
            IsSingleInstance = true;
        }

        protected override void OnCreateMainForm() {
            MainForm form = new MainForm(CommandLineArgs);

            // Set app main form.
            MainForm = form;

            // Set main form for dialog boxes.
            Dialog.Owner = form;

            base.OnCreateMainForm();
        }

        protected override bool OnStartup(StartupEventArgs eventArgs) {
            if (settings.FirstRun) {
                settings.FirstRun = false;
                settings.LfsExePath = LfsRegistryHelper.GetLfsExePath();
                settings.ExportPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }

            return base.OnStartup(eventArgs);
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs) {
            eventArgs.BringToForeground = true;

            ((MainForm)MainForm).RestoreWindowState();

            base.OnStartupNextInstance(eventArgs);
        }

        protected override void OnShutdown() {
            settings.Save();

            base.OnShutdown();
        }
    }
}
