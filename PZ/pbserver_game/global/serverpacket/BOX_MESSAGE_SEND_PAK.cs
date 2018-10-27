
using Core.server;

namespace Game.global.serverpacket
{
  public class BOX_MESSAGE_SEND_PAK : SendPacket
  {
    private uint _erro;

    public BOX_MESSAGE_SEND_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 441);
      this.writeD(this._erro);
    }
  }
}
