using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_PFL : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public PlayerFlags Flags { get; private set; }
        public ushort Spare { get; private set; }

        public IS_PFL() {
            Size = 8;
            Type = PacketType.ISP_PFL;
        }

        public IS_PFL(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            Flags = (PlayerFlags)BitConverter.ToUInt16(data, 4);
            Spare = BitConverter.ToUInt16(data, 6);
        }
    }
}
