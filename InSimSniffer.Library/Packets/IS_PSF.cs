using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_PSF : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public uint STime { get; private set; }
        public uint Spare { get; private set; }

        public IS_PSF() {
            Size = 12;
            Type = PacketType.ISP_PSF;
        }

        public IS_PSF(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            STime = BitConverter.ToUInt32(data, 4);
            Spare = BitConverter.ToUInt32(data, 8);
        }
    }
}
