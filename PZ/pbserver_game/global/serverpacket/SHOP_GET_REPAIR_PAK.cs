
using Core.server;

namespace Game.global.serverpacket
{
  public class SHOP_GET_REPAIR_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 559);
      this.writeD(0);
      this.writeD(0);
      this.writeD(0);
      this.writeD(44);
    }
  }
}
