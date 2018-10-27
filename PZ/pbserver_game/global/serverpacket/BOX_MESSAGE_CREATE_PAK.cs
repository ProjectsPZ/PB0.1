
using Core.server;

namespace Game.global.serverpacket
{
  public class BOX_MESSAGE_CREATE_PAK : SendPacket
  {
    private uint _erro;

    public BOX_MESSAGE_CREATE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 418);
      this.writeD(this._erro);
    }
  }
}
