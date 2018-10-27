
using Core.server;

namespace Game.global.serverpacket
{
  public class LOTTERY_LEAVE_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2900);
    }
  }
}
