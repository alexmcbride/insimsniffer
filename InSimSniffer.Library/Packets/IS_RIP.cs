using System;

namespace InSimSniffer.Library.Packets {
    internal enum ReplayErrors {
        RIP_OK,				//  0 - OK : completed instruction
        RIP_ALREADY,		//  1 - OK : already at the destination
        RIP_DEDICATED,		//  2 - can't run a replay - dedicated host
        RIP_WRONG_MODE,		//  3 - can't start a replay - not in a suitable mode
        RIP_NOT_REPLAY,		//  4 - RName is zero but no replay is currently loaded
        RIP_CORRUPTED,		//  5 - IS_RIP corrupted (e.g. RName does not end with zero)
        RIP_NOT_FOUND,		//  6 - the replay file was not found
        RIP_UNLOADABLE,		//  7 - obsolete / future / corrupted
        RIP_DEST_OOB,		//  8 - destination is beyond replay length
        RIP_UNKNOWN,		//  9 - unknown error found starting replay
        RIP_USER,			// 10 - replay search was terminated by user
        RIP_OOS,			// 11 - can't reach destination - SPR is out of sync
    }

    internal enum ReplayTypes {
        Spr,
        Mpr
    }

    [Flags]
    internal enum ReplayOptions {
        RIPOPT_LOOP = 1,	// replay will loop if this bit is set
        RIPOPT_SKINS = 2,		// set this bit to download missing skins
    }

    internal class IS_RIP : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public ReplayErrors Error { get; set; }
        public byte MPR { get; set; }
        public byte Paused { get; set; }
        public ReplayOptions Options { get; set; }
        public byte Sp3 { get; set; }
        public uint CTime { get; set; }
        public uint TTime { get; set; }
        public string RName { get; set; }

        public IS_RIP() {
            Size = 80;
            Type = PacketType.ISP_RIP;
            RName = string.Empty;
        }

        public IS_RIP(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Error = (ReplayErrors)data[3];
            MPR = data[4];
            Paused = data[5];
            Options = (ReplayOptions)data[6];
            Sp3 = data[7];
            CTime = BitConverter.ToUInt32(data, 8);
            TTime = BitConverter.ToUInt32(data, 12);
            RName = EncodingHelper.GetString(data, 16, 64);
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[76];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = (byte)Error;
            data[4] = MPR;
            data[5] = Paused;
            data[6] = (byte)Options;
            data[7] = Sp3;
            PacketHelper.GetBytes(data, 8, CTime);
            PacketHelper.GetBytes(data, 10, TTime);
            PacketHelper.GetBytes(data, 12, RName, 64);
            return data;
        }
    }
}
