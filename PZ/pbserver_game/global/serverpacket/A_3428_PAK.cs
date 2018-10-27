
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class A_3428_PAK : SendPacket
  {
    private Room room;

    public A_3428_PAK(Room room)
    {
      this.room = room;
    }

    public override void write()
    {
      this.writeH((short) 3429);
      this.writeD((int) this.room.room_type);
      this.writeD(this.room.getTimeByMask() * 60 - this.room.getInBattleTime());
      if (this.room.room_type == (byte) 7)
      {
        this.writeD(this.room.red_dino);
        this.writeD(this.room.blue_dino);
      }
      else if (this.room.room_type == (byte) 1 || this.room.room_type == (byte) 8 || this.room.room_type == (byte) 13)
      {
        this.writeD(this.room._redKills);
        this.writeD(this.room._blueKills);
      }
      else
      {
        this.writeD(this.room.red_rounds);
        this.writeD(this.room.blue_rounds);
      }
    }
  }
}
