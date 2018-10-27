
using Core.server;

namespace Auth.global.serverpacket
{
  public class SERVER_MESSAGE_EVENT_RANKUP_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2616);
    }
  }
}
