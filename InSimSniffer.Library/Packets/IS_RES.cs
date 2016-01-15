using System;

namespace InSimSniffer.Library.Packets {
    internal class IS_RES : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public string UName { get; private set; }
        public string PName { get; private set; }
        public string Plate { get; private set; }
        public string CName { get; private set; }
        public uint TTime { get; private set; }
        public uint BTime { get; private set; }
        public byte SpA { get; private set; }
        public byte NumStops { get; private set; }
        public ConfirmationFlags Confirm { get; private set; }
        public byte SpB { get; private set; }
        public ushort LapsDone { get; private set; }
        public PlayerFlags Flags { get; private set; }
        public byte ResultNum { get; private set; }
        public byte NumRes { get; private set; }
        public ushort PSeconds { get; private set; }

        public IS_RES() {
            Size = 84;
            Type = PacketType.ISP_RES;
        }

        public IS_RES(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            UName = EncodingHelper.GetString(data, 4, 24);
            PName = EncodingHelper.GetString(data, 28, 24);
            Plate = EncodingHelper.GetString(data, 52, 8);
            CName = EncodingHelper.GetString(data, 60, 4);
            TTime = BitConverter.ToUInt32(data, 64);
            BTime = BitConverter.ToUInt32(data, 68);
            SpA = data[72];
            NumStops = data[73];
            Confirm = (ConfirmationFlags)data[74];
            SpB = data[75];
            LapsDone = BitConverter.ToUInt16(data, 76);
            Flags = (PlayerFlags)BitConverter.ToUInt16(data, 78);
            ResultNum = data[80];
            NumRes = data[81];
            PSeconds = BitConverter.ToUInt16(data, 82);
        }
    }
}
