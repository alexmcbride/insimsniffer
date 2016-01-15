using System;

namespace InSimSniffer.Library.Packets {
    internal class CarContact {
        public byte PLID { get; private set; }
        public CompCarInfos Info { get; private set; }
        public byte Sp2 { get; private set; }
        public sbyte Steer { get; private set; }

        public byte ThrBrk { get; private set; }
        public byte CluHan { get; private set; }
        public byte GearSp { get; private set; }
        public byte Speed { get; private set; }

        public byte Direction { get; private set; }
        public byte Heading { get; private set; }
        public sbyte AccelF { get; private set; }
        public sbyte AccelR { get; private set; }

        public short X { get; private set; }
        public short Y { get; private set; }

        public CarContact(byte[] data, int offset) {
            PLID = data[offset + 0];
            Info = (CompCarInfos)data[offset + 1];
            Sp2 = data[offset + 2];
            Steer = (sbyte)data[offset + 3];
            ThrBrk = data[offset + 4];
            CluHan = data[offset + 5];
            GearSp = data[offset + 6];
            Speed = data[offset + 7];
            Direction = data[offset + 8];
            Heading = data[offset + 9];
            AccelF = (sbyte)data[offset + 10];
            AccelR = (sbyte)data[offset + 11];
            X = BitConverter.ToInt16(data, 12);
            Y = BitConverter.ToInt16(data, 14);
        }
    }
}
