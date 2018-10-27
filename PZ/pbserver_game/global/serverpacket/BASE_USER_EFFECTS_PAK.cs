
using Core.models.account.players;
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_USER_EFFECTS_PAK : SendPacket
  {
    private int _type;
    private PlayerBonus _bonus;

    public BASE_USER_EFFECTS_PAK(int type, PlayerBonus bonus)
    {
      this._type = type;
      this._bonus = bonus;
    }

    public override void write()
    {
      this.writeH((short) 2638);
      this.writeH((ushort) this._type);
      this.writeD(this._bonus.fakeRank);
      this.writeD(this._bonus.fakeRank);
      this.writeS(this._bonus.fakeNick, 33);
      this.writeH((short) this._bonus.sightColor);
    }
  }
}
