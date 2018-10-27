
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_SERVER_CHANGE_PAK : SendPacket
  {
    private int error;

    public BASE_SERVER_CHANGE_PAK(int error)
    {
      this.error = error;
    }

    public override void write()
    {
      this.writeH((short) 2578);
      this.writeD(this.error);
    }
  }
}
