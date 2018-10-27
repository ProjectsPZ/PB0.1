
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_TITLE_USE_PAK : SendPacket
  {
    private uint _erro;

    public BASE_TITLE_USE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 2622);
      this.writeD(this._erro);
    }
  }
}
