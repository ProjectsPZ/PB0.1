
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_WAR_JOINED_ROOM_PAK : SendPacket
  {
    private Match _mt;
    private int _roomId;
    private int _team;

    public CLAN_WAR_JOINED_ROOM_PAK(Match match, int roomId, int team)
    {
      this._mt = match;
      this._roomId = roomId;
      this._team = team;
    }

    public override void write()
    {
      this.writeH((short) 1566);
      this.writeD(this._roomId);
      this.writeH((ushort) this._team);
      this.writeH((ushort) this._mt.getServerInfo());
    }
  }
}
