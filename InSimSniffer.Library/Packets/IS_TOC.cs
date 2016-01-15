namespace InSimSniffer.Library.Packets {
    internal class IS_TOC : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public byte OldUCID { get; private set; }
        public byte NewUCID { get; private set; }
        public byte Sp2 { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_TOC() {
            Size = 8;
            Type = PacketType.ISP_TOC;
        }

        public IS_TOC(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            OldUCID = data[4];
            NewUCID = data[5];
            Sp2 = data[6];
            Sp3 = data[7];
        }
    }
}
