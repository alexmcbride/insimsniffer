using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum HLVCFlags {
        // 0 : ground / 1 : wall / 4 : speeding
        Ground = 0,
        Wall = 1,
        Speeding = 4,
    }

    internal class IS_HLV : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public byte HLVC { get; private set; }
        public byte Sp1 { get; private set; }
        public ushort Time { get; private set; }
        public CarContOBJ C { get; private set; }

        public IS_HLV() {
            Size = 16;
            Type = PacketType.ISP_HLV;
        }

        public IS_HLV(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            HLVC = data[4];
            Sp1 = data[5];
            Time = BitConverter.ToUInt16(data, 6);
            C = new CarContOBJ(data, 8);
        }
    }
}
