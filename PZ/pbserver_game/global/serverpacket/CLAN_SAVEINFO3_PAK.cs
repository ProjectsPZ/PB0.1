
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_SAVEINFO3_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_SAVEINFO3_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1373);
      this.writeD(this._erro);
    }
  }
}
