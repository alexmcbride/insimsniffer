using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using InSimSniffer.Library.Packets;

namespace InSimSniffer.Library {
    public class SniffedPacket {
        public string PacketType { get; private set; }
        public TimeSpan ElapsedTime { get; private set; }
        public ReadOnlyCollection<SniffedValue> Values { get; private set; }

        public SniffedPacket(string packetType, TimeSpan elapsed, IList<SniffedValue> values) {
            PacketType = packetType;
            ElapsedTime = elapsed;
            Values = new ReadOnlyCollection<SniffedValue>(values);
        }

        public override string ToString() {
            return String.Format("{0} : {1}", PacketType, ElapsedTime);
        }
    }
}
