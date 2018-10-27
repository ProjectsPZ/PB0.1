
using Core.server;

namespace Game.global.serverpacket
{
  public class VOTEKICK_CANCEL_VOTE_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3405);
    }
  }
}
