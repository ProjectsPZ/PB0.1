
using Core.server;

namespace Game.global.serverpacket
{
  public class BATTLE_HACK_DETECTED_PAK : SendPacket
  {
    private int slotId;

    public BATTLE_HACK_DETECTED_PAK(int slot)
    {
      this.slotId = slot;
    }

    public override void write()
    {
      this.writeH((short) 3413);
      this.writeC((byte) this.slotId);
      this.writeC((byte) 1);
      this.writeD(1);
    }
  }
}
