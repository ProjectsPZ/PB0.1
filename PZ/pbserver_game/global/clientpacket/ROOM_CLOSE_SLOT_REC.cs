
using Core;
using Core.models.enums;
using Core.models.room;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class ROOM_CLOSE_SLOT_REC : ReceiveGamePacket
  {
    private int slotInfo;
    private uint erro;

    public ROOM_CLOSE_SLOT_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.slotInfo = this.readD();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        Room room = player == null ? (Room) null : player._room;
        if (room != null && room._leader == player._slotId)
        {
          SLOT slot = room.getSlot(this.slotInfo & 268435455);
          if (slot == null)
            return;
          if ((this.slotInfo & 268435456) == 268435456)
            this.OpenSlot(room, slot);
          else
            this.CloseSlot(room, slot);
        }
        else
          this.erro = 2147484673U;
        this._client.SendPacket((SendPacket) new ROOM_CLOSE_SLOT_PAK(this.erro));
      }
      catch (Exception ex)
      {
        Logger.warning("[ROOM_CLOSE_SLOT_REC] " + ex.ToString());
      }
    }

    private void CloseSlot(Room room, SLOT slot)
    {
      switch (slot.state)
      {
        case SLOT_STATE.EMPTY:
          room.changeSlotState(slot, SLOT_STATE.CLOSE, true);
          break;
        case SLOT_STATE.SHOP:
        case SLOT_STATE.INFO:
        case SLOT_STATE.CLAN:
        case SLOT_STATE.INVENTORY:
        case SLOT_STATE.OUTPOST:
        case SLOT_STATE.NORMAL:
        case SLOT_STATE.READY:
          Account playerBySlot = room.getPlayerBySlot(slot);
          if (playerBySlot == null || playerBySlot.AntiKickGM || (slot.state == SLOT_STATE.READY || (room._channelType != 4 || room._state == RoomState.CountDown) && room._channelType == 4) && (slot.state != SLOT_STATE.READY || (room._channelType != 4 || room._state != RoomState.Ready) && room._channelType == 4))
            break;
          playerBySlot.SendPacket((SendPacket) new SERVER_MESSAGE_KICK_PLAYER_PAK());
          room.RemovePlayer(playerBySlot, slot, false, 0);
          break;
      }
    }

    private void OpenSlot(Room room, SLOT slot)
    {
      if ((this.slotInfo & 268435456) != 268435456 || slot.state != SLOT_STATE.CLOSE)
        return;
      room.changeSlotState(slot, SLOT_STATE.EMPTY, true);
    }
  }
}
