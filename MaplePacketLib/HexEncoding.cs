using System;

namespace MaplePacketLib {
    public class HexEncoding {
        private static Random RNG = new Random();

        public static bool IsHexDigit(Char c) {
            int numChar;
            int numA = Convert.ToInt32('A');
            int num1 = Convert.ToInt32('0');
            c = Char.ToUpper(c);
            numChar = Convert.ToInt32(c);
            if (numChar >= numA && numChar < (numA + 6))
                return true;
            if (numChar >= num1 && numChar < (num1 + 10))
                return true;
            return false;
        }

        private static byte HexToByte(string hex) {
            if (hex.Length > 2 || hex.Length <= 0)
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return newByte;
        }

        public static byte[] GetBytes(string hexString) {
            string newString = string.Empty;
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++) {
                c = hexString[i];
                if (IsHexDigit(c))
                    newString += c;
            }
            // if odd number of characters, discard last character
            if (newString.Length % 2 != 0) {
                newString = newString.Substring(0, newString.Length - 1);
            }

            int byteLength = newString.Length / 2;
            byte[] bytes = new byte[byteLength];
            string hex;
            int j = 0;
            for (int i = 0; i < bytes.Length; i++) {
                hex = new String(new Char[] { newString[j], newString[j + 1] });
                bytes[i] = HexToByte(hex);
                j = j + 2;
            }
            return bytes;
        }

        public static String ToStringFromAscii(byte[] bytes) {
            char[] ret = new char[bytes.Length];
            for (int x = 0; x < bytes.Length; x++) {
                if (bytes[x] < 32 && bytes[x] >= 0) {
                    ret[x] = '.';
                } else {
                    int chr = ((short)bytes[x]) & 0xFF;
                    ret[x] = (char)chr;
                }
            }
            return new String(ret);
        }

        public static string byteArrayToString(byte[] Array) {
            string temp = "";
            foreach (byte bit in Array) {
                temp += String.Format("{0:X2} ", bit);
            }
            return temp;
        }

        public static string ToHex(byte b) {
            return String.Format("{0:X2}", b);
        }

        public static string getRandomHexString(int digits, string spacer = "") {
            string toreturn = string.Empty;
            toreturn += ToHex((byte)RNG.Next(0xFF));
            for (int i = 0; i < digits - 1; i++)
                toreturn += spacer + HexEncoding.ToHex((byte)RNG.Next(0xFF));
            return toreturn;
        }

        public static unsafe string fillRandom(string packet) {
            fixed (char* pch = packet) {
                for (int i = 0; i < packet.Length; i++) //randomizes wildcards
                {
                    if (pch[i] == '*') {
                        pch[i] = String.Format("{0:X}", RNG.Next(16))[0];
                    }
                }
            }
            return packet;
        }
    }
}