
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_CHAT_ERROR_PAK : SendPacket
  {
    private int erro;
    private int banTime;

    public BASE_CHAT_ERROR_PAK(int erro, int time = 0)
    {
      this.erro = erro;
      this.banTime = time;
    }

    public override void write()
    {
      this.writeH((short) 2628);
      this.writeC((byte) this.erro);
      if (this.erro <= 0)
        return;
      this.writeD(this.banTime);
    }
  }
}
