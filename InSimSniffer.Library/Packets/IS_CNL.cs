namespace InSimSniffer.Library.Packets {
    internal enum LeaveReasons {
        LEAVR_DISCO,		// 0 - disconnect
        LEAVR_TIMEOUT,		// 1 - timed out
        LEAVR_LOSTCONN,		// 2 - lost connection
        LEAVR_KICKED,		// 3 - kicked
        LEAVR_BANNED,		// 4 - banned
        LEAVR_SECURITY,		// 5 - OOS or cheat protection
        LEAVR_NUM
    }

    internal class IS_CNL : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte UCID { get; private set; }
        public LeaveReasons Reason { get; private set; }
        public byte Total { get; private set; }
        public byte Sp2 { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_CNL() {
            Size = 8;
            Type = PacketType.ISP_CNL;
        }

        public IS_CNL(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            UCID = data[3];
            Reason = (LeaveReasons)data[4];
            Total = data[5];
            Sp2 = data[6];
            Sp3 = data[7];
        }
    }
}
