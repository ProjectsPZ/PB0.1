
using Core.server;

namespace Game.global.serverpacket
{
  public class SERVER_MESSAGE_KICK_PLAYER_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2051);
    }
  }
}
