
using Core.server;

namespace Game.global.serverpacket
{
  public class AUTH_JACKPOT_NOTICE_PAK : SendPacket
  {
    private string _w;
    private int cupomId;
    private int _random;

    public AUTH_JACKPOT_NOTICE_PAK(string winner, int cupom, int rnd)
    {
      this._w = winner;
      this.cupomId = cupom;
      this._random = rnd;
    }

    public override void write()
    {
      this.writeH((short) 557);
      this.writeC((byte) (this._w.Length + 1));
      this.writeS(this._w, this._w.Length + 1);
      this.writeD(this.cupomId);
      this.writeC((byte) this._random);
    }
  }
}
