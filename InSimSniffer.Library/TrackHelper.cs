using System;
using System.Collections.Generic;

namespace InSimSniffer.Library {
    internal static class TrackHelper {
        private static readonly Dictionary<string, string> tracks = new Dictionary<string, string>()
        {
            { "BL1", "Blackwood Grand Prix" },
            { "BL2", "Blackwood Rallycross" },
            { "BL3", "Blackwood Car Park" },
            { "SO1", "South City Classic" },
            { "SO2", "South City Sprint 1" },
            { "SO3", "South City Sprint 2" },
            { "SO4", "South City Long" },
            { "SO5", "South City Town" },
            { "SO6", "South City Chicane" },
            { "FE1", "Fern Bay Club" },
            { "FE2", "Fern Bay Green" },
            { "FE3", "Fern Bay Gold" },
            { "FE4", "Fern Bay Black" },
            { "FE5", "Fern Bay Rallycross" },
            { "FE6", "Fern Bay RallyX Green" },
            { "AU1", "Autocross" },
            { "AU2", "Skid Pad" },
            { "AU3", "Drag Strip" },
            { "AU4", "Eight Lane Drag" },
            { "KY1", "Kyoto Ring Oval" },
            { "KY2", "Kyoto Ring National" },
            { "KY3", "Kyoto Ring Grand Prix" },
            { "WE1", "Westhill International" },
            { "AS1", "Aston Cadet" },
            { "AS2", "Aston Club" },
            { "AS3", "Aston National" },
            { "AS4", "Aston Historic" },
            { "AS5", "Aston Grand Prix" },
            { "AS6", "Aston Grand Touring" },
            { "AS7", "Aston North" },
            { "BLX", "Blackwood Open Config" },
            { "SOX", "South City Open Config" },
            { "FEX", "Fern Bay Open Config" },
            { "AUX", "Autocross Open Config" },
            { "KYX", "Kyoto Ring Open Config" },
            { "WEX", "Westhill Open Config" },
            { "ASX", "Aston Open Config" },
        };

        public static string GetFullTrackName(string shortTrackName) {
            if (shortTrackName.Length > 3) {
                if (shortTrackName.EndsWith("R", StringComparison.OrdinalIgnoreCase)) {
                    return String.Format("{0} Reversed", tracks[shortTrackName.Substring(0, 3)]);
                }

                if (shortTrackName.EndsWith("X", StringComparison.OrdinalIgnoreCase) ||
                    shortTrackName.EndsWith("Y", StringComparison.OrdinalIgnoreCase)) {
                    return String.Format("{0} Open", tracks[shortTrackName.Substring(0, 3)]);
                }
            }

            return tracks[shortTrackName];
        }
    }
}
