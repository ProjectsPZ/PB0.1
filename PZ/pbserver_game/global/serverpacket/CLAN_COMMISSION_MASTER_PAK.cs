
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_COMMISSION_MASTER_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_COMMISSION_MASTER_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1338);
      this.writeD(this._erro);
    }
  }
}
