using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum PitWorkFlags {
        PSE_NOTHING = 0,		// bit 0 (1)
        PSE_STOP = 1,			// bit 1 (2)
        PSE_FR_DAM = 2,			// bit 2 (4)
        PSE_FR_WHL = 4,			// etc...
        PSE_LE_FR_DAM = 8,
        PSE_LE_FR_WHL = 16,
        PSE_RI_FR_DAM = 32,
        PSE_RI_FR_WHL = 64,
        PSE_RE_DAM = 128,
        PSE_RE_WHL = 256,
        PSE_LE_RE_DAM = 512,
        PSE_LE_RE_WHL = 1024,
        PSE_RI_RE_DAM = 2048,
        PSE_RI_RE_WHL = 4096,
        PSE_BODY_MINOR = 8192,
        PSE_BODY_MAJOR = 16384,
        PSE_SETUP = 32768,
        PSE_REFUEL = 65536,
        PSE_NUM = 131072,
    }

    internal class IS_PIT : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public ushort LapsDone { get; private set; }
        public PlayerFlags Flags { get; private set; }
        public byte Sp0 { get; private set; }
        public PenaltyValues Penalty { get; private set; }
        public byte NumStops { get; private set; }
        public byte Sp3 { get; private set; }
        public TyreCompounds[] Tyres { get; private set; }
        public PitWorkFlags Work { get; private set; }
        public uint Spare { get; private set; }

        public IS_PIT() {
            Size = 24;
            Type = PacketType.ISP_PIT;
        }

        public IS_PIT(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            LapsDone = BitConverter.ToUInt16(data, 4);
            Flags = (PlayerFlags)BitConverter.ToUInt16(data, 6);
            Sp0 = data[8];
            Penalty = (PenaltyValues)data[9];
            NumStops = data[10];
            Sp3 = data[11];
            Tyres = new TyreCompounds[]
            {
                (TyreCompounds)data[12],
                (TyreCompounds)data[13],
                (TyreCompounds)data[14],
                (TyreCompounds)data[15],
            };
            Work = (PitWorkFlags)BitConverter.ToUInt32(data, 16);
            Spare = BitConverter.ToUInt32(data, 20);
        }
    }
}
