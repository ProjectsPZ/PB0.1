
using Core.server;

namespace Auth.global.serverpacket
{
  public class A_2630_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2630);
    }
  }
}
