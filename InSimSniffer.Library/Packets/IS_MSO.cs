namespace InSimSniffer.Library.Packets {
    internal enum UserTypes {
        MSO_SYSTEM,			// 0 - system message
        MSO_USER,			// 1 - normal visible user message
        MSO_PREFIX,			// 2 - hidden message starting with special prefix (see ISI)
        MSO_O,				// 3 - hidden message typed on local pc with /o command
        MSO_NUM
    }

    internal class IS_MSO : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte Zero { get; private set; }
        public byte UCID { get; private set; }
        public byte PLID { get; private set; }
        public UserTypes UserType { get; private set; }
        public byte TextStart { get; private set; }
        public string Msg { get; private set; }

        public IS_MSO() {
            Size = 136;
            Type = PacketType.ISP_MSO;
        }

        public IS_MSO(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            UCID = data[4];
            PLID = data[5];
            UserType = (UserTypes)data[6];
            TextStart = data[7];
            Msg = EncodingHelper.GetString(data, 8, 128);
        }
    }
}
