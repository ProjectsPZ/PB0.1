
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_WAR_LEAVE_TEAM_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_WAR_LEAVE_TEAM_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1551);
      this.writeD(this._erro);
    }
  }
}
