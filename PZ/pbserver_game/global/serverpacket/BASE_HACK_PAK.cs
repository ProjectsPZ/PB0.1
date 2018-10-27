
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_HACK_PAK : SendPacket
  {
    private byte[] _u;

    public BASE_HACK_PAK(byte[] u)
    {
      this._u = u;
    }

    public override void write()
    {
      this.writeH((short) 2583);
      this.writeB(new byte[512]);
    }
  }
}
