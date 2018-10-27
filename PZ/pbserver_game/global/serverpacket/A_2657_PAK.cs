
using Core.server;
using System;

namespace Game.global.serverpacket
{
  public class A_2657_PAK : SendPacket
  {
    private ushort ResetDate;

    public A_2657_PAK(DateTime ResetDate)
    {
      this.ResetDate = ushort.Parse(ResetDate.ToString("HHmm"));
    }

    public override void write()
    {
      this.writeH((short) 2657);
      this.writeH((short) 1);
      this.writeH((short) 2);
      this.writeH((short) 3);
      this.writeH(this.ResetDate);
      this.writeH((short) 10);
      this.writeH((short) 20);
      this.writeH((short) 30);
    }
  }
}
