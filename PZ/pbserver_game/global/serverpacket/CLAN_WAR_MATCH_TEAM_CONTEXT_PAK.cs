
using Core.server;
using System;

namespace Game.global.serverpacket
{
  public class CLAN_WAR_MATCH_TEAM_CONTEXT_PAK : SendPacket
  {
    private int count;

    public CLAN_WAR_MATCH_TEAM_CONTEXT_PAK(int count)
    {
      this.count = count;
    }

    public override void write()
    {
      this.writeH((short) 1543);
      this.writeH((short) this.count);
      this.writeC((byte) 13);
      this.writeH((short) Math.Ceiling((double) this.count / 13.0));
    }
  }
}
