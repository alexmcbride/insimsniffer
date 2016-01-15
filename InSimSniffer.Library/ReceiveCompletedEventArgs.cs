using System;
using System.Collections.Generic;

namespace InSimSniffer.Library {
    internal class ReceiveCompletedEventArgs : EventArgs {
        public byte[] Data { get; private set; }

        public ReceiveCompletedEventArgs(byte[] data) {
            Data = data;
        }
    }
}
