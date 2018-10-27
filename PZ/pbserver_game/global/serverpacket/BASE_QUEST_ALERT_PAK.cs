
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BASE_QUEST_ALERT_PAK : SendPacket
  {
    private Account p;
    private uint erro;
    private int type;

    public BASE_QUEST_ALERT_PAK(uint erro, int type, Account p)
    {
      this.erro = erro;
      this.type = type;
      this.p = p;
    }

    public override void write()
    {
      this.writeH((short) 2602);
      this.writeD(this.erro);
      this.writeC((byte) this.type);
      if (((int) this.erro & 1) != 1)
        return;
      this.writeD(this.p._exp);
      this.writeD(this.p._gp);
      this.writeD(this.p.brooch);
      this.writeD(this.p.insignia);
      this.writeD(this.p.medal);
      this.writeD(this.p.blue_order);
      this.writeD(this.p._rank);
    }
  }
}
