
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_TITLE_DETACH_PAK : SendPacket
  {
    private uint _erro;

    public BASE_TITLE_DETACH_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 2624);
      this.writeD(this._erro);
    }
  }
}
