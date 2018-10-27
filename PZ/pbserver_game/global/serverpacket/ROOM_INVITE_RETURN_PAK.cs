
using Core.server;

namespace Game.global.serverpacket
{
  public class ROOM_INVITE_RETURN_PAK : SendPacket
  {
    private uint _erro;

    public ROOM_INVITE_RETURN_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 3885);
      this.writeD(this._erro);
    }
  }
}
