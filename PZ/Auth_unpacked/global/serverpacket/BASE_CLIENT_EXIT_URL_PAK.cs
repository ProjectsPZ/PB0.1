
using Core.server;

namespace Auth.global.serverpacket
{
  public class BASE_CLIENT_EXIT_URL_PAK : SendPacket
  {
    private int count;
    private string linkAddress;

    public BASE_CLIENT_EXIT_URL_PAK(string link)
    {
      this.count = link.Length > 0 ? 1 : 0;
      this.linkAddress = link;
    }

    public override void write()
    {
      this.writeH((short) 2694);
      this.writeC((byte) this.count);
      if (this.count <= 0)
        return;
      this.writeD(1);
      this.writeD(9);
      this.writeS(this.linkAddress, 256);
    }
  }
}
