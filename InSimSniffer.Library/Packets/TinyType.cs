
namespace InSimSniffer.Library.Packets {
    public enum TinyType {
        TINY_NONE,		//  0 - keep alive		: see "maintaining the connection"
        TINY_VER,		//  1 - info request	: get version
        TINY_CLOSE,		//  2 - instruction		: close insim
        TINY_PING,		//  3 - ping request	: external progam requesting a reply
        TINY_REPLY,		//  4 - ping reply		: reply to a ping request
        TINY_VTC,		//  5 - info			: vote cancelled
        TINY_SCP,		//  6 - info request	: send camera pos
        TINY_SST,		//  7 - info request	: send state info
        TINY_GTH,		//  8 - info request	: get time in hundredths (i.e. SMALL_RTP)
        TINY_MPE,		//  9 - info			: multi player end
        TINY_ISM,		// 10 - info request	: get multiplayer info (i.e. ISP_ISM)
        TINY_REN,		// 11 - info			: race end (return to game setup screen)
        TINY_CLR,		// 12 - info			: all players cleared from race
        TINY_NCN,		// 13 - info request	: get all connections
        TINY_NPL,		// 14 - info request	: get all players
        TINY_RES,		// 15 - info request	: get all results
        TINY_NLP,		// 16 - info request	: send an IS_NLP
        TINY_MCI,		// 17 - info request	: send an IS_MCI
        TINY_REO,		// 18 - info request	: send an IS_REO
        TINY_RST,		// 19 - info request	: send an IS_RST
        TINY_AXI,		// 20 - info request	: send an IS_AXI - AutoX Info
        TINY_AXC,		// 21 - info			: autocross cleared
        TINY_RIP,		// 22 - info request	: send an IS_RIP - Replay Information Packet
    }
}
