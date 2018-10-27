
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_USER_EXIT_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2655);
    }
  }
}
