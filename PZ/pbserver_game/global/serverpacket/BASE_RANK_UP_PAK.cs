
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_RANK_UP_PAK : SendPacket
  {
    private int _rank;
    private int _allExp;

    public BASE_RANK_UP_PAK(int rank, int allExp)
    {
      this._rank = rank;
      this._allExp = allExp;
    }

    public override void write()
    {
      this.writeH((short) 2614);
      this.writeD(this._rank);
      this.writeD(this._rank);
      this.writeD(this._allExp);
    }
  }
}
