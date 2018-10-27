
using Core.models.account.clan;
using Core.server;
using Game.data.managers;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BASE_2612_PAK : SendPacket
  {
    private Account p;
    private Clan clan;

    public BASE_2612_PAK(Account player)
    {
      this.p = player;
      this.clan = ClanManager.getClan(this.p.clanId);
    }

    public override void write()
    {
      this.writeH((short) 2612);
      this.writeS(this.p.player_name, 33);
      this.writeD(this.p._exp);
      this.writeD(this.p._rank);
      this.writeD(this.p._rank);
      this.writeD(this.p._gp);
      this.writeD(this.p._money);
      this.writeD(this.clan._id);
      this.writeD(this.p.clanAccess);
      this.writeQ(0L);
      this.writeC((byte) this.p.pc_cafe);
      this.writeC((byte) this.p.tourneyLevel);
      this.writeC((byte) this.p.name_color);
      this.writeS(this.clan._name, 17);
      this.writeC((byte) this.clan._rank);
      this.writeC((byte) this.clan.getClanUnit());
      this.writeD(this.clan._logo);
      this.writeC((byte) this.clan._name_color);
      this.writeD(10000);
      this.writeC((byte) 0);
      this.writeD(0);
      this.writeD(this.p.LastRankUpDate);
    }
  }
}
