
using Core.server;

namespace Game.global.serverpacket
{
  public class A_2659_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2659);
      this.writeC((byte) 1);
      this.writeD(1300017001);
    }
  }
}
