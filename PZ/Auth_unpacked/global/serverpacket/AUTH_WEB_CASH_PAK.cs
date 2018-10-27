
using Core.server;

namespace Auth.global.serverpacket
{
  public class AUTH_WEB_CASH_PAK : SendPacket
  {
    private int erro;
    private int gold;
    private int cash;

    public AUTH_WEB_CASH_PAK(int erro, int gold = 0, int cash = 0)
    {
      this.erro = erro;
      this.gold = gold;
      this.cash = cash;
    }

    public override void write()
    {
      this.writeH((short) 545);
      this.writeD(this.erro);
      if (this.erro < 0)
        return;
      this.writeD(this.gold);
      this.writeD(this.cash);
    }
  }
}
