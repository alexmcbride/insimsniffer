namespace InSimSniffer.Library.Packets {
    internal class IS_III : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte Zero { get; private set; }
        public byte UCID { get; private set; }
        public byte PLID { get; private set; }
        public byte Sp2 { get; private set; }
        public byte Sp3 { get; private set; }
        public string Msg { get; private set; }

        public IS_III() {
            Size = 72;
            Type = PacketType.ISP_III;
            Msg = string.Empty;
        }

        public IS_III(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            UCID = data[4];
            PLID = data[5];
            Sp2 = data[6];
            Sp3 = data[7];
            Msg = EncodingHelper.GetString(data, 8, 64);
        }
    }
}
