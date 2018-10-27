
using Core.server;
using System;

namespace Game.global.serverpacket
{
  public class SHOP_LIST_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2822);
      this.writeD(uint.Parse(DateTime.Now.ToString("yyMMddHHmm")));
    }
  }
}
