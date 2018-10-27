
using Core.server;

namespace Auth.global.serverpacket
{
  public class HELPER_PAK : SendPacket
  {
    private short _packet;

    public HELPER_PAK(short packet)
    {
      this._packet = packet;
    }

    public override void write()
    {
      this.writeH(this._packet);
      this.writeD(0);
    }
  }
}
