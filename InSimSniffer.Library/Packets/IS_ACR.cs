using System.Text;
using System;

namespace InSimSniffer.Library.Packets {
    public class IS_ACR : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte Zero { get; private set; }
        public byte UCID { get; private set; }
        public byte Admin { get; private set; }
        public byte Result { get; private set; }
        public byte Sp3 { get; private set; }
        public string Text { get; private set; }

        public IS_ACR(byte[] data) {
            if (data == null) {
                throw new ArgumentNullException("data");
            }

            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            UCID = data[4];
            Admin = data[5];
            Result = data[6];
            Sp3 = data[7];
            Text = ASCIIEncoding.ASCII.GetString(data, 8, 64);
        }

    }
}
