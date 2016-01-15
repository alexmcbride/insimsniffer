using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_SMALL : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public SmallType SubT { get; set; }
        public uint UVal { get; set; }

        public IS_SMALL() {
            Size = 8;
            Type = PacketType.ISP_SMALL;
        }

        public IS_SMALL(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            SubT = (SmallType)data[3];
            UVal = BitConverter.ToUInt32(data, 4);
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[8];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = (byte)SubT;
            PacketHelper.GetBytes(data, 4, UVal);
            return data;
        }
    }

}
