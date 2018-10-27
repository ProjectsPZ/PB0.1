
using Core;
using Core.models.enums;
using Core.models.room;
using Game.data.model;
using Game.data.utils;
using System;

namespace Game.global.clientpacket
{
  public class BATTLE_LOADING_REC : ReceiveGamePacket
  {
    private string name;

    public BATTLE_LOADING_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.name = this.readS((int) this.readC());
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Room room = player._room;
        SLOT slot;
        if (room == null || !room.isPreparing() || (!room.getSlot(player._slotId, out slot) || slot.state != SLOT_STATE.LOAD))
          return;
        slot.preLoadDate = DateTime.Now;
        room.StartCounter(0, player, slot);
        room.changeSlotState(slot, SLOT_STATE.RENDEZVOUS, true);
        room._mapName = this.name;
        if (slot._id != room._leader)
          return;
        AllUtils.LogRoomBattleStart(room);
        room._state = RoomState.Rendezvous;
        room.updateRoomInfo();
      }
      catch (Exception ex)
      {
        Logger.info("BATTLE_LOADING_REC: " + ex.ToString());
      }
    }
  }
}
