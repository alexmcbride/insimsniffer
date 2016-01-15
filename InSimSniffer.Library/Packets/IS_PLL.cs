namespace InSimSniffer.Library.Packets {
    internal class IS_PLL : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }

        public IS_PLL() {
            Size = 4;
            Type = PacketType.ISP_PLL;
        }

        public IS_PLL(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
        }
    }
}
