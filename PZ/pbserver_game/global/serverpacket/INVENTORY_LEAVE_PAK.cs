
using Core.server;

namespace Game.global.serverpacket
{
  public class INVENTORY_LEAVE_PAK : SendPacket
  {
    private int erro;
    private int type;

    public INVENTORY_LEAVE_PAK(int erro, int type = 0)
    {
      this.erro = erro;
      this.type = type;
    }

    public override void write()
    {
      this.writeH((short) 3590);
      this.writeD(this.erro);
      if (this.erro >= 0)
        return;
      this.writeD(this.type);
    }
  }
}
