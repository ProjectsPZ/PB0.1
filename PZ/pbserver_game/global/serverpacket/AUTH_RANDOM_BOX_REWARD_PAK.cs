
using Core.server;

namespace Game.global.serverpacket
{
  public class AUTH_RANDOM_BOX_REWARD_PAK : SendPacket
  {
    private int _cupomId;
    private int _rnd;

    public AUTH_RANDOM_BOX_REWARD_PAK(int cupomId, int index)
    {
      this._cupomId = cupomId;
      this._rnd = index;
    }

    public override void write()
    {
      this.writeH((short) 551);
      this.writeD(this._cupomId);
      this.writeC((byte) this._rnd);
    }
  }
}
