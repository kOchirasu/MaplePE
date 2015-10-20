using System.Collections.Generic;
using MaplePacketLib;
using MaplePE;

namespace MapleCLB.MaplePacketLib {
    class PacketHandler {
        private Dictionary<short, PacketFunction> HeaderMap;

        public PacketHandler() {
            HeaderMap = new Dictionary<short, PacketFunction>();
        }

        public void RegisterHeader(short h, PacketFunction f) {
            HeaderMap.Add(h, f);
        }

        public void Handle(Client c, PacketReader r) {
            try {
                HeaderMap[r.ReadShort()].Handle(c, r);
            } catch (KeyNotFoundException) {
                //don't handle it
            }
        }
    }

    interface PacketFunction {
        void Handle(Client c, PacketReader r);
    }
}
