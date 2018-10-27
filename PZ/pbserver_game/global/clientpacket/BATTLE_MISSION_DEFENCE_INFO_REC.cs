
using Core;
using Core.models.enums;
using Core.models.room;
using Core.server;
using Game.data.model;
using Game.data.sync.client_side;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
  public class BATTLE_MISSION_DEFENCE_INFO_REC : ReceiveGamePacket
  {
    private List<ushort> _damag1 = new List<ushort>();
    private List<ushort> _damag2 = new List<ushort>();
    private ushort tanqueA;
    private ushort tanqueB;

    public BATTLE_MISSION_DEFENCE_INFO_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.tanqueA = this.readUH();
      this.tanqueB = this.readUH();
      for (int index = 0; index < 16; ++index)
        this._damag1.Add(this.readUH());
      for (int index = 0; index < 16; ++index)
        this._damag2.Add(this.readUH());
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        Room room = player == null ? (Room) null : player._room;
        if (room == null || room.round.Timer != null || (room._state != RoomState.Battle || room.swapRound))
          return;
        SLOT slot1 = room.getSlot(player._slotId);
        if (slot1 == null || slot1.state != SLOT_STATE.BATTLE)
          return;
        room.Bar1 = (int) this.tanqueA;
        room.Bar2 = (int) this.tanqueB;
        for (int index = 0; index < 16; ++index)
        {
          SLOT slot2 = room._slots[index];
          if (slot2._playerId > 0L && slot2.state == SLOT_STATE.BATTLE)
          {
            slot2.damageBar1 = this._damag1[index];
            slot2.damageBar2 = this._damag2[index];
          }
        }
        using (BATTLE_MISSION_DEFENCE_INFO_PAK missionDefenceInfoPak = new BATTLE_MISSION_DEFENCE_INFO_PAK(room))
          room.SendPacketToPlayers((SendPacket) missionDefenceInfoPak, SLOT_STATE.BATTLE, 0);
        if (this.tanqueA != (ushort) 0 || this.tanqueB != (ushort) 0)
          return;
        Net_Room_Sabotage_Sync.EndRound(room, (byte) 0);
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
