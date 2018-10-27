
using Core.server;

namespace Game.global.serverpacket
{
  public class ROOM_NEW_HOST_PAK : SendPacket
  {
    private uint _slot;

    public ROOM_NEW_HOST_PAK(uint slot)
    {
      this._slot = slot;
    }

    public override void write()
    {
      this.writeH((short) 3873);
      this.writeD(this._slot);
    }
  }
}
