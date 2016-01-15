using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum OBHFlags {
        OBH_LAYOUT = 1,	// an added object
        OBH_CAN_MOVE = 2,	// a movable object
        OBH_WAS_MOVING = 4,	// was moving before this hit
        OBH_ON_SPOT = 8,	// object in original position
    }

    internal class IS_OBH : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public ushort SpClose { get; private set; }
        public ushort Time { get; private set; }
        public CarContOBJ C { get; private set; }
        public short X { get; private set; }
        public short Y { get; private set; }
        public byte Sp0 { get; private set; }
        public byte Sp1 { get; private set; }
        public byte Index { get; private set; }
        public OBHFlags OBHFlags { get; private set; }

        public IS_OBH() {
            Size = 24;
            Type = PacketType.ISP_OBH;
        }

        public IS_OBH(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            SpClose = BitConverter.ToUInt16(data, 4);
            Time = BitConverter.ToUInt16(data, 6);
            C = new CarContOBJ(data, 8);
            X = BitConverter.ToInt16(data, 16);
            Y = BitConverter.ToInt16(data, 18);
            Sp0 = data[20];
            Sp1 = data[21];
            Index = data[22];
            OBHFlags = (OBHFlags)data[23];
        }
    }
}
