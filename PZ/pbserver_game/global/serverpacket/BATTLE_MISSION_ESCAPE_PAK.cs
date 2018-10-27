
using Core.models.room;
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BATTLE_MISSION_ESCAPE_PAK : SendPacket
  {
    private Room r;
    private SLOT slot;

    public BATTLE_MISSION_ESCAPE_PAK(Room room, SLOT slot)
    {
      this.r = room;
      this.slot = slot;
    }

    public override void write()
    {
      this.writeH((short) 3383);
      this.writeH((ushort) this.r.red_dino);
      this.writeH((ushort) this.r.blue_dino);
      this.writeD(this.slot._id);
      this.writeH((short) this.slot.passSequence);
    }
  }
}
