
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CREATE_REQUIREMENTS_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 1417);
      this.writeC((byte) ConfigGS.minCreateRank);
      this.writeD(ConfigGS.minCreateGold);
    }
  }
}
