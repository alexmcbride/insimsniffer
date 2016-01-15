using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_REO : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public byte NumP { get; set; }
        public byte[] PLID { get; set; }

        public IS_REO() {
            Size = 36;
            Type = PacketType.ISP_REO;
            PLID = new byte[32];
        }

        public IS_REO(byte[] data)
            : this() {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            NumP = data[3];
            Buffer.BlockCopy(data, 4, PLID, 0, 32);
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[36];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = NumP;
            Buffer.BlockCopy(PLID, 0, data, 4, 32);
            return data;
        }
    }
}
