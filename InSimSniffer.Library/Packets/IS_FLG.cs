namespace InSimSniffer.Library.Packets {
    internal enum TrackFlags {
        Blue = 1,
        Yellow = 2,
    }

    internal class IS_FLG : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public byte OffOn { get; private set; }
        public byte Flag { get; private set; }
        public byte CarBehind { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_FLG() {

            Size = 8;
            Type = PacketType.ISP_FLG;
        }

        public IS_FLG(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            OffOn = data[4];
            Flag = data[5];
            CarBehind = data[6];
            Sp3 = data[7];
        }
    }
}
