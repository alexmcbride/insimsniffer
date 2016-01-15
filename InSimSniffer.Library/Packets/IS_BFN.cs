namespace InSimSniffer.Library.Packets {
    internal enum ButtonFunctions {
        BFN_DEL_BTN,		//  0 - instruction     : delete one button (must set ClickID)
        BFN_CLEAR,			//  1 - instruction		: clear all buttons made by this insim instance
        BFN_USER_CLEAR,		//  2 - info            : user cleared this insim instance's buttons
        BFN_REQUEST,		//  3 - user request    : SHIFT+B or SHIFT+I - request for buttons
    }

    internal class IS_BFN : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public ButtonFunctions SubT { get; set; }
        public byte UCID { get; set; }
        public byte ClickID { get; set; }
        public byte Inst { get; set; }
        public byte Sp3 { get; set; }

        public IS_BFN() {
            Size = 8;
            Type = PacketType.ISP_BFN;
        }

        public IS_BFN(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            SubT = (ButtonFunctions)data[3];
            UCID = data[4];
            ClickID = data[5];
            Inst = data[6];
            Sp3 = data[7];
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[8];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = (byte)SubT;
            data[4] = UCID;
            data[5] = ClickID;
            data[6] = Inst;
            data[7] = Sp3;
            return data;
        }
    }
}
