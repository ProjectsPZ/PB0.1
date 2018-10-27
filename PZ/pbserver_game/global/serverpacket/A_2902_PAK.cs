
using Core.server;

namespace Game.global.serverpacket
{
  public class A_2902_PAK : SendPacket
  {
    public int result;

    public A_2902_PAK(int result)
    {
      this.result = result;
    }

    public override void write()
    {
      this.writeH((short) 2902);
      this.writeD(this.result);
      if (this.result < 0)
        return;
      this.writeB(new byte[1443]);
    }
  }
}
