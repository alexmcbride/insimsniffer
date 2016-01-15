using System;

namespace InSimSniffer.Library.Packets {
    internal interface IPacket {
        byte Size { get; }
        PacketType Type { get; }
        byte ReqI { get; }
    }
}
