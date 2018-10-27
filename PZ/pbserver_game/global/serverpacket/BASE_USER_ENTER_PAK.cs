
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_USER_ENTER_PAK : SendPacket
  {
    private uint _erro;

    public BASE_USER_ENTER_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 2580);
      this.writeD(this._erro);
    }
  }
}
