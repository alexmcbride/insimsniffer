namespace InSimSniffer.Library.Packets {
    internal enum InSimMultiHosts {
        Guest = 0,
        Host = 1,
    }

    internal class IS_ISM : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte Zero { get; private set; }
        public byte Host { get; private set; }
        public byte Sp1 { get; private set; }
        public byte Sp2 { get; private set; }
        public byte Sp3 { get; private set; }
        public string HName { get; private set; }

        public IS_ISM() {
            Size = 40;
            Type = PacketType.ISP_ISM;
        }

        public IS_ISM(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            Host = data[4];
            Sp1 = data[5];
            Sp2 = data[6];
            Sp3 = data[7];
            HName = EncodingHelper.GetString(data, 8, 32);
        }
    }
}
