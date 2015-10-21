using MaplePacketLib;
using System;
using System.Net;
using System.Windows.Forms;

namespace MaplePE
{
    public partial class MainForm : Form
    {
        public enum LogType { SEND, RECV };
        public MainForm()
        {
            InitializeComponent();

            Program.client.Listen();

            
            //Redirector redirector = new Redirector(Program.loginPort);
            //redirector.Start();

            /*Server server = new Server();
            server.RemoteAddress = IPAddress.Any;
            server.RemotePort = 8786;

            server.Start();*/
        }

        public void AddPacket(LogType type, byte[] packet) {
            PacketReader reader = new PacketReader(packet);
            string key = reader.ReadShort().ToString("x").ToUpper().PadLeft(4, '0');

            TreeView log;
            if (type == LogType.SEND) {
                log = sendView;
            } else if (type == LogType.RECV) {
                log = recvView;
            } else {
                throw new ArgumentException("Not a valid LogType.");
            }

            if (log.Nodes[key] == null)
            {
                log.Invoke((MethodInvoker)(() => log.Nodes.Add(key, key))); //prevent outside thread from accessing error
            }
            log.Invoke((MethodInvoker)(() => log.Nodes[key].Nodes.Add(reader.ToString())));
        }

        private void sendButton_Click(object sender, EventArgs e) {
            PacketWriter pw = new PacketWriter();
            pw.WriteHexString(packetText.Text);
            Program.client.SendPacket(pw);
        }

        private void recvButton_Click(object sender, EventArgs e) {
            PacketWriter pw = new PacketWriter();
            pw.WriteHexString(packetText.Text);
            Program.client.RecvPacket(pw);
        }
    }
}
