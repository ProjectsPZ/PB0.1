
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CLIENT_CLAN_LIST_PAK : SendPacket
  {
    private uint _page;
    private int _count;
    private byte[] _array;

    public CLAN_CLIENT_CLAN_LIST_PAK(uint page, int count, byte[] array)
    {
      this._page = page;
      this._count = count;
      this._array = array;
    }

    public override void write()
    {
      this.writeH((short) 1446);
      this.writeD(this._page);
      this.writeC((byte) this._count);
      this.writeB(this._array);
    }
  }
}
