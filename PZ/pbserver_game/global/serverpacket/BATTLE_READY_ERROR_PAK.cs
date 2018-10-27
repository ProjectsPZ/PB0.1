
using Core.server;

namespace Game.global.serverpacket
{
  public class BATTLE_READY_ERROR_PAK : SendPacket
  {
    private uint _erro;

    public BATTLE_READY_ERROR_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 3332);
      this.writeD(this._erro);
    }
  }
}
