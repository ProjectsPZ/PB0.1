
using Core.server;

namespace Game.global.serverpacket
{
  public class FRIEND_ROOM_INVITE_PAK : SendPacket
  {
    private int _idx;

    public FRIEND_ROOM_INVITE_PAK(int idx)
    {
      this._idx = idx;
    }

    public override void write()
    {
      this.writeH((short) 277);
      this.writeC((byte) this._idx);
    }
  }
}
