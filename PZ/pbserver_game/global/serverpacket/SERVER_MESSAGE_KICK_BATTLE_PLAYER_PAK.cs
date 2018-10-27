
using Core.models.enums.errors;
using Core.server;

namespace Game.global.serverpacket
{
  public class SERVER_MESSAGE_KICK_BATTLE_PLAYER_PAK : SendPacket
  {
    private EventErrorEnum _error;

    public SERVER_MESSAGE_KICK_BATTLE_PLAYER_PAK(EventErrorEnum error)
    {
      this._error = error;
    }

    public override void write()
    {
      this.writeH((short) 2052);
      this.writeD((uint) this._error);
    }
  }
}
