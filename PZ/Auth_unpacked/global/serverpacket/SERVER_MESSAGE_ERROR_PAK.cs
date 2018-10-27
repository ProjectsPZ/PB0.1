
using Core.server;

namespace Auth.global.serverpacket
{
  public class SERVER_MESSAGE_ERROR_PAK : SendPacket
  {
    private uint _er;

    public SERVER_MESSAGE_ERROR_PAK(uint er)
    {
      this._er = er;
    }

    public override void write()
    {
      this.writeH((short) 2054);
      this.writeD(this._er);
    }
  }
}
