using System;

namespace InSimSniffer.Library.Packets {
    internal class ObjectInfo {
        public short X { get; private set; }
        public short Y { get; private set; }
        public sbyte Zchar { get; private set; }
        public byte Flags { get; private set; }
        public byte Index { get; private set; }
        public byte Heading { get; private set; }

        public ObjectInfo(byte[] data, int index) {
            X = BitConverter.ToInt16(data, index + 0);
            Y = BitConverter.ToInt16(data, index + 2);
            Zchar = (sbyte)data[4];
            Flags = data[5];
            Index = data[6];
            Heading = data[7];
        }
    }
}
