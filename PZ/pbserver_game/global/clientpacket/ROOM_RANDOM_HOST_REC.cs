
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
  internal class ROOM_RANDOM_HOST_REC : ReceiveGamePacket
  {
    private List<SLOT> slots = new List<SLOT>();
    private uint erro;

    public ROOM_RANDOM_HOST_REC(GameClient client, byte[] data)
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
        if (room != null && room._leader == player._slotId && room._state == RoomState.Ready)
        {
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
            this.erro = room.getPlayerBySlot(slot) != null ? (uint) slot._id : 2147483648U;
            this.slots = (List<SLOT>) null;
          }
          else
            this.erro = 2147483648U;
        }
        else
          this.erro = 2147483648U;
        this._client.SendPacket((SendPacket) new ROOM_NEW_HOST_PAK(this.erro));
      }
      catch (Exception ex)
      {
        Logger.info("ROOM_RANDOM_HOST_REC: " + ex.ToString());
      }
    }
  }
}
