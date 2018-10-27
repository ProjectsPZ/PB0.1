
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CREATE_INVITE_PAK : SendPacket
  {
    private int _clanId;
    private uint _erro;

    public CLAN_CREATE_INVITE_PAK(uint erro, int clanId)
    {
      this._erro = erro;
      this._clanId = clanId;
    }

    public override void write()
    {
      this.writeH((short) 1317);
      this.writeD(this._erro);
      if (this._erro != 0U)
        return;
      this.writeD(this._clanId);
    }
  }
}
