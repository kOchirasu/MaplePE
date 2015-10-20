using System;

namespace MaplePacketLib {
    public class PacketReader {
        private readonly byte[] m_buffer;
        private int m_index;

        public int Position {
            get {
                return m_index;
            }
        }
        public int Available {
            get {
                return m_buffer.Length - m_index;
            }
        }

        public PacketReader(byte[] packet) {
            m_buffer = packet;
            m_index = 0;
        }

        private void CheckLength(int length) {
            if (m_index + length > m_buffer.Length || length < 0)
                throw new PacketException("Not enough space");
        }

        public byte ReadByte() {
            CheckLength(1);
            return m_buffer[m_index++];
        }
        public bool ReadBool() {
            return ReadByte() == 1;
        }
        public byte[] ReadBytes(int count) {
            CheckLength(count);
            var temp = new byte[count];
            Buffer.BlockCopy(m_buffer, m_index, temp, 0, count);
            m_index += count;
            return temp;
        }
        public unsafe short ReadShort() {
            CheckLength(2);

            short value;

            fixed (byte* ptr = m_buffer) {
                value = *(short*)(ptr + m_index);
            }

            m_index += 2;

            return value;
        }
        public unsafe int ReadInt() {
            CheckLength(4);

            int value;

            fixed (byte* ptr = m_buffer) {
                value = *(int*)(ptr + m_index);
            }

            m_index += 4;

            return value;
        }
        public unsafe long ReadLong() {
            CheckLength(8);

            long value;

            fixed (byte* ptr = m_buffer) {
                value = *(long*)(ptr + m_index);
            }

            m_index += 8;

            return value;
        }

        public string ReadString(int count) {
            CheckLength(count);

            char[] final = new char[count];

            for (int i = 0; i < count; i++) {
                final[i] = (char)ReadByte();
            }

            return new string(final);
        }
        public string ReadMapleString() {
            short count = ReadShort();
            return ReadString(count);
        }
        public string ReadHexString(int count) {
            return HexEncoding.byteArrayToString(ReadBytes(count));
        }

        public void Skip(int count) {
            CheckLength(count);
            /*if (log)
                Console.WriteLine("skipped from " + m_index + " to " + (m_index + count));*/
            m_index += count;
        }
        public void Next(byte b) {
            int loc = Array.IndexOf(ToArray(), b, m_index + 1);
            if (loc > 0) {
                //Console.WriteLine("current at " + m_index + " skipping " + (loc - m_index));
                Skip(loc - m_index);
            } else
                throw new PacketException("Unable to find byte.");
        }

        public byte[] ToArray() {
            var final = new byte[m_buffer.Length];
            Buffer.BlockCopy(m_buffer, 0, final, 0, m_buffer.Length);
            return final;
        }

        public override string ToString() {
            return HexEncoding.byteArrayToString(ToArray());
        }
    }
}
