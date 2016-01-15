using System;
using InSimSniffer.Library.Packets;

namespace InSimSniffer {
    public class TinyRequestEventArgs : EventArgs {
        public TinyType Tiny {
            get;
            private set;
        }

        public TinyRequestEventArgs(TinyType tiny) {
            Tiny = tiny;
        }
    }
}
