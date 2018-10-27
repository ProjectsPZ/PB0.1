
using Core;
using Core.models.enums;
using Core.models.room;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Game.global.clientpacket
{
  public class ROOM_CHANGE_SLOT_REC : ReceiveGamePacket
  {
    private int teamIdx;

    public ROOM_CHANGE_SLOT_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.teamIdx = this.readD();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        Room room = player == null ? (Room) null : player._room;
        if (this.teamIdx >= 2 || room == null || !(player.LastSlotChange == new DateTime()) && (DateTime.Now - player.LastSlotChange).TotalSeconds < 1.5 || room.changingSlots)
          return;
        SLOT slot = room.getSlot(player._slotId);
        if (slot == null || this.teamIdx == slot._team || slot.state != SLOT_STATE.NORMAL)
          return;
        player.LastSlotChange = DateTime.Now;
        Monitor.Enter((object) room._slots);
        room.changingSlots = true;
        List<SLOT_CHANGE> slots = new List<SLOT_CHANGE>();
        room.SwitchNewSlot(slots, player, slot, this.teamIdx);
        if (slots.Count > 0)
        {
          using (ROOM_CHANGE_SLOTS_PAK roomChangeSlotsPak = new ROOM_CHANGE_SLOTS_PAK(slots, room._leader, 0))
            room.SendPacketToPlayers((SendPacket) roomChangeSlotsPak);
        }
        room.changingSlots = false;
        Monitor.Exit((object) room._slots);
      }
      catch (Exception ex)
      {
        Logger.warning("[ROOM_CHANGE_SLOT_REC] " + ex.ToString());
      }
    }
  }
}
