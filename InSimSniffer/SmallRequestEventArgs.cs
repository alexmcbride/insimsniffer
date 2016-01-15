using System;
using InSimSniffer.Library;

namespace InSimSniffer {
    public class SmallRequestEventArgs : EventArgs {
        public SmallType Small {
            get;
            private set;
        }

        public SmallRequestEventArgs(SmallType small) {
            Small = small;
        }
    }
}
