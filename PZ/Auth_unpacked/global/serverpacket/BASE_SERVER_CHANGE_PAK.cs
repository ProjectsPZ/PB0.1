
using Core.server;

namespace Auth.global.serverpacket
{
  public class BASE_SERVER_CHANGE_PAK : SendPacket
  {
    private int erro;

    public BASE_SERVER_CHANGE_PAK(int erro)
    {
      this.erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 2578);
      this.writeD(this.erro);
    }
  }
}
