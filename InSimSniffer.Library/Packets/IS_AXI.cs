using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_AXI : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public byte Zero { get; set; }
        public byte AXStart { get; set; }
        public byte NumCP { get; set; }
        public ushort NumO { get; set; }
        public string LName { get; set; }

        public IS_AXI() {
            Size = 40;
            Type = PacketType.ISP_AXI;
            LName = string.Empty;
        }

        public IS_AXI(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            AXStart = data[4];
            NumCP = data[5];
            NumO = BitConverter.ToUInt16(data, 6);
            LName = EncodingHelper.GetString(data, 8, 8);
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[40];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = Zero;
            data[4] = AXStart;
            data[5] = NumCP;
            PacketHelper.GetBytes(data, 6, NumO);
            PacketHelper.GetBytes(data, 8, LName, 32);
            return data;
        }
    }
}
