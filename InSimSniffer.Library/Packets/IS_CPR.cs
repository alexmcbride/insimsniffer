namespace InSimSniffer.Library.Packets {
    internal class IS_CPR : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte UCID { get; private set; }
        public string PName { get; private set; }
        public string Plate { get; private set; }

        public IS_CPR() {
            Size = 36;
            Type = PacketType.ISP_CPR;
        }

        public IS_CPR(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            UCID = data[3];
            PName = EncodingHelper.GetString(data, 4, 24);
            Plate = EncodingHelper.GetString(data, 28, 8);
        }
    }
}
