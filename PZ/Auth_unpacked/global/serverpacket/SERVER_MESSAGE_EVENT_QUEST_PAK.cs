
using Core.server;

namespace Auth.global.serverpacket
{
  public class SERVER_MESSAGE_EVENT_QUEST_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2061);
    }
  }
}
