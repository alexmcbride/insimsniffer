using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using InSimSniffer.Library.Packets;

namespace InSimSniffer.Library {
    internal static class PacketFactory {
        public static IPacket Build(byte[] buffer) {
            PacketType type = (PacketType)buffer[1];

            switch (type) {
                case PacketType.ISP_AXI:
                    return new IS_AXI(buffer);
                case PacketType.ISP_AXO:
                    return new IS_AXO(buffer);
                case PacketType.ISP_BFN:
                    return new IS_BFN(buffer);
                case PacketType.ISP_BTT:
                    return new IS_BTT(buffer);
                case PacketType.ISP_CCH:
                    return new IS_CCH(buffer);
                case PacketType.ISP_CNL:
                    return new IS_CNL(buffer);
                case PacketType.ISP_CPP:
                    return new IS_CPP(buffer);
                case PacketType.ISP_CPR:
                    return new IS_CPR(buffer);
                case PacketType.ISP_CRS:
                    return new IS_CRS(buffer);
                case PacketType.ISP_FIN:
                    return new IS_FIN(buffer);
                case PacketType.ISP_FLG:
                    return new IS_FLG(buffer);
                case PacketType.ISP_III:
                    return new IS_III(buffer);
                case PacketType.ISP_ISM:
                    return new IS_ISM(buffer);
                case PacketType.ISP_LAP:
                    return new IS_LAP(buffer);
                case PacketType.ISP_MCI:
                    return new IS_MCI(buffer);
                case PacketType.ISP_MSL:
                    return new IS_MSL(buffer);
                case PacketType.ISP_MSO:
                    return new IS_MSO(buffer);
                case PacketType.ISP_MSX:
                    return new IS_MSX(buffer);
                case PacketType.ISP_NCN:
                    return new IS_NCN(buffer);
                case PacketType.ISP_NLP:
                    return new IS_NLP(buffer);
                case PacketType.ISP_NPL:
                    return new IS_NPL(buffer);
                case PacketType.ISP_PEN:
                    return new IS_PEN(buffer);
                case PacketType.ISP_PFL:
                    return new IS_PFL(buffer);
                case PacketType.ISP_PIT:
                    return new IS_PIT(buffer);
                case PacketType.ISP_PLA:
                    return new IS_PLA(buffer);
                case PacketType.ISP_PLL:
                    return new IS_PLL(buffer);
                case PacketType.ISP_PLP:
                    return new IS_PLP(buffer);
                case PacketType.ISP_PSF:
                    return new IS_PSF(buffer);
                case PacketType.ISP_REO:
                    return new IS_REO(buffer);
                case PacketType.ISP_RES:
                    return new IS_RES(buffer);
                case PacketType.ISP_RIP:
                    return new IS_RIP(buffer);
                case PacketType.ISP_RST:
                    return new IS_RST(buffer);
                case PacketType.ISP_SCC:
                    return new IS_SCC(buffer);
                case PacketType.ISP_SMALL:
                    return new IS_SMALL(buffer);
                case PacketType.ISP_SPX:
                    return new IS_SPX(buffer);
                case PacketType.ISP_SSH:
                    return new IS_SSH(buffer);
                case PacketType.ISP_STA:
                    return new IS_STA(buffer);
                case PacketType.ISP_TINY:
                    return new IS_TINY(buffer);
                case PacketType.ISP_TOC:
                    return new IS_TOC(buffer);
                case PacketType.ISP_VER:
                    return new IS_VER(buffer);
                case PacketType.ISP_VTN:
                    return new IS_VTN(buffer);
                case PacketType.ISP_CON:
                    return new IS_CON(buffer);
                case PacketType.ISP_OBH:
                    return new IS_OBH(buffer);
                case PacketType.ISP_HLV:
                    return new IS_HLV(buffer);
                case PacketType.ISP_AXM:
                    return new IS_AXM(buffer);
                case PacketType.ISP_ACR:
                    return new IS_ACR(buffer);
                default:
                    return null;
            }
        }
    }
}
