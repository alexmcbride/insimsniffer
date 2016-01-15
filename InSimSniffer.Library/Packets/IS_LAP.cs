using System;

namespace InSimSniffer.Library.Packets {
    internal enum PenaltyValues {
        PENALTY_NONE,		// 0		
        PENALTY_DT,			// 1
        PENALTY_DT_VALID,	// 2
        PENALTY_SG,			// 3
        PENALTY_SG_VALID,	// 4
        PENALTY_30,			// 5
        PENALTY_45,			// 6
        PENALTY_NUM
    }

    internal class IS_LAP : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public uint LTime { get; private set; }
        public uint ETime { get; private set; }
        public ushort LapsDone { get; private set; }
        public PlayerFlags Flags { get; private set; }
        public byte Sp0 { get; private set; }
        public PenaltyValues Penalty { get; private set; }
        public byte NumStops { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_LAP() {
            Size = 20;
            Type = PacketType.ISP_LAP;
        }

        public IS_LAP(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            LTime = BitConverter.ToUInt32(data, 4);
            ETime = BitConverter.ToUInt32(data, 8);
            LapsDone = BitConverter.ToUInt16(data, 12);
            Flags = (PlayerFlags)BitConverter.ToUInt16(data, 14);
            Sp0 = data[16];
            Penalty = (PenaltyValues)data[17];
            NumStops = data[18];
            Sp3 = data[19];
        }
    }
}
