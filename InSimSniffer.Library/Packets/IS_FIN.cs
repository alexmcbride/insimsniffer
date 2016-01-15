using System;

namespace InSimSniffer.Library.Packets {
    [Flags]
    internal enum ConfirmationFlags {
        CONF_MENTIONED = 1,
        CONF_CONFIRMED = 2,
        CONF_PENALTY_DT = 4,
        CONF_PENALTY_SG = 8,
        CONF_PENALTY_30 = 16,
        CONF_PENALTY_45 = 32,
        CONF_DID_NOT_PIT = 64,
        CONF_DISQ = (CONF_PENALTY_DT | CONF_PENALTY_SG | CONF_DID_NOT_PIT),
        CONF_TIME = (CONF_PENALTY_30 | CONF_PENALTY_45),
    }

    internal class IS_FIN : IPacket {
        public byte Size { get; private set; }
        public PacketType Type { get; private set; }
        public byte ReqI { get; private set; }
        public byte PLID { get; private set; }
        public uint TTime { get; private set; }
        public uint BTime { get; private set; }
        public byte SpA { get; private set; }
        public byte NumStops { get; private set; }
        public ConfirmationFlags Confirm { get; private set; }
        public byte SpB { get; private set; }
        public ushort LapsDone { get; private set; }
        public PlayerFlags Flags { get; private set; }

        public IS_FIN() {
            Size = 20;
            Type = PacketType.ISP_FIN;
        }

        public IS_FIN(byte[] data) {
            Size = data[0];
            Type = (PacketType)data[1];
            ReqI = data[2];
            PLID = data[3];
            TTime = BitConverter.ToUInt32(data, 4);
            BTime = BitConverter.ToUInt32(data, 8);
            SpA = data[12];
            NumStops = data[13];
            Confirm = (ConfirmationFlags)data[14];
            SpB = data[15];
            LapsDone = BitConverter.ToUInt16(data, 16);
            Flags = (PlayerFlags)BitConverter.ToUInt16(data, 18);
        }
    }
}
