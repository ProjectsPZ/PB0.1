
using Core.models.room;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;

namespace Game.data.chat
{
  public static class GetRoomInfo
  {
    public static string GetSlotStats(string str, Account player, Room room)
    {
      int slotIdx = int.Parse(str.Substring(5)) - 1;
      string str1 = "Informações:";
      if (room == null)
        return "Sala inválida. [Servidor]";
      SLOT slot = room.getSlot(slotIdx);
      if (slot == null)
        return "Slot inválido. [Servidor]";
      string msg = str1 + "\nIndex: " + (object) slot._id + "\nTeam: " + (object) slot._team + "\nFlag: " + (object) slot._flag + "\nAccountId: " + (object) slot._playerId + "\nState: " + (object) slot.state + "\nMissions: " + (slot.Missions != null ? "Valido" : "Null");
      player.SendPacket((SendPacket) new SERVER_MESSAGE_ANNOUNCE_PAK(msg));
      return "Logs do slot geradas com sucesso. [Servidor]";
    }
  }
}
