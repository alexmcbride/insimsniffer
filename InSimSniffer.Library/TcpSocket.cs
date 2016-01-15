using System;
using System.IO;
using System.Net.Sockets;

namespace InSimSniffer.Library {
    internal partial class TcpSocket : IDisposable {
        private const int BufferSize = 2048;
        private Socket socket;

        public event EventHandler<ErrorEventArgs> InSimError;
        public event EventHandler ConnectionLost;
        public event EventHandler SendCompleted;
        public event EventHandler<ReceiveCompletedEventArgs> ReceiveCompleted;

        public bool IsConnected {
            get { return socket.Connected; }
        }

        public TcpSocket() {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.NoDelay = true;
        }

        //public TcpSocket(Socket socket) {
        //    this.socket = socket;
        //    this.socket.NoDelay = true;

        //    HandleReceive();
        //}

        public void Connect(string host, int port) {
            socket.Connect(host, port);

            HandleReceive();
        }

        public void Close() {
            socket.Close();
        }

        public void Dispose() {
            socket.Dispose();
        }

        public void Send(byte[] buffer) {
            HandleSend(new SocketState(socket, buffer));
        }

        private void HandleSend(SocketState state) {
            state.Socket.BeginSend(state.Buffer, state.Offset, state.Buffer.Length - state.Offset, SocketFlags.None, HandleSend, state);
        }

        private void HandleSend(IAsyncResult asyncResult) {
            SocketState state = (SocketState)asyncResult.AsyncState;

            try {
                state.Offset += state.Socket.EndSend(asyncResult);
                if (state.Offset < state.Buffer.Length) {
                    HandleSend(state);
                }
            }
            catch (Exception ex) {
                state.Socket.Close();
                OnInSimError(new ErrorEventArgs(ex));
            }
        }

        private void HandleReceive() {
            HandleReceive(new SocketState(socket, new byte[BufferSize]));
        }

        private void HandleReceive(SocketState state) {
            state.Socket.BeginReceive(state.Buffer, state.Offset, state.Buffer.Length - state.Offset, SocketFlags.None, HandleReceive, state);
        }

        private void HandleReceive(IAsyncResult asyncResult) {
            SocketState state = (SocketState)asyncResult.AsyncState;

            if (IsConnected) {
                try {
                    int received = state.Socket.EndReceive(asyncResult);
                    if (received > 0) {
                        state.Offset += received;

                        HandlePackets(state);
                        HandleReceive(state);
                    }
                    else {
                        state.Socket.Close();
                        OnConnectionLost(EventArgs.Empty);
                    }
                }
                catch (Exception ex) {
                    state.Socket.Close();
                    OnInSimError(new ErrorEventArgs(ex));
                }
            }
        }

        private void HandlePackets(SocketState state) {
            int size = 0;
            int read = 0;

            while (state.Offset > 0 && state.Offset >= (size = state.Buffer[read])) {
                if (size % 4 > 0) {
                    throw new InvalidOperationException(StringResources.TcpSocketCorruptPacketExceptionMessage);
                }

                byte[] buffer = new byte[size];
                Buffer.BlockCopy(state.Buffer, read, buffer, 0, size);
                OnReceiveCompleted(new ReceiveCompletedEventArgs(buffer));

                read += size;
                state.Offset -= size;
            }

            if (state.Offset > 0) {
                Buffer.BlockCopy(state.Buffer, read, state.Buffer, 0, state.Buffer.Length - read);
            }
        }

        protected virtual void OnInSimError(ErrorEventArgs e) {
            EventHandler<ErrorEventArgs> temp = InSimError;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected virtual void OnConnectionLost(EventArgs e) {
            EventHandler temp = ConnectionLost;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected virtual void OnSendCompleted(EventArgs e) {
            EventHandler temp = SendCompleted;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected virtual void OnReceiveCompleted(ReceiveCompletedEventArgs e) {
            EventHandler<ReceiveCompletedEventArgs> temp = ReceiveCompleted;
            if (temp != null) {
                temp(this, e);
            }
        }
    }
}
