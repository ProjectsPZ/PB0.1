
using Core.server;
using System;

namespace Game.global.serverpacket
{
  public class INVENTORY_ENTER_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 3586);
      this.writeD(uint.Parse(DateTime.Now.ToString("yyMMddHHmm")));
    }
  }
}
