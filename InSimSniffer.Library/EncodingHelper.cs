using System;
using System.Collections.Generic;
using System.Text;

namespace InSimSniffer.Library {
    internal static class EncodingHelper {
        private static readonly Dictionary<char, Encoding> EncodingMap = new Dictionary<char, Encoding> 
        {
            { 'L', Encoding.GetEncoding(1252) },
            { 'G', Encoding.GetEncoding(1253) },
            { 'C', Encoding.GetEncoding(1251) },
            { 'J', Encoding.GetEncoding(932) },
            { 'E', Encoding.GetEncoding(1250) },
            { 'T', Encoding.GetEncoding(1254) },
            { 'B', Encoding.GetEncoding(1257) },
            { 'H', Encoding.GetEncoding(950) },
            { 'S', Encoding.GetEncoding(936) },
            { 'K', Encoding.GetEncoding(949) },
        };

        private static readonly Dictionary<char, char> EscapeMap = new Dictionary<char, char>
        {
            { 'v', '|' },
            { 'a', '*' },
            { 'c', ':' },
            { 'd', '\\' },
            { 's', '/' },
            { 'q', '?' },
            { 't', '"' },
            { 'l', '<' },
            { 'r', '>' },
            { '^', '^' },
        };

        public static string GetString(byte[] buffer, int index, int length) {
            StringBuilder output = new StringBuilder(length);
            Encoding encoding = EncodingMap['L'], enc = null;
            int i = 0, start = index;
            char escape;

            for (i = index; i < index + length; i++) {
                char current = (char)buffer[i];

                if (current == Char.MinValue) {
                    break;
                }
                else if (current == '^') {
                    if (i - start > 0) {
                        output.Append(encoding.GetString(buffer, start, i - start));
                    }
                    start = (++i) + 1;

                    char next = (char)buffer[i];
                    if (EncodingMap.TryGetValue(next, out enc)) {
                        encoding = enc;
                    }
                    else if (EscapeMap.TryGetValue(next, out escape)) {
                        output.Append(escape);
                    }
                    else {
                        output.Append('^');
                        output.Append(next);
                    }
                }
            }

            if (i - start > 0) {
                output.Append(encoding.GetString(buffer, start, i - start));
            }

            return output.ToString();
        }

        public static void GetBytes(string value, byte[] buffer, int index, int length) {
            Encoding encoding = EncodingMap['L'];
            byte[] bytes;
            int count;

            for (int i = 0; i < value.Length && i < length - 1; i++) {
                if (value[i] < 128) {
                    // All codepages share first 128 characters
                    buffer[index++] = (byte)value[i];
                }
                else if (TryGetBytes(encoding, value[i], out bytes, out count)) {
                    // Character exists in current codepage.
                    Buffer.BlockCopy(bytes, 0, buffer, index, count);
                    index += count;
                }
                else {
                    // Switch codepage.
                    foreach (KeyValuePair<char, Encoding> enc in EncodingMap) {
                        if (enc.Value != encoding && TryGetBytes(enc.Value, value[i], out bytes, out count)) {
                            encoding = enc.Value;

                            buffer[index++] = (byte)'^';
                            buffer[index++] = (byte)enc.Key;
                            Buffer.BlockCopy(bytes, 0, buffer, index, count);
                            index += count;

                            break;
                        }
                    }
                }
            }
        }

        private static bool TryGetBytes(Encoding encoding, char value, out byte[] bytes, out int count) {
            bytes = new byte[2];
            bool failed = false;
            count = NativeMethods.WideCharToMultiByte((uint)encoding.CodePage, 0, value.ToString(), 1, bytes, 2, IntPtr.Zero, out failed);
            return !failed;
        }
    }
}
