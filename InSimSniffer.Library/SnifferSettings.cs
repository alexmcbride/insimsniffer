using System;

namespace InSimSniffer.Library {
    [Serializable]
    public class SnifferSettings {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Admin { get; set; }
        public string Name { get; set; }
        public int Interval { get; set; }
        public bool EnableMci { get; set; }
        public bool EnableNlp { get; set; }
        public bool EnableCon { get; set; }
        public bool EnableHlv { get; set; }
        public bool EnableObh { get; set; }
        public bool EnableAxmEdit { get; set; }
        public bool EnableAxmLoad { get; set; }

        public SnifferSettings() {
            Host = String.Empty;
            Admin = String.Empty;
            Name = String.Empty;
        }

        public override string ToString() {
            return String.Format("{0}:{1}", Host, Port);
        }
    }
}
