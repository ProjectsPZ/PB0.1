
using Core.server;

namespace Game.global.serverpacket
{
  public class AUTH_CHECK_NICKNAME_PAK : SendPacket
  {
    private uint _erro;

    public AUTH_CHECK_NICKNAME_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 549);
      this.writeD(this._erro);
    }
  }
}
