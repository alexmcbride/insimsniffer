namespace InSimSniffer.Library.Packets {
    internal enum ScreenshotErrors {
        SSH_OK,				//  0 - OK : completed instruction
        SSH_DEDICATED,		//  1 - can't save a screenshot - dedicated host
        SSH_CORRUPTED,		//  2 - IS_SSH corrupted (e.g. BMP does not end with zero)
        SSH_NO_SAVE,		//  3 - could not save the screenshot
    }

    internal class IS_SSH : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public ScreenshotErrors Error { get; set; }
        public byte Sp0 { get; set; }
        public byte Sp1 { get; set; }
        public byte Sp2 { get; set; }
        public byte Sp3 { get; set; }
        public string BMP { get; set; }

        public IS_SSH() {
            Size = 40;
            Type = PacketType.ISP_SSH;
            BMP = string.Empty;
        }

        public IS_SSH(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Error = (ScreenshotErrors)data[3];
            Sp0 = data[4];
            Sp1 = data[5];
            Sp2 = data[6];
            Sp3 = data[7];
            BMP = EncodingHelper.GetString(data, 8, 32);
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[40];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = (byte)Error;
            data[4] = Sp0;
            data[5] = Sp1;
            data[6] = Sp2;
            data[7] = Sp3;
            PacketHelper.GetBytes(data, 8, BMP, 32);
            return data;
        }
    }
}
