
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_WAR_ACCEPTED_BATTLE_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_WAR_ACCEPTED_BATTLE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1559);
      this.writeD(this._erro);
    }
  }
}
