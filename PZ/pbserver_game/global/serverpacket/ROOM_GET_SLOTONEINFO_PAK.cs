
using Core.models.account.clan;
using Core.server;
using Game.data.managers;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class ROOM_GET_SLOTONEINFO_PAK : SendPacket
  {
    private Account p;
    private Clan clan;

    public ROOM_GET_SLOTONEINFO_PAK(Account player)
    {
      this.p = player;
      if (this.p == null)
        return;
      this.clan = ClanManager.getClan(this.p.clanId);
    }

    public ROOM_GET_SLOTONEINFO_PAK(Account player, Clan c)
    {
      this.p = player;
      this.clan = c;
    }

    public override void write()
    {
      if (this.p._room == null || this.p._slotId == -1)
        return;
      this.writeH((short) 3909);
      this.writeD(this.p._slotId);
      this.writeC((byte) this.p._room._slots[this.p._slotId].state);
      this.writeC((byte) this.p.getRank());
      this.writeD(this.clan._id);
      this.writeD(this.p.clanAccess);
      this.writeC((byte) this.clan._rank);
      this.writeD(this.clan._logo);
      this.writeC((byte) this.p.pc_cafe);
      this.writeC((byte) this.p.tourneyLevel);
      this.writeD((uint) this.p.effects);
      this.writeS(this.clan._name, 17);
      this.writeD(0);
      this.writeC((byte) 31);
      this.writeS(this.p.player_name, 33);
      this.writeC((byte) this.p.name_color);
    }
  }
}
