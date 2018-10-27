
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CHANGE_MAX_PLAYERS_PAK : SendPacket
  {
    private int _max;

    public CLAN_CHANGE_MAX_PLAYERS_PAK(int max)
    {
      this._max = max;
    }

    public override void write()
    {
      this.writeH((short) 1377);
      this.writeC((byte) this._max);
    }
  }
}
