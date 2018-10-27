
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_PRIVILEGES_KICK_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 1336);
    }
  }
}
