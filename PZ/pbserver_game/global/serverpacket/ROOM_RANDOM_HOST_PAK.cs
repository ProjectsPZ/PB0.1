
using Core.server;

namespace Game.global.serverpacket
{
  public class ROOM_RANDOM_HOST_PAK : SendPacket
  {
    private uint _slot;

    public ROOM_RANDOM_HOST_PAK(uint slot)
    {
      this._slot = slot;
    }

    public ROOM_RANDOM_HOST_PAK(int slot)
      : this((uint) slot)
    {
    }

    public override void write()
    {
      this.writeH((short) 3869);
      this.writeD(this._slot);
    }
  }
}
