
using Core.models.room;
using Core.server;

namespace Game.global.serverpacket
{
  public class VOTEKICK_UPDATE_PAK : SendPacket
  {
    private VoteKick _k;

    public VOTEKICK_UPDATE_PAK(VoteKick vote)
    {
      this._k = vote;
    }

    public override void write()
    {
      this.writeH((short) 3407);
      this.writeC((byte) this._k.kikar);
      this.writeC((byte) this._k.deixar);
    }
  }
}
