
using Core.server;

namespace Game.global.serverpacket
{
  public class LOTTERY_ENTER_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2898);
      this.writeD(0);
      this.writeC((byte) 0);
      this.writeC((byte) 0);
      this.writeC((byte) 0);
      this.writeB(new byte[340]);
    }
  }
}
