
using Core.server;

namespace Auth.global.serverpacket
{
  public class A_475_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 475);
      this.writeC((byte) 1);
      this.writeC((byte) 5);
      this.writeS("", 5);
      this.writeC((byte) 5);
      this.writeS("", 5);
      this.writeQ(1L);
    }
  }
}
