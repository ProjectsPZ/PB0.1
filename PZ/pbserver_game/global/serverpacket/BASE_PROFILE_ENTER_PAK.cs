
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_PROFILE_ENTER_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3863);
    }
  }
}
