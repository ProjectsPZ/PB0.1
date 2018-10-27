
using Core.server;

namespace Game.global.serverpacket
{
  public class ROOM_GET_NICKNAME_PAK : SendPacket
  {
    private int slotIdx;
    private int color;
    private string name;

    public ROOM_GET_NICKNAME_PAK(int slot, string name, int color)
    {
      this.slotIdx = slot;
      this.name = name;
      this.color = color;
    }

    public override void write()
    {
      this.writeH((short) 3844);
      this.writeD(this.slotIdx);
      if (this.slotIdx < 0)
        return;
      this.writeS(this.name, 33);
      this.writeC((byte) this.color);
    }
  }
}
