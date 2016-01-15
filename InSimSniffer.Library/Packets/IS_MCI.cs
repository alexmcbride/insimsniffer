namespace InSimSniffer.Library.Packets {
    internal class IS_MCI : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte NumC { get; private set; }
        public CompCar[] Info { get; private set; }

        public IS_MCI(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            NumC = data[3];
            Info = new CompCar[NumC];

            for (int i = 0, offset = 4; i < NumC; i++, offset += 28) {
                Info[i] = new CompCar(data, offset);
            }
        }
    }
}
