using System;

namespace InSimSniffer.Library.Packets {
    internal class NodeLap {
        public ushort Node { get; private set; }
        public ushort Lap { get; private set; }
        public byte PLID { get; private set; }
        public byte Position { get; private set; }

        public NodeLap(byte[] data, int offset) {
            Node = BitConverter.ToUInt16(data, offset + 0);
            Lap = BitConverter.ToUInt16(data, offset + 2);
            PLID = data[offset + 4];
            Position = data[offset + 5];
        }
    }
}
