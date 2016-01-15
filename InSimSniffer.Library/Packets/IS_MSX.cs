namespace InSimSniffer.Library.Packets {
    internal class IS_MSX : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public byte Zero { get; set; }
        public string Msg { get; set; }

        public IS_MSX() {
            Size = 100;
            Type = PacketType.ISP_MSX;
            Msg = string.Empty;
        }

        public IS_MSX(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            Msg = EncodingHelper.GetString(data, 4, 96);
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[100];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = Zero;
            PacketHelper.GetBytes(data, 4, Msg, 96);
            return data;
        }
    }
}
