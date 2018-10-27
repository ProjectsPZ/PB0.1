
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class A_3410_PAK : SendPacket
  {
    private Room room;

    public A_3410_PAK(Room room)
    {
      this.room = room;
    }

    public override void write()
    {
      this.writeH((short) 3410);
      this.writeC((byte) 0);
      this.writeH((ushort) this.room.red_dino);
      this.writeH((ushort) this.room.blue_dino);
    }
  }
}
