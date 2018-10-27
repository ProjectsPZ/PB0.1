
using Core.server;

namespace Game.global.serverpacket
{
  public class A_2669_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2669);
      this.writeB(new byte[48]);
    }
  }
}
