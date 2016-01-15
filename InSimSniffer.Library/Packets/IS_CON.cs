using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_CON : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte Zero { get; private set; }

        public ushort SpClose { get; private set; }
        public ushort Time { get; private set; }

        public CarContact A { get; private set; }
        public CarContact B { get; private set; }

        internal IS_CON(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];

            SpClose = BitConverter.ToUInt16(data, 4);
            Time = BitConverter.ToUInt16(data, 6);

            A = new CarContact(data, 8);
            B = new CarContact(data, 24);
        }
    }
}
