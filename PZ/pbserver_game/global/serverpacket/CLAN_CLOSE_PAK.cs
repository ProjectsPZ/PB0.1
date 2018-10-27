
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CLOSE_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_CLOSE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1313);
      this.writeD(this._erro);
    }
  }
}
