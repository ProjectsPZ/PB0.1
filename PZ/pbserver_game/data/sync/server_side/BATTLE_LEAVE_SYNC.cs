﻿
using Core.models.enums;
using Core.server;
using Game.data.model;

namespace Game.data.sync.server_side
{
  public class BATTLE_LEAVE_SYNC
  {
    public static void SendUDPPlayerLeave(Room room, int slotId)
    {
      if (room == null)
        return;
      int playingPlayers = room.getPlayingPlayers(2, SLOT_STATE.BATTLE, 0, slotId);
      using (SendGPacket sendGpacket = new SendGPacket())
      {
        sendGpacket.writeH((short) 2);
        sendGpacket.writeD(room.UniqueRoomId);
        sendGpacket.writeD(room.mapId * 16 + (int) room.room_type);
        sendGpacket.writeC((byte) slotId);
        sendGpacket.writeC((byte) playingPlayers);
        Game_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), room.UDPServer.Connection);
      }
    }
  }
}
