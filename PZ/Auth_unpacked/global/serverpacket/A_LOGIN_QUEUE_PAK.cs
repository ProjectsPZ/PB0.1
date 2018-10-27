
using Core.server;

namespace Auth.global.serverpacket
{
  public class A_LOGIN_QUEUE_PAK : SendPacket
  {
    private int queue_pos;
    private int estimated_time;

    public A_LOGIN_QUEUE_PAK(int queue_pos, int estimated_time)
    {
      this.queue_pos = queue_pos;
      this.estimated_time = estimated_time;
    }

    public override void write()
    {
      this.writeH((short) 2676);
      this.writeD(this.queue_pos);
      this.writeD(this.estimated_time);
    }
  }
}
