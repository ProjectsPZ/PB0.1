
using Core.server;

namespace Game.global.serverpacket
{
  public class BATTLE_4VS4_ERROR_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3879);
    }
  }
}
