
using Core.models.room;
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BATTLE_RECORD_PAK : SendPacket
  {
    private Room _r;

    public BATTLE_RECORD_PAK(Room r)
    {
      this._r = r;
    }

    public override void write()
    {
      this.writeH((short) 3363);
      this.writeH((ushort) this._r._redKills);
      this.writeH((ushort) this._r._redDeaths);
      this.writeH((ushort) this._r._blueKills);
      this.writeH((ushort) this._r._blueDeaths);
      for (int index = 0; index < 16; ++index)
      {
        SLOT slot = this._r._slots[index];
        this.writeH((ushort) slot.allKills);
        this.writeH((ushort) slot.allDeaths);
      }
    }
  }
}
