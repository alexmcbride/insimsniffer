namespace InSimSniffer.Library.Packets {
    internal class IS_BTT : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte UCID { get; private set; }
        public byte ClickID { get; private set; }
        public byte Inst { get; private set; }
        public byte TypeIn { get; private set; }
        public byte Sp3 { get; private set; }
        public string Text { get; private set; }

        public IS_BTT(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            UCID = data[3];
            ClickID = data[4];
            Inst = data[5];
            TypeIn = data[6];
            Sp3 = data[7];
            Text = EncodingHelper.GetString(data, 8, 96);
        }
    }
}
