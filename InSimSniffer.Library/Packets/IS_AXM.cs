
namespace InSimSniffer.Library.Packets {
    internal enum PMOActions {
        PMO_LOADING_FILE,	// 0 - sent by the layout loading system only
        PMO_ADD_OBJECTS,	// 1 - adding objects (from InSim or editor)
        PMO_DEL_OBJECTS,	// 2 - delete objects (from InSim or editor)
        PMO_CLEAR_ALL,		// 3 - clear all objects (NumO must be zero)
        PMO_NUM
    }

    internal class IS_AXM : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte NumO { get; private set; }
        public byte UCID { get; private set; }
        public PMOActions PMOAction { get; private set; }
        public byte PMOFlags { get; private set; }
        public byte Sp3 { get; private set; }

        public ObjectInfo[] Info { get; private set; }

        public IS_AXM() {
            Size = 8;
            Type = PacketType.ISP_AXM;
        }

        public IS_AXM(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            NumO = data[3];
            UCID = data[4];
            PMOAction = (PMOActions)data[5];
            PMOFlags = data[6];
            Sp3 = data[7];

            Info = new ObjectInfo[NumO];
            for (int i = 0, j = 8; i < NumO; i++, j += 8) {
                Info[i] = new ObjectInfo(data, j);
            }
        }
    }
}
