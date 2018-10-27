
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BATTLE_MISSION_DEFENCE_INFO_PAK : SendPacket
  {
    private Room room;

    public BATTLE_MISSION_DEFENCE_INFO_PAK(Room room)
    {
      this.room = room;
    }

    public override void write()
    {
      this.writeH((short) 3387);
      this.writeH((ushort) this.room.Bar1);
      this.writeH((ushort) this.room.Bar2);
      for (int index = 0; index < 16; ++index)
        this.writeH(this.room._slots[index].damageBar1);
      for (int index = 0; index < 16; ++index)
        this.writeH(this.room._slots[index].damageBar2);
    }
  }
}
