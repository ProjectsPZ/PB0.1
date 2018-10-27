
using Core.server;

namespace Game.global.serverpacket
{
  public class AUTH_ACCOUNT_KICK_PAK : SendPacket
  {
    private int _type;

    public AUTH_ACCOUNT_KICK_PAK(int type)
    {
      this._type = type;
    }

    public override void write()
    {
      this.writeH((short) 513);
      this.writeC((byte) this._type);
    }
  }
}
