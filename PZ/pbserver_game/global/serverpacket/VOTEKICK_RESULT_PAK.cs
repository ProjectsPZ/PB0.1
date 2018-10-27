
using Core.models.room;
using Core.server;

namespace Game.global.serverpacket
{
  public class VOTEKICK_RESULT_PAK : SendPacket
  {
    private VoteKick vote;
    private uint erro;

    public VOTEKICK_RESULT_PAK(uint erro, VoteKick vote)
    {
      this.erro = erro;
      this.vote = vote;
    }

    public override void write()
    {
      this.writeH((short) 3403);
      this.writeC((byte) this.vote.victimIdx);
      this.writeC((byte) this.vote.kikar);
      this.writeC((byte) this.vote.deixar);
      this.writeD(this.erro);
    }
  }
}
