using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;

namespace InSimSniffer.Library {
    internal static class StringHelper {
        private static readonly Regex ColoursRegex = new Regex(@"\^[0-9]");

        public static string StripColors(string str) {
            return ColoursRegex.Replace(str, string.Empty);
        }

        public static string TimeString(long value) {
            long hours = value / 3600000;
            long minutes = value / 60000 % 60;
            long seconds = value / 1000 % 60;
            long thousandths = value % 1000;

            if (hours > 0) {
                return String.Format(
                    "{0}:{1:00}:{2:00}.{3:000}",
                    hours,
                    minutes,
                    seconds,
                    thousandths);
            }
            return String.Format(
                "{0:}:{1:00}.{2:000}",
                minutes,
                seconds,
                thousandths);
        }
    }
}
