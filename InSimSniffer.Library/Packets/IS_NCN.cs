using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum ConnectionFlags {
        Remote = 2,
    }

    internal class IS_NCN : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte UCID { get; private set; }
        public string UName { get; private set; }
        public string PName { get; private set; }
        public byte Admin { get; private set; }
        public byte Total { get; private set; }
        public ConnectionFlags Flags { get; private set; }
        public byte Sp3 { get; private set; }

        public IS_NCN() {
            Size = 56;
            Type = PacketType.ISP_NCN;
        }

        public IS_NCN(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            UCID = data[3];
            UName = EncodingHelper.GetString(data, 4, 24);
            PName = EncodingHelper.GetString(data, 28, 24);
            Admin = data[52];
            Total = data[53];
            Flags = (ConnectionFlags)data[54];
            Sp3 = data[55];
        }
    }
}
