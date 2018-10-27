
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BASE_QUEST_UPDATE_INFO_PAK : SendPacket
  {
    private Account p;

    public BASE_QUEST_UPDATE_INFO_PAK(Account p)
    {
      this.p = p;
    }

    public override void write()
    {
      this.writeH((short) 2604);
      if (this.p != null)
      {
        this.writeQ(this.p.player_id);
        this.writeD(this.p.brooch);
        this.writeD(this.p.insignia);
        this.writeD(this.p.medal);
        this.writeD(this.p.blue_order);
      }
      else
        this.writeB(new byte[24]);
    }
  }
}
