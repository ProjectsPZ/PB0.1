
using Core.server;

namespace Game.global.serverpacket
{
  public class LOBBY_QUICKJOIN_ROOM_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3078);
      this.writeD(2147483648U);
    }
  }
}
