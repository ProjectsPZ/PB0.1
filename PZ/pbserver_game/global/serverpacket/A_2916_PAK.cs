
using Core.server;

namespace Game.global.serverpacket
{
  public class A_2916_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2916);
      this.writeD(1);
    }
  }
}
