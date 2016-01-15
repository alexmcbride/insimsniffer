
namespace InSimSniffer.Library {
    public enum SmallType// the fourth byte of an IS_TINY packet is one of these
    {
        SMALL_NONE,		//  0					: not used
        SMALL_SSP,		//  1 - instruction		: start sending positions
        SMALL_SSG,		//  2 - instruction		: start sending gauges
        SMALL_VTA,		//  3 - report			: vote action
        SMALL_TMS,		//  4 - instruction		: time stop
        SMALL_STP,		//  5 - instruction		: time step
        SMALL_RTP,		//  6 - info			: race time packet (reply to GTH)
        SMALL_NLI,		//  7 - instruction		: set node lap interval
    }
}
