using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace InSimSniffer {
    public partial class AboutDialog : Form {
        private static string Description {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(AssemblyDescriptionAttribute),
                    false);

                if (attributes.Any()) {
                    return ((AssemblyDescriptionAttribute)attributes[0]).Description;
                }

                return String.Empty;
            }
        }

        private static string Copyright {
            get {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(
                    typeof(AssemblyCopyrightAttribute),
                    false);

                if (attributes.Any()) {
                    return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
                }

                return String.Empty;
            }
        }

        public AboutDialog() {
            InitializeComponent();

            Text = String.Format(StringResources.AboutDialogTitle, Program.Name);
            nameLabel.Text = Program.Name;
            versionLabel.Text = String.Format(StringResources.AboutDialogVersion, Program.Version);
            copyrightLabel.Text = Copyright;
            descriptionLabel.Text = Description;
        }

        private void OnThrowExceptionButtonClick(object sender, EventArgs e) {
            throw new FishDanceException(StringResources.AboutFishDanceExceptionMessage);
        }
    }
}
