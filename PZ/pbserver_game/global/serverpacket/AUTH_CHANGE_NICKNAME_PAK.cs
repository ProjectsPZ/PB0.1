
using Core.server;

namespace Game.global.serverpacket
{
  public class AUTH_CHANGE_NICKNAME_PAK : SendPacket
  {
    private string name;

    public AUTH_CHANGE_NICKNAME_PAK(string name)
    {
      this.name = name;
    }

    public override void write()
    {
      this.writeH((short) 300);
      this.writeC((byte) this.name.Length);
      this.writeS(this.name, this.name.Length);
    }
  }
}
