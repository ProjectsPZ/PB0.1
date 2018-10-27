
using Core.server;

namespace Game.global.serverpacket
{
  public class VOTEKICK_UPDATE_RESULT_PAK : SendPacket
  {
    private uint erro;

    public VOTEKICK_UPDATE_RESULT_PAK(uint erro)
    {
      this.erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 3401);
      this.writeD(this.erro);
    }
  }
}
