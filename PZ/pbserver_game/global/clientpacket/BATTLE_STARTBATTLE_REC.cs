
using Core;
using Core.models.enums;
using Core.models.enums.errors;
using Core.models.room;
using Core.server;
using Game.data.model;
using Game.data.utils;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class BATTLE_STARTBATTLE_REC : ReceiveGamePacket
  {
    public BATTLE_STARTBATTLE_REC(GameClient client, byte[] data)
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
        if (this._client == null)
          return;
        Account player = this._client._player;
        Room room = player == null ? (Room) null : player._room;
        if (room != null && room.isPreparing())
        {
          bool isBotMode = room.isBotMode();
          SLOT slot1 = room.getSlot(player._slotId);
          if (slot1 == null)
            return;
          if (slot1.state == SLOT_STATE.PRESTART)
          {
            room.changeSlotState(slot1, SLOT_STATE.BATTLE_READY, true);
            slot1.StopTiming();
            if (isBotMode)
              this._client.SendPacket((SendPacket) new BATTLE_CHANGE_DIFFICULTY_LEVEL_PAK(room));
            this._client.SendPacket((SendPacket) new BATTLE_ROOM_INFO_PAK(room, isBotMode));
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            for (int index = 0; index < 16; ++index)
            {
              SLOT slot2 = room._slots[index];
              if (slot2.state >= SLOT_STATE.LOAD)
              {
                ++num3;
                if (slot2._team == 0)
                  ++num4;
                else
                  ++num5;
                if (slot2.state >= SLOT_STATE.BATTLE_READY)
                {
                  if (slot2._team == 0)
                    ++num2;
                  else
                    ++num1;
                }
              }
            }
            if (room._state != RoomState.Battle && (!(room._slots[room._leader].state >= SLOT_STATE.BATTLE_READY & isBotMode) || (room._leader % 2 != 0 || num2 <= num4 / 2) && (room._leader % 2 != 1 || num1 <= num5 / 2)) && (room._slots[room._leader].state < SLOT_STATE.BATTLE_READY || (ConfigGS.isTestMode && ConfigGS.udpType == SERVER_UDP_STATE.RELAY || (num1 <= num5 / 2 || num2 <= num4 / 2)) && (!ConfigGS.isTestMode || ConfigGS.udpType != SERVER_UDP_STATE.RELAY)))
              return;
            room.SpawnReadyPlayers(isBotMode);
          }
          else
          {
            this._client.SendPacket((SendPacket) new SERVER_MESSAGE_KICK_BATTLE_PLAYER_PAK(EventErrorEnum.Battle_First_Hole));
            this._client.SendPacket((SendPacket) new BATTLE_LEAVEP2PSERVER_PAK(player, 0));
            room.changeSlotState(slot1, SLOT_STATE.NORMAL, true);
            AllUtils.BattleEndPlayersCount(room, isBotMode);
          }
        }
        else
        {
          this._client.SendPacket((SendPacket) new SERVER_MESSAGE_KICK_BATTLE_PLAYER_PAK(EventErrorEnum.Battle_First_Hole));
          this._client.SendPacket((SendPacket) new BATTLE_STARTBATTLE_PAK());
          room.changeSlotState(player._slotId, SLOT_STATE.NORMAL, true);
          if (room != null || player == null)
            return;
          this._client.SendPacket((SendPacket) new LOBBY_ENTER_PAK());
        }
      }
      catch (Exception ex)
      {
        Logger.warning("[BATTLE_STARTBATTLE_REC] " + ex.ToString());
      }
    }
  }
}
