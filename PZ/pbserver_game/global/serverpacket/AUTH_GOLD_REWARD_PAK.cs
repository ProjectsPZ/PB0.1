
using Core.server;

namespace Game.global.serverpacket
{
  public class AUTH_GOLD_REWARD_PAK : SendPacket
  {
    private int gp;
    private int _gpIncrease;
    private int type;

    public AUTH_GOLD_REWARD_PAK(int increase, int gold, int type)
    {
      this._gpIncrease = increase;
      this.gp = gold;
      this.type = type;
    }

    public override void write()
    {
      this.writeH((short) 561);
      this.writeD(this._gpIncrease);
      this.writeD(this.gp);
      this.writeD(this.type);
    }
  }
}
