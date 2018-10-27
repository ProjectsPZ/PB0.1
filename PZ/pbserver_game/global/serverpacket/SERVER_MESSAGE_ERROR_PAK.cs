
using Core.server;

namespace Game.global.serverpacket
{
  public class SERVER_MESSAGE_ERROR_PAK : SendPacket
  {
    private uint _erro;

    public SERVER_MESSAGE_ERROR_PAK(uint err)
    {
      this._erro = err;
    }

    public override void write()
    {
      this.writeH((short) 2054);
      this.writeD(this._erro);
    }
  }
}
