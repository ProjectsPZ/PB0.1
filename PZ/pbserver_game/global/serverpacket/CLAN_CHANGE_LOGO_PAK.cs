
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CHANGE_LOGO_PAK : SendPacket
  {
    private uint _logo;

    public CLAN_CHANGE_LOGO_PAK(uint logo)
    {
      this._logo = logo;
    }

    public override void write()
    {
      this.writeH((short) 1371);
      this.writeD(this._logo);
    }
  }
}
