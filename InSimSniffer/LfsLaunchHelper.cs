using System;
using System.Diagnostics;
using System.IO;

namespace InSimSniffer {
    public class LfsLaunchHelper : IDisposable {
        private Process lfsProcess;
        private string lfsExePath;

        public LfsLaunchHelper(string lfsExePath) {
            this.lfsExePath = lfsExePath;
        }

        public void Launch(int insimPort) {
            lfsProcess = new Process();
            lfsProcess.StartInfo.Arguments = String.Format("/insim={0}", insimPort);
            lfsProcess.StartInfo.FileName = lfsExePath;
            lfsProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(lfsExePath);
            lfsProcess.Start();
        }

        public void WaitForIdle() {
            const int TimeToWait = 10 * 1000; // Milliseconds.

            lfsProcess.WaitForInputIdle(TimeToWait);
        }

        public void Dispose() {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                lfsProcess.Dispose();
            }
        }
    }
}
