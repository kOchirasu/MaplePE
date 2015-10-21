using MaplePacketLib;
using MaplePacketLib.Cryptography;
using System;
using System.Net;
using System.Windows.Forms;

namespace MaplePE {
    static class Program {
        public static MainForm gui;
        public static Client client;
        public static AesCipher cipher;
        public const string loginIP = "8.31.99.141";
        public const short loginPort = 8484;

        public static readonly byte[] userKey = new byte[32] //166.1
        {
            0xD6, 0x00, 0x00, 0x00, 
            0x1F, 0x00, 0x00, 0x00, 
            0xCE, 0x00, 0x00, 0x00, 
            0xD9, 0x00, 0x00, 0x00, 
            0x41, 0x00, 0x00, 0x00, 
            0x07, 0x00, 0x00, 0x00, 
            0xB7, 0x00, 0x00, 0x00, 
            0x07, 0x00, 0x00, 0x00
        };

        [STAThread]
        static void Main() {
            cipher = new AesCipher(userKey);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            client = new Client(IPAddress.Parse(loginIP), loginPort, cipher);
            gui = new MainForm();
            Application.Run(gui);
        }
    }
}
