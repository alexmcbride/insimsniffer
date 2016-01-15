namespace InSimSniffer.Library.Packets {
    internal class IS_NLP : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte NumP { get; private set; }
        public NodeLap[] Info { get; private set; }

        public IS_NLP(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            NumP = data[3];
            Info = new NodeLap[NumP];

            for (int i = 0, offset = 4; i < NumP; i++, offset += 6) {
                Info[i] = new NodeLap(data, offset);
            }
        }
    }
}
