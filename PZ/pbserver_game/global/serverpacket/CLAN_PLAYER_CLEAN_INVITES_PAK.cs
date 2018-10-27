
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_PLAYER_CLEAN_INVITES_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_PLAYER_CLEAN_INVITES_PAK(uint error)
    {
      this._erro = error;
    }

    public override void write()
    {
      this.writeH((short) 1319);
      this.writeD(this._erro);
    }
  }
}
