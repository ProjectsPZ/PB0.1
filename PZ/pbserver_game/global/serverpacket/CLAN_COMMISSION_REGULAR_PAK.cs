
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_COMMISSION_REGULAR_PAK : SendPacket
  {
    private uint result;

    public CLAN_COMMISSION_REGULAR_PAK(uint result)
    {
      this.result = result;
    }

    public override void write()
    {
      this.writeH((short) 1344);
      this.writeD(this.result);
    }
  }
}
