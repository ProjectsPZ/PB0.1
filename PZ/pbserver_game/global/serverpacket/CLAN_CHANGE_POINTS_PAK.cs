
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CHANGE_POINTS_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 1410);
    }
  }
}
