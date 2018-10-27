
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_WAR_MATCH_UPTIME_PAK : SendPacket
  {
    private int _f;
    private uint _erro;

    public CLAN_WAR_MATCH_UPTIME_PAK(uint erro, int formacao = 0)
    {
      this._erro = erro;
      this._f = formacao;
    }

    public override void write()
    {
      this.writeH((short) 1572);
      this.writeD(this._erro);
      if (this._erro != 0U)
        return;
      this.writeC((byte) this._f);
    }
  }
}
