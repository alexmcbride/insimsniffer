namespace InSimSniffer.Library.Packets {
    internal enum VoteActions {
        VOTE_NONE,			// 0 - no vote
        VOTE_END,			// 1 - end race
        VOTE_RESTART,		// 2 - restart
        VOTE_QUALIFY,		// 3 - qualify
        VOTE_NUM
    }

    internal class IS_VTN : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte Zero { get; private set; }
        public byte UCID { get; private set; }
        public VoteActions Action { get; private set; }
        public byte Spare2 { get; private set; }
        public byte Spare3 { get; private set; }

        public IS_VTN() {
            Size = 8;
            Type = PacketType.ISP_VTN;
        }

        public IS_VTN(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            UCID = data[4];
            Action = (VoteActions)data[5];
            Spare2 = data[6];
            Spare3 = data[7];
        }
    }
}
