
using Core.models.room;
using Core.server;

namespace Game.global.serverpacket
{
  public class VOTEKICK_START_PAK : SendPacket
  {
    private VoteKick vote;

    public VOTEKICK_START_PAK(VoteKick vote)
    {
      this.vote = vote;
    }

    public override void write()
    {
      this.writeH((short) 3399);
      this.writeC((byte) this.vote.creatorIdx);
      this.writeC((byte) this.vote.victimIdx);
      this.writeC((byte) this.vote.motive);
    }
  }
}
