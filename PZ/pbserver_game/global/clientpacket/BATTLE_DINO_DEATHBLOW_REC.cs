
using Core;
using Core.models.enums;
using Core.models.enums.missions;
using Core.models.room;
using Core.server;
using Game.data.model;
using Game.data.utils;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class BATTLE_DINO_DEATHBLOW_REC : ReceiveGamePacket
  {
    private int weaponId;
    private int TRex;

    public BATTLE_DINO_DEATHBLOW_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.TRex = (int) this.readC();
      this.weaponId = this.readD();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Room room = player._room;
        if (room == null || room.round.Timer != null || (room._state != RoomState.Battle || room.TRex != this.TRex))
          return;
        SLOT slot = room.getSlot(player._slotId);
        if (slot == null || slot.state != SLOT_STATE.BATTLE)
          return;
        if (slot._team == 0)
          room.red_dino += 5;
        else
          room.blue_dino += 5;
        using (BATTLE_DINO_PLACAR_PAK battleDinoPlacarPak = new BATTLE_DINO_PLACAR_PAK(room))
          room.SendPacketToPlayers((SendPacket) battleDinoPlacarPak, SLOT_STATE.BATTLE, 0);
        AllUtils.CompleteMission(room, player, slot, MISSION_TYPE.DEATHBLOW, this.weaponId);
      }
      catch (Exception ex)
      {
        Logger.info("BATTLE_DINO_DEATHBLOW_REC: " + ex.ToString());
      }
    }
  }
}
