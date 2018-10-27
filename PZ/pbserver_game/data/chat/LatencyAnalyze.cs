
using Core;
using Core.models.enums;
using Game.data.model;

namespace Game.data.chat
{
  public static class LatencyAnalyze
  {
    public static string StartAnalyze(Account player, Room room)
    {
      if (room == null)
        return Translation.GetLabel("GeneralRoomInvalid");
      if (room.getSlot(player._slotId).state != SLOT_STATE.BATTLE)
        return Translation.GetLabel("LatencyInfoError");
      player.DebugPing = !player.DebugPing;
      if (player.DebugPing)
        return Translation.GetLabel("LatencyInfoOn");
      return Translation.GetLabel("LatencyInfoOff");
    }
  }
}
