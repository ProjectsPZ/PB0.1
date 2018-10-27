
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_MEMBER_INFO_UPDATE_PAK : SendPacket
  {
    private Account p;
    private ulong status;

    public CLAN_MEMBER_INFO_UPDATE_PAK(Account pl)
    {
      this.p = pl;
      this.status = ComDiv.GetClanStatus(pl._status, pl._isOnline);
    }

    public override void write()
    {
      this.writeH((short) 1380);
      this.writeQ(this.p.player_id);
      this.writeS(this.p.player_name, 33);
      this.writeC((byte) this.p._rank);
      this.writeC((byte) this.p.clanAccess);
      this.writeQ(this.status);
      this.writeD(this.p.clanDate);
      this.writeC((byte) this.p.name_color);
    }
  }
}
