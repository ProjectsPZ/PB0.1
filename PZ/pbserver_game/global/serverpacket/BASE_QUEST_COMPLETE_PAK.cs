
using Core.server;
using Core.xml;

namespace Game.global.serverpacket
{
  public class BASE_QUEST_COMPLETE_PAK : SendPacket
  {
    private int missionId;
    private int value;

    public BASE_QUEST_COMPLETE_PAK(int progress, Card card)
    {
      this.missionId = card._missionBasicId;
      if (card._missionLimit == progress)
        this.missionId += 240;
      this.value = progress;
    }

    public override void write()
    {
      this.writeH((short) 2600);
      this.writeC((byte) this.missionId);
      this.writeC((byte) this.value);
    }
  }
}
