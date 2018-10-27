
using Core.server;

namespace Game.global.serverpacket
{
  public class BATTLE_RESPAWN_FOR_AI_PAK : SendPacket
  {
    private int _slot;

    public BATTLE_RESPAWN_FOR_AI_PAK(int slot)
    {
      this._slot = slot;
    }

    public override void write()
    {
      this.writeH((short) 3379);
      this.writeD(this._slot);
    }
  }
}
