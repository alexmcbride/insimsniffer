using System.IO;
using Microsoft.Win32;

namespace InSimSniffer {
    public static class LfsRegistryHelper {
        private const string LfsRegistryPath = @"Software\Live for Speed";

        public static bool IsLfsInstalled() {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(LfsRegistryPath)) {
                return key != null;
            }
        }

        public static string GetLfsExePath() {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(LfsRegistryPath)) {
                if (key != null) {
                    string value = key.GetValue(null) as string;
                    if (value != null) {
                        string path = Path.Combine(value, "LFS.exe");
                        if (File.Exists(path)) {
                            return path;
                        }
                    }
                }
            }
            return null;
        }
    }
}
