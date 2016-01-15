using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum RaceFlags {
        HOSTF_CAN_VOTE = 1,
        HOSTF_CAN_SELECT = 2,
        HOSTF_MID_RACE = 32,
        HOSTF_MUST_PIT = 64,
        HOSTF_CAN_RESET = 128,
        HOSTF_FCV = 256,
        HOSTF_CRUISE = 512,
    }

    internal class IS_RST : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte Zero { get; private set; }
        public byte RaceLaps { get; private set; }
        public byte QualMins { get; private set; }
        public byte NumP { get; private set; }
        public byte Timing { get; private set; }
        public string Track { get; private set; }
        public byte Weather { get; private set; }
        public byte Wind { get; private set; }
        public RaceFlags Flags { get; private set; }
        public ushort NumNodes { get; private set; }
        public ushort Finish { get; private set; }
        public ushort Split1 { get; private set; }
        public ushort Split2 { get; private set; }
        public ushort Split3 { get; private set; }

        public IS_RST() {
            Size = 28;
            Type = PacketType.ISP_RST;
        }

        public IS_RST(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            RaceLaps = data[4];
            QualMins = data[5];
            NumP = data[6];
            Timing = data[7];
            Track = EncodingHelper.GetString(data, 8, 6);
            Weather = data[14];
            Wind = data[15];
            Flags = (RaceFlags)BitConverter.ToUInt16(data, 16);
            NumNodes = BitConverter.ToUInt16(data, 18);
            Finish = BitConverter.ToUInt16(data, 20);
            Split1 = BitConverter.ToUInt16(data, 22);
            Split2 = BitConverter.ToUInt16(data, 24);
            Split3 = BitConverter.ToUInt16(data, 26);
        }
    }
}
