
using Core.server;
using System.Collections.Generic;

namespace Game.global.serverpacket
{
  public class BOX_MESSAGE_CHECK_READED_PAK : SendPacket
  {
    private List<int> msgs;

    public BOX_MESSAGE_CHECK_READED_PAK(List<int> msgs)
    {
      this.msgs = msgs;
    }

    public override void write()
    {
      this.writeH((short) 423);
      this.writeC((byte) this.msgs.Count);
      for (int index = 0; index < this.msgs.Count; ++index)
        this.writeD(this.msgs[index]);
    }
  }
}
