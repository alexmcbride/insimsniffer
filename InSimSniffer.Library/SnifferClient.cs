using System;
using System.IO;
using InSimSniffer.Library.Packets;
using System.Net.Sockets;

namespace InSimSniffer.Library {
    public class SnifferClient : IDisposable {
        private const byte RequestId = 255;
        private const byte ReservedId = 254;

        private TcpSocket socket;
        private bool isPaused;
        private SnifferService snifferService = new SnifferService();

        public event EventHandler<ErrorEventArgs> InSimError;
        public event EventHandler<InSimCloseEventArgs> ConnectionClosed;
        public event EventHandler HostChanged;
        public event EventHandler<PacketEventArgs> PacketSniffed;
        public event EventHandler PauseChanged;

        public string HostName { get; private set; }
        public SnifferSettings Settings { get; private set; }

        public bool IsHostConnected {
            get { return !String.IsNullOrEmpty(HostName); }
        }

        public bool IsPaused {
            get { return isPaused; }
            set {
                if (isPaused != value) {
                    isPaused = value;
                    OnPauseChanged(EventArgs.Empty);
                }
            }
        }

        public bool IsConnected {
            get { return socket == null ? false : socket.IsConnected; }
        }

        public SnifferClient() { }

        private void InitializeTcpSocket() {
            if (socket != null) {
                socket.InSimError -= OnTcpSocketInSimError;
                socket.ReceiveCompleted -= OnTcpSocketReceiveCompleted;
                socket.ConnectionLost -= OnTcpSocketConnectionLost;
            }

            socket = new TcpSocket();
            socket.InSimError += OnTcpSocketInSimError;
            socket.ReceiveCompleted += OnTcpSocketReceiveCompleted;
            socket.ConnectionLost += OnTcpSocketConnectionLost;
        }

        public void Dispose() {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing && socket != null) {
                socket.Dispose();
            }
        }

        public void Clear() {
            snifferService.ResetElapsedTime();
        }

        public void Disconnect() {
            if (IsConnected) {
                socket.Close();
                IsPaused = false;

                OnConnectionClosed(new InSimCloseEventArgs(InSimCloseReason.Close));
            }
        }

        private void HandleSend(ISendable packet) {
            if (socket.IsConnected) {
                socket.Send(packet.GetBuffer());
            }
        }

        public void Initialize(SnifferSettings settings) {
            if (settings == null) {
                throw new ArgumentNullException("settings");
            }

            Settings = settings;

            InitializeTcpSocket();

            socket.Connect(settings.Host, settings.Port);

            snifferService.ResetElapsedTime();

            HandleSend(new IS_ISI {
                ReqI = RequestId,
                Admin = Settings.Admin,
                IName = Settings.Name,
                Interval = (ushort)Settings.Interval,
                Flags = GetInitFlags(),
            });
        }

        private IsiFlags GetInitFlags() {
            IsiFlags flags = 0;

            flags |= Settings.EnableMci ? IsiFlags.ISF_MCI : 0;
            flags |= Settings.EnableNlp ? IsiFlags.ISF_NLP : 0;
            flags |= Settings.EnableCon ? IsiFlags.ISF_CON : 0;
            flags |= Settings.EnableHlv ? IsiFlags.ISF_HLV : 0;
            flags |= Settings.EnableObh ? IsiFlags.ISF_OBH : 0;
            flags |= Settings.EnableAxmEdit ? IsiFlags.ISF_AXM_EDIT : 0;
            flags |= Settings.EnableAxmLoad ? IsiFlags.ISF_AXM_LOAD : 0;

            return flags;
        }

        private void OnTcpSocketInSimError(object sender, ErrorEventArgs e) {
            OnInSimError(e);
            IsPaused = false;
        }

        private void OnTcpSocketReceiveCompleted(object sender, ReceiveCompletedEventArgs e) {
            HandlePacket(e.Data);
        }

        private void OnTcpSocketConnectionLost(object sender, EventArgs e) {
            OnConnectionClosed(new InSimCloseEventArgs(InSimCloseReason.Lost));
            IsPaused = false;
        }

        private void HandlePacket(byte[] buffer) {
            IPacket packet = PacketFactory.Build(buffer);
            if (packet == null) return;

            switch (packet.Type) {
                case PacketType.ISP_ISM:
                    HandleInSimMultiplayer((IS_ISM)packet);
                    break;
                case PacketType.ISP_TINY:
                    HandleTiny((IS_TINY)packet);
                    break;
                case PacketType.ISP_NCN:
                    snifferService.AddConnection((IS_NCN)packet);
                    break;
                case PacketType.ISP_NPL:
                    snifferService.AddPlayer((IS_NPL)packet);
                    break;
                case PacketType.ISP_STA:
                    HandleState((IS_STA)packet);
                    break;
            }

            if (packet.ReqI != ReservedId && !IsPaused) {
                SniffedPacket sniffedPacket = snifferService.SniffPacket(packet);
                OnPacketSniffed(new PacketEventArgs(sniffedPacket));
            }

            switch (packet.Type) {
                case PacketType.ISP_CNL:
                    snifferService.RemoveConnection((IS_CNL)packet);
                    break;
                case PacketType.ISP_PLL:
                    snifferService.RemovePlayer((IS_PLL)packet);
                    break;
            }
        }

        private void HandleInSimMultiplayer(IS_ISM packet) {
            if (!String.IsNullOrEmpty(packet.HName)) {
                HostName = StringHelper.StripColors(packet.HName);
                OnHostChanged(EventArgs.Empty);
            }

            // Request players/connections.
            HandleSend(new IS_TINY { ReqI = ReservedId, SubT = TinyType.TINY_NCN });
            HandleSend(new IS_TINY { ReqI = ReservedId, SubT = TinyType.TINY_NPL });
        }

        private void HandleTiny(IS_TINY packet) {
            switch (packet.SubT) {
                case TinyType.TINY_MPE:
                    if (!String.IsNullOrEmpty(HostName)) {
                        HostName = null;
                        OnHostChanged(EventArgs.Empty);
                    }
                    break;
                case TinyType.TINY_NONE:
                    // Keep alive.
                    socket.Send(packet.GetBuffer());
                    break;
            }
        }

        private void HandleState(IS_STA sta) {
            // If singleplayer replay request players. Multiplayer replay gets handled by ISM.
            if (sta.Flags.HasFlag(StateFlags.ISS_REPLAY)) {
                // Request players.
                HandleSend(new IS_TINY { ReqI = ReservedId, SubT = TinyType.TINY_NPL });
            }
        }

        public void Request(TinyType tinyType) {
            HandleSend(new IS_TINY { ReqI = RequestId, SubT = tinyType });
        }

        public void Request(SmallType smallType, long uval) {
            HandleSend(new IS_SMALL { ReqI = RequestId, SubT = smallType, UVal = (uint)uval });
        }

        protected virtual void OnConnectionClosed(InSimCloseEventArgs e) {
            EventHandler<InSimCloseEventArgs> temp = ConnectionClosed;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected virtual void OnInSimError(ErrorEventArgs e) {
            EventHandler<ErrorEventArgs> temp = InSimError;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected virtual void OnHostChanged(EventArgs e) {
            EventHandler temp = HostChanged;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected virtual void OnPacketSniffed(PacketEventArgs e) {
            EventHandler<PacketEventArgs> temp = PacketSniffed;
            if (temp != null) {
                temp(this, e);
            }
        }

        protected virtual void OnPauseChanged(EventArgs e) {
            EventHandler temp = PauseChanged;
            if (temp != null) {
                temp(this, e);
            }
        }
    }
}
