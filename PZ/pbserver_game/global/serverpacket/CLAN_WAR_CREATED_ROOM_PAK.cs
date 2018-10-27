
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_WAR_CREATED_ROOM_PAK : SendPacket
  {
    public Match _mt;

    public CLAN_WAR_CREATED_ROOM_PAK(Match match)
    {
      this._mt = match;
    }

    public override void write()
    {
      this.writeH((short) 1564);
      this.writeH((short) this._mt._matchId);
      this.writeD(this._mt.getServerInfo());
      this.writeH((short) this._mt.getServerInfo());
      this.writeC((byte) 10);
    }
  }
}
