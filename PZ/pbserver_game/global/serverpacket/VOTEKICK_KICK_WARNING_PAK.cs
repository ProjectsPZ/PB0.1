
using Core.server;

namespace Game.global.serverpacket
{
  public class VOTEKICK_KICK_WARNING_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3409);
    }
  }
}
