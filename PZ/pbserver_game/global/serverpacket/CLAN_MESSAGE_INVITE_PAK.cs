
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_MESSAGE_INVITE_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_MESSAGE_INVITE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1393);
      this.writeD(this._erro);
    }
  }
}
