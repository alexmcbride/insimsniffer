using System;

namespace InSimSniffer.Library {
    public class InSimCloseEventArgs : EventArgs {
        public InSimCloseReason Reason { get; private set; }

        public InSimCloseEventArgs(InSimCloseReason reason) {
            Reason = reason;
        }
    }
}
