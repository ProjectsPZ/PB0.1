
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CLIENT_LEAVE_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 1444);
    }
  }
}
