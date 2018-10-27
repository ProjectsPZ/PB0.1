
using Core.models.room;
using Core.server;
using System.Collections.Generic;

namespace Game.global.serverpacket
{
  public class ROOM_CHANGE_SLOTS_PAK : SendPacket
  {
    private int _type;
    private int _leader;
    private List<SLOT_CHANGE> _slots;

    public ROOM_CHANGE_SLOTS_PAK(List<SLOT_CHANGE> slots, int leader, int type)
    {
      this._slots = slots;
      this._leader = leader;
      this._type = type;
    }

    public override void write()
    {
      this.writeH((short) 3877);
      this.writeC((byte) this._type);
      this.writeC((byte) this._leader);
      this.writeC((byte) this._slots.Count);
      for (int index = 0; index < this._slots.Count; ++index)
      {
        SLOT_CHANGE slot = this._slots[index];
        this.writeC((byte) slot.oldSlot._id);
        this.writeC((byte) slot.newSlot._id);
        this.writeC((byte) slot.oldSlot.state);
        this.writeC((byte) slot.newSlot.state);
      }
    }
  }
}
