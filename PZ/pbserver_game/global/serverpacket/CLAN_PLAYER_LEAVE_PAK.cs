
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_PLAYER_LEAVE_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_PLAYER_LEAVE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1333);
      this.writeD(this._erro);
    }
  }
}
