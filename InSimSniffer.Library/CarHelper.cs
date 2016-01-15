using System.Collections.Generic;

namespace InSimSniffer.Library {
    internal static class CarHelper {
        private static readonly Dictionary<string, string> cars = new Dictionary<string, string>()
        {
            { "XFG", "XF GTI" },
            { "XRG", "XR GT" },
            { "FBM", "Formula BMW" },
            { "XRT", "XR GT Turbo" },
            { "RB4", "RB4 GT" },
            { "FXO", "FXO Turbo" },
            { "LX4", "LX4" },
            { "LX6", "LX6" },
            { "MRT", "MRT5" },
            { "UF1", "UF 1000" },
            { "RAC", "RaceAbout" },
            { "FZ5", "FZ50" },
            { "XFR", "XF GTR" },
            { "UFR", "UF GTR" },
            { "FOX", "Formula XR" },
            { "FO8", "Formula V8" },
            { "BF1", "BMW Sauber F1" },
            { "FXR", "FXO GTR" },
            { "XRR", "XR GTR" },
            { "FZR", "FZ50 GTR" },
            { "VWS", "VW Scirocco" },
        };

        public static string GetFullCarName(string shortCarName) {
            return cars[shortCarName];
        }

        public static string[] GetAllCars() {
            List<string> items = new List<string>();
            foreach (KeyValuePair<string, string> car in cars) {
                items.Add(car.Value);
            }
            return items.ToArray();
        }
    }
}
