
using Core.server;
using System;

namespace Game.global.serverpacket
{
  public class CLAN_WAR_PARTY_CONTEXT_PAK : SendPacket
  {
    private int matchCount;

    public CLAN_WAR_PARTY_CONTEXT_PAK(int count)
    {
      this.matchCount = count;
    }

    public override void write()
    {
      this.writeH((short) 1539);
      this.writeC((byte) this.matchCount);
      this.writeC((byte) 13);
      this.writeC((byte) Math.Ceiling((double) this.matchCount / 13.0));
    }
  }
}
