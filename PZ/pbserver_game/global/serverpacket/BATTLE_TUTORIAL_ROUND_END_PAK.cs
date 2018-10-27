
using Core.server;

namespace Game.global.serverpacket
{
  public class BATTLE_TUTORIAL_ROUND_END_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3395);
      this.writeC((byte) 3);
      this.writeD(110);
    }
  }
}
