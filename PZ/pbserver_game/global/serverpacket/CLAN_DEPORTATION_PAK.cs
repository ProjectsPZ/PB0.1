
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_DEPORTATION_PAK : SendPacket
  {
    private uint result;

    public CLAN_DEPORTATION_PAK(uint result)
    {
      this.result = result;
    }

    public override void write()
    {
      this.writeH((short) 1335);
      this.writeD(this.result);
    }
  }
}
