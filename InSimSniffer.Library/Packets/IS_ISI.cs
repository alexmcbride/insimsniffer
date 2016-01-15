using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum IsiFlags {
        ISF_RES_0 = 1,	// bit 0 : spare
        ISF_RES_1 = 2,	// bit 1 : spare
        ISF_LOCAL = 4,// bit 2 : guest or single player
        ISF_MSO_COLS = 8,	// bit 3 : keep colours in MSO text
        ISF_NLP = 16,	// bit 4 : receive NLP packets
        ISF_MCI = 32,	// bit 5 : receive MCI packets
        ISF_CON = 64,   // bit  6 : receive CON packets
        ISF_OBH = 128,	// bit  7 : receive OBH packets
        ISF_HLV = 256,	// bit  8 : receive HLV packets
        ISF_AXM_LOAD = 512,	// bit  9 : receive AXM when loading a layout
        ISF_AXM_EDIT = 1024,	// bit 10 : receive AXM when changing objects
    }

    internal class IS_ISI : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public byte Zero { get; set; }
        public ushort UDPPort { get; set; }
        public IsiFlags Flags { get; set; }
        public byte Sp0 { get; set; }
        public char Prefix { get; set; }
        public ushort Interval { get; set; }
        public string Admin { get; set; }
        public string IName { get; set; }

        public IS_ISI() {
            Size = 44;
            Type = PacketType.ISP_ISI;
            Admin = string.Empty;
            IName = string.Empty;
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[Size];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = Zero;
            PacketHelper.GetBytes(data, 4, UDPPort);
            PacketHelper.GetBytes(data, 6, (ushort)Flags);
            data[8] = Sp0;
            data[9] = (byte)Prefix;
            PacketHelper.GetBytes(data, 10, Interval);
            PacketHelper.GetBytes(data, 12, Admin, 16);
            PacketHelper.GetBytes(data, 28, IName, 16);
            return data;
        }
    }
}
