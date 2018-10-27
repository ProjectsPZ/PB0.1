
using Core.server;

namespace Game.global.serverpacket
{
  public class BATTLE_SENDPING_PAK : SendPacket
  {
    private byte[] _slots;

    public BATTLE_SENDPING_PAK(byte[] slots)
    {
      this._slots = slots;
    }

    public override void write()
    {
      this.writeH((short) 3345);
      this.writeB(this._slots);
    }
  }
}
