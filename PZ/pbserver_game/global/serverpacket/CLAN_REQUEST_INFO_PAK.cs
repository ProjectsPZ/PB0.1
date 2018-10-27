
using Core.server;
using Game.data.managers;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_REQUEST_INFO_PAK : SendPacket
  {
    private string text;
    private uint _erro;
    private Account p;

    public CLAN_REQUEST_INFO_PAK(long id, string txt)
    {
      this.text = txt;
      this.p = AccountManager.getAccount(id, 0);
      if (this.p != null && this.text != null)
        return;
      this._erro = 2147483648U;
    }

    public override void write()
    {
      this.writeH((short) 1325);
      this.writeD(this._erro);
      if (this._erro != 0U)
        return;
      this.writeQ(this.p.player_id);
      this.writeS(this.p.player_name, 33);
      this.writeC((byte) this.p._rank);
      this.writeD(this.p._statistic.kills_count);
      this.writeD(this.p._statistic.deaths_count);
      this.writeD(this.p._statistic.fights);
      this.writeD(this.p._statistic.fights_win);
      this.writeD(this.p._statistic.fights_lost);
      this.writeS(this.text, this.text.Length + 1);
    }
  }
}
