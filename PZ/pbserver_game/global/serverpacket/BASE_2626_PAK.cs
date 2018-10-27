
using Core.server;
using Game.data.model;
using System;

namespace Game.global.serverpacket
{
  public class BASE_2626_PAK : SendPacket
  {
    private Account p;

    public BASE_2626_PAK(Account player)
    {
      this.p = player;
    }

    public override void write()
    {
      this.writeH((short) 2626);
      this.writeB(BitConverter.GetBytes(this.p.player_id), 0, 4);
      this.writeQ(this.p._titles.Flags);
      this.writeC((byte) this.p._titles.Equiped1);
      this.writeC((byte) this.p._titles.Equiped2);
      this.writeC((byte) this.p._titles.Equiped3);
      this.writeD(this.p._titles.Slots);
    }
  }
}
