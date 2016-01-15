namespace InSimSniffer.Library.Packets {
    internal enum PenaltyReasons {
        PENR_UNKNOWN,		// 0 - unknown or cleared penalty
        PENR_ADMIN,			// 1 - penalty given by admin
        PENR_WRONG_WAY,		// 2 - wrong way driving
        PENR_FALSE_START,	// 3 - starting before green light
        PENR_SPEEDING,		// 4 - speeding in pit lane
        PENR_STOP_SHORT,	// 5 - stop-go pit stop too short
        PENR_STOP_LATE,		// 6 - compulsory stop is too late
        PENR_NUM
    }

    internal class IS_PEN : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public PenaltyValues OldPen { get; private set; }
        public PenaltyValues NewPen { get; private set; }
        public PenaltyReasons Reason { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_PEN() {
            Size = 8;
            Type = PacketType.ISP_PEN;
        }

        public IS_PEN(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            OldPen = (PenaltyValues)data[4];
            NewPen = (PenaltyValues)data[5];
            Reason = (PenaltyReasons)data[6];
            Sp3 = data[7];
        }
    }
}
