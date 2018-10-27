
using Core.server;

namespace Game.global.serverpacket
{
  public class A_3096_PAK : SendPacket
  {
    private int XPEarned;
    private int GPEarned;

    public A_3096_PAK(int xp_earned, int gp_earned)
    {
      this.XPEarned = xp_earned;
      this.GPEarned = gp_earned;
    }

    public override void write()
    {
      this.writeH((short) 3097);
      this.writeD(this.XPEarned);
      this.writeD(this.GPEarned);
    }
  }
}
