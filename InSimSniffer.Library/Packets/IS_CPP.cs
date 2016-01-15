using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_CPP : IPacket, ISendable {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; set; }
        public byte Zero { get; set; }
        public int Pos1 { get; set; }
        public int Pos2 { get; set; }
        public int Pos3 { get; set; }
        public ushort H { get; set; }
        public ushort P { get; set; }
        public ushort R { get; set; }
        public byte ViewPLID { get; set; }
        public CameraViews InGameCam { get; set; }
        public float FOV { get; set; }
        public ushort Time { get; set; }
        public StateFlags Flags { get; set; }

        public IS_CPP() {
            Size = 32;
            Type = PacketType.ISP_CPP;
        }

        public IS_CPP(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            Zero = data[3];
            Pos1 = BitConverter.ToInt32(data, 4);
            Pos2 = BitConverter.ToInt32(data, 8);
            Pos3 = BitConverter.ToInt32(data, 12);
            H = BitConverter.ToUInt16(data, 16);
            P = BitConverter.ToUInt16(data, 18);
            R = BitConverter.ToUInt16(data, 20);
            ViewPLID = data[22];
            InGameCam = (CameraViews)data[23];
            FOV = BitConverter.ToSingle(data, 24);
            Time = BitConverter.ToUInt16(data, 28);
            Flags = (StateFlags)BitConverter.ToUInt16(data, 30);
        }

        public byte[] GetBuffer() {
            byte[] data = new byte[32];
            data[0] = Size;
            data[1] = (byte)Type;
            data[2] = ReqI;
            data[3] = Zero;
            PacketHelper.GetBytes(data, 4, Pos1);
            PacketHelper.GetBytes(data, 8, Pos2);
            PacketHelper.GetBytes(data, 12, Pos3);
            PacketHelper.GetBytes(data, 16, H);
            PacketHelper.GetBytes(data, 18, P);
            PacketHelper.GetBytes(data, 20, R);
            data[22] = ViewPLID;
            data[23] = (byte)InGameCam;
            PacketHelper.GetBytes(data, 24, FOV);
            PacketHelper.GetBytes(data, 28, Time);
            PacketHelper.GetBytes(data, 30, (ushort)Flags);
            return data;
        }
    }
}
