
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_ROOM_INVITE_RESULT_PAK : SendPacket
  {
    private long _pId;

    public CLAN_ROOM_INVITE_RESULT_PAK(long pId)
    {
      this._pId = pId;
    }

    public override void write()
    {
      this.writeH((short) 1383);
      this.writeQ(this._pId);
    }
  }
}
