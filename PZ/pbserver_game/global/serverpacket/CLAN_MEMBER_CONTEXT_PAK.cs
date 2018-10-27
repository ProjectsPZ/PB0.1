
using Core.server;
using System;

namespace Game.global.serverpacket
{
  public class CLAN_MEMBER_CONTEXT_PAK : SendPacket
  {
    private int erro;
    private int playersCount;

    public CLAN_MEMBER_CONTEXT_PAK(int erro, int playersCount)
    {
      this.erro = erro;
      this.playersCount = playersCount;
    }

    public CLAN_MEMBER_CONTEXT_PAK(int erro)
    {
      this.erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1307);
      this.writeD(this.erro);
      if (this.erro != 0)
        return;
      this.writeC((byte) this.playersCount);
      this.writeC((byte) 14);
      this.writeC((byte) Math.Ceiling((double) this.playersCount / 14.0));
      this.writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
    }
  }
}
