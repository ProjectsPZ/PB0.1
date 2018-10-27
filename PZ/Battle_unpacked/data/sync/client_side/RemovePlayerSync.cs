
using Battle.data.models;
using Battle.network;

namespace Battle.data.sync.client_side
{
  public static class RemovePlayerSync
  {
    public static void Load(ReceivePacket p)
    {
      uint UniqueRoomId = p.readUD();
      int gen2 = p.readD();
      int slot = (int) p.readC();
      int num = (int) p.readC();
      Room room = RoomsManager.getRoom(UniqueRoomId, gen2);
      if (room == null)
        return;
      if (num == 0)
      {
        RoomsManager.RemoveRoom(UniqueRoomId);
      }
      else
      {
        Player player = room.getPlayer(slot, false);
        if (player != null)
          player.ResetAllInfos();
      }
    }
  }
}
