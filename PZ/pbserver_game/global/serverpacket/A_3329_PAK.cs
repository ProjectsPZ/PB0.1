
using Core.server;

namespace Game.global.serverpacket
{
  public class A_3329_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3330);
      this.writeD(0);
    }
  }
}
