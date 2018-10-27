
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BATTLE_CHANGE_DIFFICULTY_LEVEL_PAK : SendPacket
  {
    private Room room;

    public BATTLE_CHANGE_DIFFICULTY_LEVEL_PAK(Room room)
    {
      this.room = room;
    }

    public override void write()
    {
      this.writeH((short) 3377);
      this.writeC(this.room.IngameAiLevel);
      for (int index = 0; index < 16; ++index)
        this.writeD(this.room._slots[index].aiLevel);
    }
  }
}
