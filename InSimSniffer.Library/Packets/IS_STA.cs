using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum StateFlags {
        ISS_GAME = 1,	// in game (or MPR)
        ISS_REPLAY = 2,	// in SPR
        ISS_PAUSED = 4,	// paused
        ISS_SHIFTU = 8,	// SHIFT+U mode
        ISS_16 = 16,		// HIGH view
        ISS_SHIFTU_FOLLOW = 32,	// following car
        ISS_SHIFTU_NO_OPT = 64,	// SHIFT+U buttons hidden
        ISS_SHOW_2D = 128,	// showing 2d display
        ISS_FRONT_END = 256,	// entry screen
        ISS_MULTI = 512,	// multiplayer mode
        ISS_MPSPEEDUP = 1024,	// multiplayer speedup option
        ISS_WINDOWED = 2048,	// LFS is running in a window
        ISS_SOUND_MUTE = 4096,	// sound is switched off
        ISS_VIEW_OVERRIDE = 8192,	// override user view
        ISS_VISIBLE = 16384,// InSim buttons visible
    }

    internal enum CameraViews {
        VIEW_FOLLOW,	// 0 - arcade
        VIEW_HELI,		// 1 - helicopter
        VIEW_CAM,		// 2 - tv camera
        VIEW_DRIVER,	// 3 - cockpit
        VIEW_CUSTOM,	// 4 - custom
        VIEW_MAX,
    }

    internal enum Winds {
        None = 0,
        Low = 1,
        High = 2
    }

    internal enum Weathers {
        Clear = 0,
        CloudySunsetDusk = 1,
        Overcast = 2
    }

    internal enum RaceInProgs {
        None = 0,
        Race = 1,
        Qualifying = 2
    }

    internal class IS_STA : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte Zero { get; private set; }
        public float ReplaySpeed { get; private set; }
        public StateFlags Flags { get; private set; }
        public CameraViews InGameCam { get; private set; }
        public byte ViewPLID { get; private set; }
        public byte NumP { get; private set; }
        public byte NumConns { get; private set; }
        public byte NumFinished { get; private set; }
        public byte RaceInProg { get; private set; }
        public byte QualMins { get; private set; }
        public byte RaceLaps { get; private set; }
        public byte Spare2 { get; private set; }
        public byte Spare3 { get; private set; }
        public string Track { get; private set; }
        public byte Weather { get; private set; }
        public byte Wind { get; private set; }

        public IS_STA() {
            Size = 28;
            Type = PacketType.ISP_STA;
        }

        public IS_STA(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            ReplaySpeed = BitConverter.ToSingle(data, 4);
            Flags = (StateFlags)BitConverter.ToUInt16(data, 8);
            InGameCam = (CameraViews)data[10];
            ViewPLID = data[11];
            NumP = data[12];
            NumConns = data[13];
            NumFinished = data[14];
            RaceInProg = data[15];
            QualMins = data[16];
            RaceLaps = data[17];
            Spare2 = data[18];
            Spare3 = data[19];
            Track = EncodingHelper.GetString(data, 20, 6);
            Weather = data[26];
            Wind = data[27];
        }
    }
}
