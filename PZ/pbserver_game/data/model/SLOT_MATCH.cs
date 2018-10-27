
using Core.models.enums.match;

namespace Game.data.model
{
  public class SLOT_MATCH
  {
    public SlotMatchState state;
    public long _playerId;
    public long _id;

    public SLOT_MATCH(int slot)
    {
      this._id = (long) slot;
    }
  }
}
