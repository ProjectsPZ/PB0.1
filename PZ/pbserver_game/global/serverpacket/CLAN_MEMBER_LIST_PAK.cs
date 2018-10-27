
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_MEMBER_LIST_PAK : SendPacket
  {
    private byte[] array;
    private int erro;
    private int page;
    private int count;

    public CLAN_MEMBER_LIST_PAK(int page, int count, byte[] array)
    {
      this.page = page;
      this.count = count;
      this.array = array;
    }

    public CLAN_MEMBER_LIST_PAK(int erro)
    {
      this.erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1309);
      this.writeD(this.erro);
      if (this.erro < 0)
        return;
      this.writeC((byte) this.page);
      this.writeC((byte) this.count);
      this.writeB(this.array);
    }
  }
}
