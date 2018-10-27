
using Core.models.account.players;
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_USER_CHANGE_STATS_PAK : SendPacket
  {
    private PlayerStats s;

    public BASE_USER_CHANGE_STATS_PAK(PlayerStats s)
    {
      this.s = s;
    }

    public override void write()
    {
      this.writeH((short) 2610);
      this.writeD(this.s.fights);
      this.writeD(this.s.fights_win);
      this.writeD(this.s.fights_lost);
      this.writeD(this.s.fights_draw);
      this.writeD(this.s.kills_count);
      this.writeD(this.s.headshots_count);
      this.writeD(this.s.deaths_count);
      this.writeD(this.s.totalfights_count);
      this.writeD(this.s.totalkills_count);
      this.writeD(this.s.escapes);
      this.writeD(this.s.fights);
      this.writeD(this.s.fights_win);
      this.writeD(this.s.fights_lost);
      this.writeD(this.s.fights_draw);
      this.writeD(this.s.kills_count);
      this.writeD(this.s.headshots_count);
      this.writeD(this.s.deaths_count);
      this.writeD(this.s.totalfights_count);
      this.writeD(this.s.totalkills_count);
      this.writeD(this.s.escapes);
    }
  }
}
