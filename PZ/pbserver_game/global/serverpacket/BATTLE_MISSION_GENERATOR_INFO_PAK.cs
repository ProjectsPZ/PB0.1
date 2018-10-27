
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BATTLE_MISSION_GENERATOR_INFO_PAK : SendPacket
  {
    private Room _room;

    public BATTLE_MISSION_GENERATOR_INFO_PAK(Room room)
    {
      this._room = room;
    }

    public override void write()
    {
      this.writeH((short) 3369);
      this.writeH((ushort) this._room.Bar1);
      this.writeH((ushort) this._room.Bar2);
      for (int index = 0; index < 16; ++index)
        this.writeH(this._room._slots[index].damageBar1);
    }
  }
}
