
using Core.server;

namespace Auth.global.serverpacket
{
  public class A_2677_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2677);
      this.writeH((short) 10);
      for (int index = 0; index < 10; ++index)
        this.writeH((short) (102 + index));
    }
  }
}
