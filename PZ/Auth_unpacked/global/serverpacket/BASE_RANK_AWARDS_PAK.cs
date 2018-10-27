
using Core.server;

namespace Auth.global.serverpacket
{
  public class BASE_RANK_AWARDS_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2667);
      for (int index = 0; index < 50; ++index)
      {
        this.writeC((byte) (index + 1));
        this.writeD(0);
        this.writeD(0);
        this.writeD(0);
        this.writeD(0);
      }
    }
  }
}
