
using Core.server;

namespace Game.global.serverpacket
{
  public class A_3104_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3104);
      this.writeD(0);
      this.writeC((byte) 254);
    }
  }
}
