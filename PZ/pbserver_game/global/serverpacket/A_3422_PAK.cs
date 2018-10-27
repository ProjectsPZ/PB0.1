
using Core.server;

namespace Game.global.serverpacket
{
  public class A_3422_PAK : SendPacket
  {
    private uint erro;

    public A_3422_PAK(uint erro)
    {
      this.erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 3422);
      this.writeD(this.erro);
      if (this.erro != 0U)
        return;
      this.writeD(1);
    }
  }
}
