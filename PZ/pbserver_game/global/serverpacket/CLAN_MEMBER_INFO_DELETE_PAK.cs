
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_MEMBER_INFO_DELETE_PAK : SendPacket
  {
    private long _pId;

    public CLAN_MEMBER_INFO_DELETE_PAK(long pId)
    {
      this._pId = pId;
    }

    public override void write()
    {
      this.writeH((short) 1353);
      this.writeQ(this._pId);
    }
  }
}
