
using Core.server;

namespace Game.global.serverpacket
{
  public class LOBBY_LEAVE_PAK : SendPacket
  {
    private uint _erro;

    public LOBBY_LEAVE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 3084);
      this.writeD(this._erro);
    }
  }
}
