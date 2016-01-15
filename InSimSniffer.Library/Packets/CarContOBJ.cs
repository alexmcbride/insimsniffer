using System;

namespace InSimSniffer.Library.Packets {
    internal class CarContOBJ {
        public byte Direction { get; private set; }	// car's motion if Speed > 0 : 0 = world y direction, 128 = 180 deg
        public byte Heading { get; private set; }	// direction of forward axis : 0 = world y direction, 128 = 180 deg
        public byte Speed { get; private set; }		// m/s
        public byte Sp3 { get; private set; }
        public short X { get; private set; }			// position (1 metre = 16)
        public short Y { get; private set; }			// position (1 metre = 16)

        public CarContOBJ(byte[] data, int index) {
            Direction = data[index + 0];
            Heading = data[index + 1];
            Speed = data[index + 2];
            Sp3 = data[index + 3];
            X = BitConverter.ToInt16(data, index + 4);
            Y = BitConverter.ToInt16(data, index + 6);
        }
    }
}
