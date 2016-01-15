using System;

namespace InSimSniffer.Library {
    public class SniffedValue {
        public int Index { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }
        public string Information { get; private set; }

        public SniffedValue(int index, string name, string value)
            : this(index, name, value, String.Empty) { }

        public SniffedValue(int index, string name, string value, string information) {
            Index = index;
            Name = name;
            Value = value;
            Information = information;
        }

        public override string ToString() {
            return String.Format("{0} : {1}", Name, Value);
        }
    }
}
