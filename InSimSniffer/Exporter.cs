using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using InSimSniffer.Library;

namespace InSimSniffer {
    public static class Exporter {
        private const int XmlVersion = 2;
        private const string BinaryHeader = "ISSBSF";
        private const int BinaryVersion = 1;

        public static string CreateExportFileName() {
            const string DateTimeFormat = "ddMMyyyy HHmm";

            return String.Format(StringResources.ExportFileName, DateTime.Now.ToString(DateTimeFormat));
        }

        public static void Export(string path, IEnumerable<SniffedPacket> packets) {
            string ext = Path.GetExtension(path);

            switch (ext) {
                case ".xml":
                    ExportXml(path, packets);
                    break;
                case ".txt":
                    ExportTxt(path, packets);
                    break;
                case ".sniffer":
                    ExportBinary(path, packets);
                    break;
                default:
                    throw new ExportException(String.Format(StringResources.ExportExtensionNotSupportedMessage, ext));
            }
        }

        public static void ExportXml(string path, IEnumerable<SniffedPacket> packets) {
            if (packets == null) {
                throw new ArgumentNullException("packets");
            }

            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", Encoding.UTF8.HeaderName, String.Empty));
            XElement xPackets = new XElement(
                "Packets",
                new XAttribute("Version", XmlVersion));

            foreach (SniffedPacket packet in packets) {
                XElement xPacket = new XElement("Packet");
                xPacket.Add(new XAttribute("Elapsed", packet.ElapsedTime.TotalMilliseconds));

                foreach (SniffedValue value in packet.Values) {
                    xPacket.Add(new XElement(value.Name, value.Value));
                }

                xPackets.Add(xPacket);
            }

            xDoc.Add(xPackets);
            xDoc.Save(path);
        }

        public static void ExportTxt(string path, IEnumerable<SniffedPacket> packets) {
            if (packets == null) {
                throw new ArgumentNullException("packets");
            }

            using (StreamWriter writer = new StreamWriter(path)) {
                foreach (SniffedPacket packet in packets) {
                    string[] values = new string[packet.Values.Count];
                    for (int i = 0; i < values.Length; i++) {
                        values[i] = packet.Values[i].ToString();
                    }
                    writer.WriteLine("{0} - {1}", packet.ElapsedTime, String.Join(", ", values));
                }
            }
        }

        public static void ExportBinary(string path, IEnumerable<SniffedPacket> packets) {
            using (Stream stream = File.Open(path, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(stream)) {
                writer.Write(ASCIIEncoding.ASCII.GetBytes(BinaryHeader));
                writer.Write(BinaryVersion);
                writer.Write(packets.Count());

                foreach (SniffedPacket packet in packets) {
                    writer.Write(packet.PacketType);
                    writer.Write(packet.ElapsedTime.TotalMilliseconds);
                    writer.Write(packet.Values.Count);

                    foreach (SniffedValue value in packet.Values) {
                        writer.Write(value.Index);
                        writer.Write(value.Name);
                        writer.Write(value.Value);
                        writer.Write(value.Information);
                    }
                }
            }
        }

        public static IEnumerable<SniffedPacket> Import(string path) {
            string ext = Path.GetExtension(path);

            switch (ext) {
                case ".sniffer":
                    return ImportBinary(path);
                default:
                    throw new ExportException(String.Format(StringResources.ExportExtensionNotSupportedMessage, ext));
            }
         }

        public static IEnumerable<SniffedPacket> ImportBinary(string path) {
            using (Stream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BinaryReader reader = new BinaryReader(stream)) {
                if (ASCIIEncoding.ASCII.GetString(reader.ReadBytes(BinaryHeader.Length)) != BinaryHeader) {
                    throw new ExportException(String.Format(StringResources.ImportInvalidHeaderErrorMessage, path));
                }

                if (reader.ReadInt32() != BinaryVersion) {
                    throw new ExportException(String.Format(StringResources.ImportInvalidVersionErrorMessage, path));
                }

                int numPackets = reader.ReadInt32();
                for (int i = 0; i < numPackets; i++) {
                    string packetType = reader.ReadString();
                    TimeSpan elapsedTime = TimeSpan.FromMilliseconds(reader.ReadDouble());
                    int numValues = reader.ReadInt32();

                    List<SniffedValue> values = new List<SniffedValue>(numValues);
                    for (int j = 0; j < numValues; j++) {
                        values.Add(new SniffedValue(
                            reader.ReadInt32(),
                            reader.ReadString(),
                            reader.ReadString(),
                            reader.ReadString()));
                    }

                    yield return new SniffedPacket(packetType, elapsedTime, values);
                }
            }

            yield break;
        }
    }
}
