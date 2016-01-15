namespace InSimSniffer.Library.Packets {
    internal class IS_TINY : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public TinyType SubT { get; set; }

        public IS_TINY() {
            Size = 4;
            Type = PacketType.ISP_TINY;
        }

        public IS_TINY(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            SubT = (TinyType)data[3];
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[4];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = (byte)SubT;
            return data;
        }
    }
}
