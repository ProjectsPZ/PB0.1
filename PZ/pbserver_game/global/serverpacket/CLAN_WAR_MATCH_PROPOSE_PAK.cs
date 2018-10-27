
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_WAR_MATCH_PROPOSE_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_WAR_MATCH_PROPOSE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1554);
      this.writeD(this._erro);
    }
  }
}
