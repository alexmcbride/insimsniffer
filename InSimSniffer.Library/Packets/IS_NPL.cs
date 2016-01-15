using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum PlayerFlags {
        PIF_SWAPSIDE = 1,
        PIF_RESERVED_2 = 2,
        PIF_RESERVED_4 = 4,
        PIF_AUTOGEARS = 8,
        PIF_SHIFTER = 16,
        PIF_RESERVED_32 = 32,
        PIF_HELP_B = 64,
        PIF_AXIS_CLUTCH = 128,
        PIF_INPITS = 256,
        PIF_AUTOCLUTCH = 512,
        PIF_MOUSE = 1024,
        PIF_KB_NO_HELP = 2048,
        PIF_KB_STABILISED = 4096,
        PIF_CUSTOM_VIEW = 8192,
    }

    [Flags]
    internal enum PlayerTypes {
        None = 0,
        Female = 1,
        AI = 2,
        Remote = 4,
    }

    internal enum TyreCompounds {
        TYRE_R1,			// 0
        TYRE_R2,			// 1
        TYRE_R3,			// 2
        TYRE_R4,			// 3
        TYRE_ROAD_SUPER,	// 4
        TYRE_ROAD_NORMAL,	// 5
        TYRE_HYBRID,		// 6
        TYRE_KNOBBLY,		// 7
        TYRE_NUM,
        TYRE_NONE = 255,
    }

    [Flags]
    internal enum SetupFlags {
        SETF_NONE = 0,
        SETF_SYMM_WHEELS = 1,
        SETF_TC_ENABLE = 2,
        SETF_ABS_ENABLE = 4,
    }

    [Flags]
    internal enum PassengerFlags {
        None = 0,
        FemaleFront = 1,
        Front = 2,
        FemaleRearLeft = 4,
        RearLeft = 8,
        FemaleMiddle = 16,
        RearMiddle = 32,
        FemaleRight = 64,
        RearRight = 128,
    }

    internal class IS_NPL : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public byte UCID { get; private set; }
        public byte PType { get; private set; }
        public PlayerFlags Flags { get; private set; }
        public string PName { get; private set; }
        public string Plate { get; private set; }
        public string CName { get; private set; }
        public string SName { get; private set; }
        public TyreCompounds[] Tyres { get; private set; }
        public byte H_Mass { get; private set; }
        public byte H_TRes { get; private set; }
        public byte Model { get; private set; }
        public PassengerFlags Pass { get; private set; }
        public int Spare { get; private set; }
        public SetupFlags SetF { get; private set; }
        public byte NumP { get; private set; }
        public byte Sp2 { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_NPL() {
            Size = 76;
            Type = PacketType.ISP_NPL;
        }

        public IS_NPL(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            UCID = data[4];

            PType = data[5];
            Flags = (PlayerFlags)BitConverter.ToUInt16(data, 6);
            PName = EncodingHelper.GetString(data, 8, 24);
            Plate = EncodingHelper.GetString(data, 32, 8);
            CName = EncodingHelper.GetString(data, 40, 4);
            SName = EncodingHelper.GetString(data, 44, 16);
            Tyres = new TyreCompounds[] 
            { 
                (TyreCompounds)data[60], 
                (TyreCompounds)data[61], 
                (TyreCompounds)data[62], 
                (TyreCompounds)data[63] 
            };
            H_Mass = data[64];
            H_TRes = data[65];
            Model = data[66];
            Pass = (PassengerFlags)data[67];
            Spare = BitConverter.ToInt32(data, 68);
            SetF = (SetupFlags)data[72];
            NumP = data[73];
            Sp2 = data[74];
            Sp3 = data[75];
        }
    }
}
