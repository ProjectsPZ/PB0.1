
using Core.server;

namespace Game.global.serverpacket
{
  public class A_3424_PAK : SendPacket
  {
    private uint erro;

    public A_3424_PAK(uint erro)
    {
      this.erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 3424);
      this.writeD(this.erro);
    }
  }
}
