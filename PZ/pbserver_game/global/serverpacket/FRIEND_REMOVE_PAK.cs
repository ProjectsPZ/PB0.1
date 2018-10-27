
using Core.server;

namespace Game.global.serverpacket
{
  public class FRIEND_REMOVE_PAK : SendPacket
  {
    private uint _erro;

    public FRIEND_REMOVE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 285);
      this.writeD(this._erro);
    }
  }
}
