
using Core.server;

namespace Game.global.serverpacket
{
  public class VOTEKICK_CHECK_PAK : SendPacket
  {
    private uint _erro;

    public VOTEKICK_CHECK_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 3397);
      this.writeD(this._erro);
    }
  }
}
