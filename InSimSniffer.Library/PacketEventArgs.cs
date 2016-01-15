using System;

namespace InSimSniffer.Library {
    public class PacketEventArgs : EventArgs {
        public SniffedPacket Packet {
            get;
            private set;
        }

        public PacketEventArgs(SniffedPacket packet) {
            Packet = packet;
        }
    }
}
