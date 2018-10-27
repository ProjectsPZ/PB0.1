
using Core.server;

namespace Game.global.serverpacket
{
  public class LOBBY_ENTER_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3080);
      this.writeD(0);
    }
  }
}
