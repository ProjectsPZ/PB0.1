
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BATTLE_DINO_PLACAR_PAK : SendPacket
  {
    private Room _r;

    public BATTLE_DINO_PLACAR_PAK(Room r)
    {
      this._r = r;
    }

    public override void write()
    {
      this.writeH((short) 3389);
      this.writeH((ushort) this._r.red_dino);
      this.writeH((ushort) this._r.blue_dino);
    }
  }
}
