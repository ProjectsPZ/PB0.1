
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_MSG_FOR_PLAYERS_PAK : SendPacket
  {
    private int playersCount;

    public CLAN_MSG_FOR_PLAYERS_PAK(int count)
    {
      this.playersCount = count;
    }

    public override void write()
    {
      this.writeH((short) 1397);
      this.writeD(this.playersCount);
    }
  }
}
