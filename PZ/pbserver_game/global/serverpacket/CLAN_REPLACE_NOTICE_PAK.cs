
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_REPLACE_NOTICE_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_REPLACE_NOTICE_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1363);
      this.writeD(this._erro);
    }
  }
}
