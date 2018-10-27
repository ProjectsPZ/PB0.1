
using Core.server;

namespace Game.global.serverpacket
{
  public class BATTLE_MISSION_BOMB_UNINSTALL_PAK : SendPacket
  {
    private int _slot;

    public BATTLE_MISSION_BOMB_UNINSTALL_PAK(int slot)
    {
      this._slot = slot;
    }

    public override void write()
    {
      this.writeH((short) 3359);
      this.writeD(this._slot);
    }
  }
}
