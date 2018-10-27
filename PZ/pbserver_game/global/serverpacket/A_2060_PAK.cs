
using Core.server;

namespace Game.global.serverpacket
{
  public class A_2060_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2060);
      this.writeQ(10L);
      this.writeD(20);
    }
  }
}
