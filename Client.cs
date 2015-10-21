using MaplePacketLib;
using MaplePacketLib.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MaplePE {
    class Client {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private AesCipher aesCipher;

        public Session toClient;
        public Session toServer;

        private bool connectedToServer = false;

        private ServerInfo handshakeInfo;

        public Client(IPAddress ipAddress, int port, AesCipher aesCipher) {
            this.ipAddress = ipAddress;
            this.port = port;
            this.aesCipher = aesCipher;
        }

        /*public static void DisableTunnel() {
            List<string> iPList = new List<string>();
            iPList.Add("8.31.99.133");
            iPList.Add("8.31.99.134");
            iPList.Add("8.31.99.135");
            iPList.Add("8.31.99.136");
            iPList.Add("8.31.99.137");
            iPList.Add("8.31.99.138");
            iPList.Add("8.31.99.139");
            iPList.Add("8.31.99.140");
            iPList.Add("8.31.99.141");
            //iPList.Add("8.31.99.142");
            //iPList.Add("8.31.99.143");
            iPList.Add("8.31.99.144");
            iPList.Add("8.31.99.145");
            iPList.Add("8.31.99.146");
            iPList.Add("8.31.99.200");
            iPList.Add("8.31.99.201");
            iPList.Add("8.31.99.244");

            foreach (string ip in iPList) {
                new Process {
                    StartInfo = {
                        FileName = "netsh", 
                        Arguments = "int ip delete addr 1 " + ip, 
                        CreateNoWindow = true, 
                        UseShellExecute = false
                    }
                }.Start();
            }
        }

        public bool AdapterChecks() {
            List<string> iPList = new List<string>();
            /*iPList.Add("8.31.99.133");
            iPList.Add("8.31.99.134");
            iPList.Add("8.31.99.135");
            iPList.Add("8.31.99.136");
            iPList.Add("8.31.99.137");
            iPList.Add("8.31.99.138");
            iPList.Add("8.31.99.139");
            iPList.Add("8.31.99.140");
            iPList.Add("8.31.99.141");*/
            /*iPList.Add("8.31.99.142");
            iPList.Add("8.31.99.143");
            /*iPList.Add("8.31.99.144");
            iPList.Add("8.31.99.145");
            iPList.Add("8.31.99.146");
            iPList.Add("8.31.99.200");
            iPList.Add("8.31.99.201");
            iPList.Add("8.31.99.244");*/
        /*this.AddIpToAdapter(iPList);
        return true;
    }

    public void AddIpToAdapter(List<string> IPList) {
        new Process { 
            StartInfo = { 
                FileName = "netsh", 
                Arguments = "interface ip set dns \"Loopback Pseudo-Interface 1\" dhcp", 
                CreateNoWindow = true, 
                UseShellExecute = false
            }
        }.Start();

        foreach (string ip in IPList) {
            new Process {
                StartInfo = {
                    FileName = "netsh", 
                    Arguments = "int ip add addr 1 " + ip + " st=ac", 
                    CreateNoWindow = true, 
                    UseShellExecute = false
                }
            }.Start();
        }
    }

    public void StartTunnels() {
        //AdapterChecks();

        ServerInfo info = new ServerInfo() {
            Version = 166,
            Locale = 8,
            Subversion = "1"
        };
        Acceptor acceptor = new Acceptor(info, aesCipher, port);
        acceptor.OnClientAccepted += new EventHandler<Session>(OnClientAccepted);
        acceptor.Start();
        /*try {
            ushort lowPort = 8484;
            ushort highPort = 8888;
            string toIP = Program.toIP;
            if (Program.checkIP(toIP)) {
                ushort num5;
                if (false) {
                    LinkServer server = new LinkServer(8484, toIP);
                    ushort num3 = (ushort)(highPort - lowPort);
                    for (ushort i = 0; i <= num3; i = (ushort)(num5 + 1)) {
                        LinkServer server2 = new LinkServer((ushort)(lowPort + i), toIP);
                        num5 = i;
                    }
                } else {
                    Listener listener = new Listener();
                    Debug.WriteLine("Listening on 8484");
                    listener.OnClientConnected += new Listener.ClientConnectedHandler(this.listener_OnClientConnected);
                    listener.Listen(8484);
                    LinkServer server3 = new LinkServer(8789, toIP);
                    ushort num6 = (ushort)(highPort - lowPort);
                    for (ushort j = 0; j <= num6; j = (ushort)(num5 + 1)) {
                        Listener listener2 = new Listener();
                        listener2.OnClientConnected += new Listener.ClientConnectedHandler(this.listener_OnClientConnected);
                        listener2.Listen((ushort)(lowPort + j));
                        Debug.WriteLine("Listening on " + ((lowPort + j)).ToString());
                        this.Listeners.Add((ushort)(lowPort + j), listener2);
                        num5 = j;
                    }
                }
            }
        } catch {
        }
    }*/

        public void Listen() {
            ServerInfo info = new ServerInfo() {
                Version = 166,
                Locale = 8,
                Subversion = "1"
            };
            Acceptor acceptor = new Acceptor(info, aesCipher, port);
            acceptor.OnClientAccepted += new EventHandler<Session>(OnClientAccepted);
            acceptor.Start();

            /*Process maple = new Process();
            if (!File.Exists("C:/Nexon/Maplestory/MapleStory.exe")) {
                Debug.WriteLine("Maple doesnt exist...");
                Application.Exit();
            }
            maple.StartInfo.FileName = "C:/Nexon/Maplestory/MapleStory.exe";
            maple.StartInfo.Arguments = "GameLaunching";
            maple.Start();*/
        }

        public void OnClientAccepted(object o, Session toClient) {
            this.toClient = toClient;
            Debug.WriteLine("CONNECTION MADE WITH CLIENT");
            // Setup handlers
            toClient.OnDisconnected += new EventHandler(OnClientDisconnected);
            toClient.OnPacket += new EventHandler<byte[]>(OnClientPacket);
            if (handshakeInfo != null) {
                toClient.Start(handshakeInfo);
            }

            // Now you actually need to connect to game...
            // DisableTunnel();
            // Connect from FakeClient to Server
            if (!connectedToServer) {
                Connector connector = new Connector(ipAddress, port, aesCipher);
                connector.OnConnected += new EventHandler<Session>(OnServerConnected);
                connector.OnError += new EventHandler<SocketError>(OnError);
                connector.Connect();
            }
        }

        void OnError(object c, SocketError e) {
            Debug.WriteLine("ERROR!");
        }

        void OnServerConnected(object o, Session toServer) {
            connectedToServer = true;
            this.toServer = toServer;
            Debug.WriteLine("CONNECTION MADE WITH SERVER");
            toServer.OnDisconnected += new EventHandler(OnServerDisconnected);
            toServer.OnPacket += new EventHandler<byte[]>(OnServerPacket);
            toServer.OnHandshake += new EventHandler<ServerInfo>(OnHandshake);
        }

        void OnClientDisconnected(object o, EventArgs e) {
            Debug.WriteLine("shit we disconnected from client");
        }

        void OnServerDisconnected(object o, EventArgs e) {
            Debug.WriteLine("shit we disconnected from server");
            connectedToServer = false;
        }

        void OnHandshake(object o, ServerInfo info) {
            Debug.WriteLine("forwarding handshake to client: " + info.Version + "." + info.Subversion);
            handshakeInfo = info;
            toClient.Start(info);
        }

        // Packets being sent out
        void OnClientPacket(object o, byte[] p) {
            //Debug.WriteLine("SEND: " + HexEncoding.byteArrayToString(p));

            Program.gui.AddPacket(MainForm.LogType.SEND, p);
            toServer.SendPacket(p);
        }

        // Packets being received
        void OnServerPacket(object o, byte[] p) {
            //Debug.WriteLine("RECV: " + HexEncoding.byteArrayToString(p));

            Program.gui.AddPacket(MainForm.LogType.RECV, p);
            toClient.SendPacket(p);
        }

        public void SendPacket(PacketWriter pw) {
            toServer.SendPacket(pw);
        }

        public void RecvPacket(PacketWriter pw) {
            toClient.SendPacket(pw);
        }
    }
}

/*int localPort = 0;// ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port;
// Connect from Client to FakeClient
Connector fromClient = new Connector(IPAddress.Loopback, localPort, aesCipher);
fromClient.OnConnected += new EventHandler<Session>(OnClientConnected);
fromClient.OnError += new EventHandler<SocketError>(OnError);
fromClient.Connect();*/
