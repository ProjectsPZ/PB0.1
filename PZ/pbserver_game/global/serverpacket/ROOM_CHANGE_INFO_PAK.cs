
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class ROOM_CHANGE_INFO_PAK : SendPacket
  {
    private string _leader;
    private Room _room;

    public ROOM_CHANGE_INFO_PAK(Room room, string leader)
    {
      this._room = room;
      this._leader = leader;
    }

    public override void write()
    {
      this.writeH((short) 3859);
      this.writeS(this._leader, 33);
      this.writeD(this._room.killtime);
      this.writeC(this._room.limit);
      this.writeC(this._room.seeConf);
      this.writeH((short) this._room.autobalans);
    }
  }
}
