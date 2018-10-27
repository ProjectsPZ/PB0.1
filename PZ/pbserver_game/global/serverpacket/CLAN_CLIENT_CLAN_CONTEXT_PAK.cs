
using Core.server;
using System;

namespace Game.global.serverpacket
{
  public class CLAN_CLIENT_CLAN_CONTEXT_PAK : SendPacket
  {
    private int clansCount;

    public CLAN_CLIENT_CLAN_CONTEXT_PAK(int count)
    {
      this.clansCount = count;
    }

    public override void write()
    {
      this.writeH((short) 1452);
      this.writeD(this.clansCount);
      this.writeC((byte) 170);
      this.writeH((ushort) Math.Ceiling((double) this.clansCount / 170.0));
      this.writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
    }
  }
}
