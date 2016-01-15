using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_VER : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte Zero { get; private set; }
        public string Version { get; private set; }
        public string Product { get; private set; }
        public ushort InSimVer { get; private set; }

        public IS_VER(byte[] data)
            : base() {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            Version = EncodingHelper.GetString(data, 4, 8);
            Product = EncodingHelper.GetString(data, 12, 6);
            InSimVer = BitConverter.ToUInt16(data, 18);
        }
    }
}
