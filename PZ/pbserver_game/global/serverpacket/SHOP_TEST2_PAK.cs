
using Core.server;

namespace Game.global.serverpacket
{
  public class SHOP_TEST2_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 567);
      this.writeD(0);
      this.writeD(0);
      this.writeD(0);
      this.writeD(44);
    }
  }
}
