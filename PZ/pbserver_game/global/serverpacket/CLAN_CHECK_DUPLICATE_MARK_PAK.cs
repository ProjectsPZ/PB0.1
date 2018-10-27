
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CHECK_DUPLICATE_MARK_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_CHECK_DUPLICATE_MARK_PAK(uint er)
    {
      this._erro = er;
    }

    public override void write()
    {
      this.writeH((short) 1361);
      this.writeD(this._erro);
    }
  }
}
