
using Core.server;

namespace Game.global.serverpacket
{
  public class HELPER_PAK : SendPacket
  {
    private ushort _packet;

    public HELPER_PAK(ushort packet)
    {
      this._packet = packet;
    }

    public override void write()
    {
      this.writeH(this._packet);
      this.writeD(0);
      this.writeC((byte) 1);
    }
  }
}
