﻿
using Core.server;

namespace Game.global.serverpacket
{
  public class A_2061_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2061);
    }
  }
}
