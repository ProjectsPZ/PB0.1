
using Core;
using Core.models.enums;
using Core.models.room;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
  internal class ROOM_RANDOM_HOST2_REC : ReceiveGamePacket
  {
    private List<SLOT> slots = new List<SLOT>();

    public ROOM_RANDOM_HOST2_REC(GameClient client, byte[] data)
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
        if (room == null || room._leader != player._slotId || room._state != RoomState.Ready)
          return;
        lock (room._slots)
        {
          for (int index = 0; index < 16; ++index)
          {
            SLOT slot = room._slots[index];
            if (slot._playerId > 0L && index != room._leader)
              this.slots.Add(slot);
          }
        }
        if (this.slots.Count > 0)
        {
          SLOT slot = this.slots[new Random().Next(this.slots.Count)];
          if (room.getPlayerBySlot(slot) != null)
          {
            room.setNewLeader(slot._id, 0, room._leader, false);
            using (ROOM_RANDOM_HOST_PAK roomRandomHostPak = new ROOM_RANDOM_HOST_PAK(slot._id))
              room.SendPacketToPlayers((SendPacket) roomRandomHostPak);
            room.updateSlotsInfo();
          }
          else
            this._client.SendPacket((SendPacket) new ROOM_RANDOM_HOST_PAK(2147483648U));
          this.slots = (List<SLOT>) null;
        }
        else
          this._client.SendPacket((SendPacket) new ROOM_RANDOM_HOST_PAK(2147483648U));
      }
      catch (Exception ex)
      {
        Logger.info("ROOM_RANDOM_HOST2_REC: " + ex.ToString());
      }
    }
  }
}
