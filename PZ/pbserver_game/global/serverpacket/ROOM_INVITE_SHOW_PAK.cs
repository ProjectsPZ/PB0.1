
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class ROOM_INVITE_SHOW_PAK : SendPacket
  {
    private Account sender;
    private Room room;

    public ROOM_INVITE_SHOW_PAK(Account sender, Room room)
    {
      this.sender = sender;
      this.room = room;
    }

    public override void write()
    {
      this.writeH((short) 2053);
      this.writeS(this.sender.player_name, 33);
      this.writeD(this.room._roomId);
      this.writeQ(this.sender.player_id);
      this.writeS(this.room.password, 4);
    }
  }
}
