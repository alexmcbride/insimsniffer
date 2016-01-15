using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using InSimSniffer.Library.Packets;

namespace InSimSniffer.Library {
    internal class SnifferService {
        private Stopwatch elapsedTime;
        private Dictionary<int, IS_NCN> connections = new Dictionary<int, IS_NCN>(32);
        private Dictionary<int, IS_NPL> players = new Dictionary<int, IS_NPL>(32);
        private Dictionary<string, Func<object, string>> infoMap;

        public SnifferService() {
            infoMap = new Dictionary<string, Func<object, string>>()
            {
                { "PLID", LookupPlid },
                { "ViewPLID", LookupPlid },
                { "CarBehind", LookupPlid },
                { "UCID", LookupUcid },
                { "Time", LookupTime },
                { "LTime", LookupTime },
                { "ETime", LookupTime },
                { "STime", LookupTime },
                { "TTime", LookupTime },
                { "BTime", LookupTime },
                { "CTime", LookupTime },
                { "CName", LookupCar },
                { "Track", LookupTrack },
                { "RaceInProg", LookupRaceInProg },
                { "Wind", LookupWind },
                { "Weather", LookupWeather },
                { "Flag", LookupFlag },
                { "OffOn", LookupOffOn },
                { "Host", LookupHost },
                { "MPR", LookupMpr },
                { "Paused", LookupPaused },
                { "HLVC", LookupHlvc },
            };
        }

        public void AddConnection(IS_NCN packet) {
            connections[packet.UCID] = packet;
        }

        public void AddPlayer(IS_NPL packet) {
            players[packet.PLID] = packet;
        }

        public void RemoveConnection(IS_CNL packet) {
            connections.Remove(packet.UCID);
        }

        public void RemovePlayer(IS_PLL packet) {
            players.Remove(packet.PLID);
        }

        public SniffedPacket SniffPacket(IPacket packet) {
            IList<SniffedValue> values = SniffValues(packet);

            return new SniffedPacket(packet.Type.ToString(), elapsedTime.Elapsed, values);
        }

        private IList<SniffedValue> SniffValues(object packet) {
            List<SniffedValue> values = new List<SniffedValue>();

            int index = 0;
            PropertyInfo[] properties = packet.GetType().GetProperties();
            foreach (PropertyInfo property in properties) {
                string name = property.Name;
                object value = property.GetValue(packet, null);

                if (value.GetType().IsArray) {
                    Array array = (Array)value;
                    foreach (object item in array) {
                        if (IsArraySubPacket(item)) {
                            values.AddRange(SniffValues(item));
                        }
                        else {
                            values.Add(new SniffedValue(
                                index++,
                                name,
                                item.ToString(),
                                LookupInformation(name, item)));
                        }
                    }
                }
                else if (IsSubPacket(value)) {
                    values.AddRange(SniffValues(value));
                }
                else {
                    values.Add(new SniffedValue(
                        index++,
                        name,
                        value.ToString(),
                        LookupInformation(name, value)));
                }
            }

            return values;
        }

        private static bool IsSubPacket(object value) {
            return value is CarContact || value is CarContOBJ;
        }

        private static bool IsArraySubPacket(object value) {
            return value is NodeLap || value is CompCar || value is ObjectInfo;
        }

        public void ResetElapsedTime() {
            if (elapsedTime != null && elapsedTime.IsRunning) {
                elapsedTime.Stop();
            }

            elapsedTime = new Stopwatch();
            elapsedTime.Start();
        }

        private string LookupInformation(string name, object value) {
            Func<object, string> lookup;
            if (infoMap.TryGetValue(name, out lookup)) {
                return lookup(value);
            }
            return String.Empty;
        }

        private string LookupPlid(object value) {
            int plid = (byte)value;

            IS_NPL npl;
            if (players.TryGetValue(plid, out npl)) {
                return StringHelper.StripColors(npl.PName);
            }

            return String.Empty;
        }

        private string LookupUcid(object value) {
            int ucid = (byte)value;

            if (ucid == 0) {
                return StringResources.LookupUcidHost;
            }

            IS_NCN ncn;
            if (connections.TryGetValue(ucid, out ncn)) {
                return ncn.UName;
            }

            return String.Empty;
        }

        private string LookupTime(object value) {
            return value is ushort ?
                StringHelper.TimeString((ushort)value) :
                StringHelper.TimeString((uint)value);
        }

        private string LookupTrack(object value) {
            return TrackHelper.GetFullTrackName((string)value);
        }

        private string LookupCar(object value) {
            return CarHelper.GetFullCarName((string)value);
        }

        public string LookupRaceInProg(object value) {
            int raceInProg = (byte)value;

            if (raceInProg == 1) {
                return StringResources.LookupRaceInProgRace;
            }

            if (raceInProg == 2) {
                return StringResources.LookupRaceInProgQual;
            }

            return StringResources.LookupRaceInProgNone;
        }

        public string LookupWind(object value) {
            int wind = (byte)value;

            if (wind == 1) {
                return StringResources.LookupWindLow;
            }

            if (wind == 2) {
                return StringResources.LookupWindHigh;
            }

            return StringResources.LookupWindNone;
        }

        public string LookupWeather(object value) {
            int weather = (byte)value;

            if (weather == 1) {
                return StringResources.LookupWeatherSunset;
            }

            if (weather == 2) {
                return StringResources.LookupWeatherOvercast;
            }

            return StringResources.LookupWeatherClear;
        }

        public string LookupFlag(object value) {
            if (value is byte) {
                int flag = (byte)value;

                if (flag == 1) {
                    return StringResources.LookupFlagBlue;
                }

                if (flag == 2) {
                    return StringResources.LookupFlagYellow;
                }
            }
            return String.Empty;
        }

        public string LookupOffOn(object value) {
            if ((byte)value == 1) {
                return StringResources.LookupOffOnOn;
            }
            return StringResources.LookupOffOnOff;
        }

        private string LookupHost(object value) {
            if ((byte)value == 1) {
                return StringResources.LookupHostHost;
            }
            return StringResources.LookupHostGuest;

        }

        private string LookupMpr(object value) {
            if ((byte)value == 1) {
                return StringResources.LookupMprMpr;
            }
            return StringResources.LookupMprSpr;
        }

        private string LookupPaused(object value) {
            if ((byte)value == 1) {
                return StringResources.LookupPausedPaused;
            }
            return String.Empty;
        }

        private string LookupHlvc(object value) {
            byte v = (byte)value;
            if ((v & 0) > 0)
                return StringResources.LookupHlvcGround;
            if ((v & 1) > 0)
                return StringResources.LookupHlvcWall;
            if ((v & 4) > 0)
                return StringResources.LookupHlvcSpeeding;
            return StringResources.LookupHlvcNone;
        }
    }
}
