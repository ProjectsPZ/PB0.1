
using Core.server;

namespace Game.global.serverpacket
{
  public class SERVER_MESSAGE_ITEM_RECEIVE_PAK : SendPacket
  {
    private uint _er;

    public SERVER_MESSAGE_ITEM_RECEIVE_PAK(uint er)
    {
      this._er = er;
    }

    public override void write()
    {
      this.writeH((short) 2692);
      this.writeD(this._er);
    }
  }
}
