namespace InSimSniffer.Library.Packets {
    internal class IS_SCC : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public byte Zero { get; set; }
        public byte ViewPLID { get; set; }
        public CameraViews InGameCam { get; set; }
        public byte Sp2 { get; set; }
        public byte Sp3 { get; set; }

        public IS_SCC() {
            Size = 8;
            Type = PacketType.ISP_SCC;
        }

        public IS_SCC(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            ViewPLID = data[4];
            InGameCam = (CameraViews)data[5];
            Sp2 = data[6];
            Sp3 = data[7];
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[8];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = Zero;
            data[4] = ViewPLID;
            data[5] = (byte)InGameCam;
            data[6] = Sp2;
            data[7] = Sp3;
            return data;
        }
    }
}
