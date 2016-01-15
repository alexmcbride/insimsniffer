using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace InSimSniffer.Library {
    internal static class PacketHelper {
        public static void GetBytes(byte[] data, int index, ushort value) {
            Buffer.BlockCopy(BitConverter.GetBytes(value), 0, data, index, 2);
        }

        public static void GetBytes(byte[] data, int index, uint value) {
            Buffer.BlockCopy(BitConverter.GetBytes(value), 0, data, index, 4);
        }

        public static void GetBytes(byte[] data, int index, int value) {
            Buffer.BlockCopy(BitConverter.GetBytes(value), 0, data, index, 4);
        }

        public static void GetBytes(byte[] data, int index, float value) {
            Buffer.BlockCopy(BitConverter.GetBytes(value), 0, data, index, 4);
        }

        public static void GetBytes(byte[] data, int index, string value, int max) {
            max--;
            if (value.Length >= max) {
                value = value.Substring(0, max);
            }

            //EncodingHelper.GetBytes(value, data, index);

            ASCIIEncoding.ASCII.GetBytes(value, 0, value.Length, data, index);
        }
    }
}
