
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_SERVER_PASSW_PAK : SendPacket
  {
    private uint _erro;

    public BASE_SERVER_PASSW_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 2645);
      this.writeD(this._erro);
    }
  }
}
