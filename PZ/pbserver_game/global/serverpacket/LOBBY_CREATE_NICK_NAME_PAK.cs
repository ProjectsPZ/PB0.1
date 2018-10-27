
using Core.server;

namespace Game.global.serverpacket
{
  public class LOBBY_CREATE_NICK_NAME_PAK : SendPacket
  {
    private uint _erro;

    public LOBBY_CREATE_NICK_NAME_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 3102);
      this.writeD(this._erro);
    }
  }
}
