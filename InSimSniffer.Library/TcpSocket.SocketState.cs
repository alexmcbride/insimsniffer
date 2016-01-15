using System.Net.Sockets;
using System.Collections.Generic;

namespace InSimSniffer.Library {
    internal partial class TcpSocket {
        private class SocketState {
            public byte[] Buffer { get; private set; }
            public int Offset { get; set; }
            public Socket Socket { get; private set; }

            public SocketState(Socket socket, byte[] buffer) {
                Socket = socket;
                Buffer = buffer;
            }
        }
    }
}
