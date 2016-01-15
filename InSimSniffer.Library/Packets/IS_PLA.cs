namespace InSimSniffer.Library.Packets {
    internal enum PitLaneFacts {
        PITLANE_EXIT,		// 0 - left pit lane
        PITLANE_ENTER,		// 1 - entered pit lane
        PITLANE_NO_PURPOSE,	// 2 - entered for no purpose
        PITLANE_DT,			// 3 - entered for drive-through
        PITLANE_SG,			// 4 - entered for stop-go
        PITLANE_NUM
    }

    internal class IS_PLA : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public PitLaneFacts Fact { get; private set; }
        public byte Sp1 { get; private set; }
        public byte Sp2 { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_PLA() {
            Size = 8;
            Type = PacketType.ISP_PLA;
        }

        public IS_PLA(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            Fact = (PitLaneFacts)data[4];
            Sp1 = data[5];
            Sp2 = data[6];
            Sp3 = data[7];
        }
    }
}
