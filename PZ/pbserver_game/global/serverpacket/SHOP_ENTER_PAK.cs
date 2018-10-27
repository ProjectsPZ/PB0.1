
using Core.server;
using System;

namespace Game.global.serverpacket
{
  public class SHOP_ENTER_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2820);
      this.writeD(uint.Parse(DateTime.Now.ToString("yyMMddHHmm")));
    }
  }
}
