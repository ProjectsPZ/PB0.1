
using Core.server;

namespace Game.global.serverpacket
{
  public class FRIEND_INVITE_FOR_ROOM_PAK : SendPacket
  {
    private uint _erro;

    public FRIEND_INVITE_FOR_ROOM_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 276);
      this.writeD(this._erro);
    }
  }
}
