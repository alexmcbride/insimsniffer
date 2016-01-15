namespace InSimSniffer.Library.Packets {
    internal enum MessageSounds {
        SND_SILENT,
        SND_MESSAGE,
        SND_SYSMESSAGE,
        SND_INVALIDKEY,
        SND_ERROR,
        SND_NUM
    }

    internal class IS_MSL : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public MessageSounds Sound { get; set; }
        public string Msg { get; set; }

        public IS_MSL() {
            Size = 132;
            Type = PacketType.ISP_MSL;
            Msg = string.Empty;
        }

        public IS_MSL(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Sound = (MessageSounds)data[3];
            Msg = EncodingHelper.GetString(data, 4, 128);
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[132];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = (byte)Sound;
            PacketHelper.GetBytes(data, 4, Msg, 128);
            return data;
        }
    }
}
