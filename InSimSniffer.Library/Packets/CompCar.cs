using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum CompCarInfos {
        CCI_NONE = 0,
        CCI_BLUE = 1,		// this car is in the way of a driver who is a lap ahead
        CCI_YELLOW = 2,		// this car is slow or stopped and in a dangerous place

        CCI_LAG = 32,		// this car is lagging (missing or delayed position packets)

        CCI_FIRST = 64,	// this is the first compcar in this set of MCI packets
        CCI_LAST = 128,	// this is the last compcar in this set of MCI packets
    }

    internal class CompCar {
        public ushort Node { get; private set; }
        public ushort Lap { get; private set; }
        public byte PLID { get; private set; }
        public byte Position { get; private set; }
        public CompCarInfos Info { get; private set; }
        public byte Sp3 { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public ushort Speed { get; private set; }
        public ushort Direction { get; private set; }
        public ushort Heading { get; private set; }
        public short AngVel { get; private set; }

        public CompCar(byte[] data, int offset) {
            Node = BitConverter.ToUInt16(data, offset + 0);
            Lap = BitConverter.ToUInt16(data, offset + 2);
            PLID = data[offset + 4];
            Position = data[offset + 5];
            Info = (CompCarInfos)data[offset + 6];
            Sp3 = data[offset + 7];
            X = BitConverter.ToInt32(data, offset + 8);
            Y = BitConverter.ToInt32(data, offset + 12);
            Z = BitConverter.ToInt32(data, offset + 16);
            Speed = BitConverter.ToUInt16(data, offset + 20);
            Direction = BitConverter.ToUInt16(data, offset + 22);
            Heading = BitConverter.ToUInt16(data, offset + 24);
            AngVel = BitConverter.ToInt16(data, offset + 26);
        }
    }
}
