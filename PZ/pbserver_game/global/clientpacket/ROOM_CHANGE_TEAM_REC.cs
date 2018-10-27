
using Core;
using Core.models.enums;
using Core.models.room;
using Game.data.model;
using Game.data.utils;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Game.global.clientpacket
{
  public class ROOM_CHANGE_TEAM_REC : ReceiveGamePacket
  {
    private List<SLOT_CHANGE> changeList = new List<SLOT_CHANGE>();

    public ROOM_CHANGE_TEAM_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        Room room = player == null ? (Room) null : player._room;
        if (room == null || room._leader != player._slotId || (room._state != RoomState.Ready || room.changingSlots))
          return;
        Monitor.Enter((object) room._slots);
        room.changingSlots = true;
        foreach (int oldSlotId in room.RED_TEAM)
        {
          int newSlotId = oldSlotId + 1;
          if (oldSlotId == room._leader)
            room._leader = newSlotId;
          else if (newSlotId == room._leader)
            room._leader = oldSlotId;
          room.SwitchSlots(this.changeList, newSlotId, oldSlotId, true);
        }
        if (this.changeList.Count > 0)
        {
          using (ROOM_CHANGE_SLOTS_PAK roomChangeSlotsPak = new ROOM_CHANGE_SLOTS_PAK(this.changeList, room._leader, 2))
          {
            byte[] completeBytes = roomChangeSlotsPak.GetCompleteBytes("ROOM_CHANGE_TEAM_REC");
            foreach (Account allPlayer in room.getAllPlayers())
            {
              allPlayer._slotId = AllUtils.getNewSlotId(allPlayer._slotId);
              Logger.LogProblems("[ROOM_CHANGE_TEAM_REC] Jogador '" + (object) allPlayer.player_id + "' '" + allPlayer.player_name + "'; NewSlot: " + (object) allPlayer._slotId, "errorC");
              allPlayer.SendCompletePacket(completeBytes);
            }
          }
        }
        room.changingSlots = false;
        Monitor.Exit((object) room._slots);
      }
      catch (Exception ex)
      {
        Logger.info("ROOM_CHANGE_TEAM_REC: " + ex.ToString());
      }
    }
  }
}
