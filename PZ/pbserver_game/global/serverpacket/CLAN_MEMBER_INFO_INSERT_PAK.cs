
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_MEMBER_INFO_INSERT_PAK : SendPacket
  {
    private Account p;
    private ulong status;

    public CLAN_MEMBER_INFO_INSERT_PAK(Account pl)
    {
      this.p = pl;
      this.status = ComDiv.GetClanStatus(pl._status, pl._isOnline);
    }

    public override void write()
    {
      this.writeH((short) 1351);
      this.writeC((byte) (this.p.player_name.Length + 1));
      this.writeS(this.p.player_name, this.p.player_name.Length + 1);
      this.writeQ(this.p.player_id);
      this.writeQ(this.status);
      this.writeC((byte) this.p._rank);
    }
  }
}
