using System.Collections.Generic;
using System.Collections.ObjectModel;
using InSimSniffer.Library.Packets;

namespace InSimSniffer.Library {
    public static class PacketTypeHelper {
        private static List<TinyType> requestableTinyTypes = new List<TinyType>
        {
            TinyType.TINY_VER,
            TinyType.TINY_PING,
            TinyType.TINY_SCP,
            TinyType.TINY_SST,
            TinyType.TINY_GTH,
            TinyType.TINY_ISM,
            TinyType.TINY_NCN,
            TinyType.TINY_NPL,
            TinyType.TINY_RES,
            TinyType.TINY_NLP,
            TinyType.TINY_MCI,
            TinyType.TINY_REO,
            TinyType.TINY_RST,
            TinyType.TINY_AXI,
            TinyType.TINY_RIP,
        };

        public static ReadOnlyCollection<TinyType> RequestableTinyTypes {
            get {
                return new ReadOnlyCollection<TinyType>(requestableTinyTypes);
            }
        }

        private static readonly List<SmallType> requestableSmallTypes = new List<SmallType>
        {
            SmallType.SMALL_SSP,
            SmallType.SMALL_SSG,
            SmallType.SMALL_TMS,
            SmallType.SMALL_STP,
            SmallType.SMALL_NLI,
        };

        public static ReadOnlyCollection<SmallType> RequestableSmallTypes {
            get {
                return new ReadOnlyCollection<SmallType>(requestableSmallTypes);
            }
        }

        private static readonly List<PacketType> receivablePacketTypes = new List<PacketType>()
        {
            PacketType.ISP_AXI, PacketType.ISP_AXO, PacketType.ISP_BFN, 
            PacketType.ISP_BTC, PacketType.ISP_BTT, PacketType.ISP_CCH, 
            PacketType.ISP_CNL, PacketType.ISP_CPP, PacketType.ISP_CPR, 
            PacketType.ISP_CRS, PacketType.ISP_FIN, PacketType.ISP_FLG, 
            PacketType.ISP_III, PacketType.ISP_ISM, PacketType.ISP_LAP,
            PacketType.ISP_MCI, PacketType.ISP_MSO, PacketType.ISP_NCN, 
            PacketType.ISP_NLP, PacketType.ISP_NPL, PacketType.ISP_PEN, 
            PacketType.ISP_PFL, PacketType.ISP_PIT, PacketType.ISP_PLA, 
            PacketType.ISP_PLL, PacketType.ISP_PLP, PacketType.ISP_PSF, 
            PacketType.ISP_REO, PacketType.ISP_RES, PacketType.ISP_RIP,
            PacketType.ISP_RST, PacketType.ISP_SMALL, PacketType.ISP_SPX,
            PacketType.ISP_SSH, PacketType.ISP_STA, PacketType.ISP_TINY, 
            PacketType.ISP_TOC, PacketType.ISP_VER, PacketType.ISP_VTN
        };

        public static ReadOnlyCollection<PacketType> ReceivablePacketTypes {
            get {
                return new ReadOnlyCollection<PacketType>(receivablePacketTypes);
            }
        }
    }
}
