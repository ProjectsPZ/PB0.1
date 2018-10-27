
using Core.models.account.players;
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_GET_USER_STATS_PAK : SendPacket
  {
    private PlayerStats st;

    public BASE_GET_USER_STATS_PAK(PlayerStats stats)
    {
      this.st = stats;
    }

    public override void write()
    {
      this.writeH((short) 2592);
      if (this.st != null)
      {
        this.writeD(this.st.fights);
        this.writeD(this.st.fights_win);
        this.writeD(this.st.fights_lost);
        this.writeD(this.st.fights_draw);
        this.writeD(this.st.kills_count);
        this.writeD(this.st.headshots_count);
        this.writeD(this.st.deaths_count);
        this.writeD(this.st.totalfights_count);
        this.writeD(this.st.totalkills_count);
        this.writeD(this.st.escapes);
        this.writeD(this.st.fights);
        this.writeD(this.st.fights_win);
        this.writeD(this.st.fights_lost);
        this.writeD(this.st.fights_draw);
        this.writeD(this.st.kills_count);
        this.writeD(this.st.headshots_count);
        this.writeD(this.st.deaths_count);
        this.writeD(this.st.totalfights_count);
        this.writeD(this.st.totalkills_count);
        this.writeD(this.st.escapes);
      }
      else
        this.writeB(new byte[80]);
    }
  }
}
