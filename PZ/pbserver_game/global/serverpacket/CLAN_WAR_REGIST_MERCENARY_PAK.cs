
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_WAR_REGIST_MERCENARY_PAK : SendPacket
  {
    private Match m;

    public CLAN_WAR_REGIST_MERCENARY_PAK(Match m)
    {
      this.m = m;
    }

    public override void write()
    {
      this.writeH((short) 1552);
      this.writeH((short) this.m.getServerInfo());
      this.writeC((byte) this.m._state);
      this.writeC((byte) this.m.friendId);
      this.writeC((byte) this.m.formação);
      this.writeC((byte) this.m.getCountPlayers());
      this.writeD(this.m._leader);
      this.writeC((byte) 0);
      foreach (SLOT_MATCH slot in this.m._slots)
      {
        Account playerBySlot = this.m.getPlayerBySlot(slot);
        if (playerBySlot != null)
        {
          this.writeC((byte) playerBySlot._rank);
          this.writeS(playerBySlot.player_name, 33);
          this.writeQ(slot._playerId);
          this.writeC((byte) slot.state);
        }
        else
          this.writeB(new byte[43]);
      }
    }
  }
}
