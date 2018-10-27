
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CHANGE_FIGHTS_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 1409);
    }
  }
}
