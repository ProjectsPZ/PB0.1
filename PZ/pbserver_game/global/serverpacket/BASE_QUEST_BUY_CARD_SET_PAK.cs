
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class BASE_QUEST_BUY_CARD_SET_PAK : SendPacket
  {
    private Account player;
    private uint _erro;

    public BASE_QUEST_BUY_CARD_SET_PAK(uint erro, Account p)
    {
      this._erro = erro;
      this.player = p;
    }

    public override void write()
    {
      this.writeH((short) 2606);
      this.writeD(this._erro);
      if (this._erro != 0U)
        return;
      this.writeD(this.player._gp);
      this.writeC((byte) this.player._mission.actualMission);
      this.writeC((byte) this.player._mission.actualMission);
      this.writeC((byte) this.player._mission.card1);
      this.writeC((byte) this.player._mission.card2);
      this.writeC((byte) this.player._mission.card3);
      this.writeC((byte) this.player._mission.card4);
      this.writeB(ComDiv.getCardFlags(this.player._mission.mission1, this.player._mission.list1));
      this.writeB(ComDiv.getCardFlags(this.player._mission.mission2, this.player._mission.list2));
      this.writeB(ComDiv.getCardFlags(this.player._mission.mission3, this.player._mission.list3));
      this.writeB(ComDiv.getCardFlags(this.player._mission.mission4, this.player._mission.list4));
      this.writeC((byte) this.player._mission.mission1);
      this.writeC((byte) this.player._mission.mission2);
      this.writeC((byte) this.player._mission.mission3);
      this.writeC((byte) this.player._mission.mission4);
    }
  }
}
