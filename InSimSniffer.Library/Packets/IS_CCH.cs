namespace InSimSniffer.Library.Packets {
    internal class IS_CCH : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public CameraViews Camera { get; private set; }
        public byte Sp1 { get; private set; }
        public byte Sp2 { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_CCH() {
            Size = 8;
            Type = PacketType.ISP_CCH;
        }

        public IS_CCH(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            Camera = (CameraViews)data[4];
            Sp1 = data[5];
            Sp2 = data[6];
            Sp3 = data[7];
        }
    }
}
