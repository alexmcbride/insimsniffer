using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_SPX : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public uint STime { get; private set; }
        public uint ETime { get; private set; }
        public byte Split { get; private set; }
        public PenaltyValues Penalty { get; private set; }
        public byte NumStops { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_SPX() {
            Size = 16;
            Type = PacketType.ISP_SPX;
        }

        public IS_SPX(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            STime = BitConverter.ToUInt32(data, 4);
            ETime = BitConverter.ToUInt32(data, 8);
            Split = data[12];
            Penalty = (PenaltyValues)data[13];
            NumStops = data[14];
            Sp3 = data[15];
        }
    }
}
