
using Core;
using Core.models.account.players;
using Core.models.enums;
using Core.models.room;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.data.utils;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
  public class BATTLE_READYBATTLE_REC : ReceiveGamePacket
  {
    private int erro;

    public BATTLE_READYBATTLE_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.erro = this.readD();
    }

    private bool ClassicModeCheck(Account p, Room room)
    {
      if (!room.name.ToLower().Contains("@camp") && !room.name.ToLower().Contains("camp") && (!room.name.ToLower().Contains("@cnpb") && !room.name.ToLower().Contains("cnpb")) && (!room.name.ToLower().Contains("@79") && !room.name.ToLower().Contains("79") && (!room.name.ToLower().Contains("@Lan") && !room.name.ToLower().Contains("@lan"))))
        return false;
      List<string> list = new List<string>();
      PlayerEquipedItems equip = p._equip;
      if (room.name.ToLower().Contains("@camp") || room.name.ToLower().Contains(" @camp") || (room.name.ToLower().Contains("@camp ") || room.name.ToLower().Contains("camp")))
      {
        for (int index = 0; index < TorunamentRulesManager.itemscamp.Count; ++index)
        {
          int listid = TorunamentRulesManager.itemscamp[index];
          if (!TorunamentRulesManager.IsBlocked(listid, equip._primary, ref list, Translation.GetLabel("ClassicCategory1")) && !TorunamentRulesManager.IsBlocked(listid, equip._secondary, ref list, Translation.GetLabel("ClassicCategory2")) && (!TorunamentRulesManager.IsBlocked(listid, equip._melee, ref list, Translation.GetLabel("ClassicCategory3")) && !TorunamentRulesManager.IsBlocked(listid, equip._grenade, ref list, Translation.GetLabel("ClassicCategory4"))) && (!TorunamentRulesManager.IsBlocked(listid, equip._special, ref list, Translation.GetLabel("ClassicCategory5")) && !TorunamentRulesManager.IsBlocked(listid, equip._red, ref list, Translation.GetLabel("ClassicCategory6")) && (!TorunamentRulesManager.IsBlocked(listid, equip._blue, ref list, Translation.GetLabel("ClassicCategory7")) && !TorunamentRulesManager.IsBlocked(listid, equip._helmet, ref list, Translation.GetLabel("ClassicCategory8")))) && !TorunamentRulesManager.IsBlocked(listid, equip._dino, ref list, Translation.GetLabel("ClassicCategory9")))
            TorunamentRulesManager.IsBlocked(listid, equip._beret, ref list, Translation.GetLabel("ClassicCategory10"));
        }
      }
      if (room.name.ToLower().Contains("@cnpb") || room.name.ToLower().Contains("@cnpb ") || (room.name.ToLower().Contains(" @cnpb") || room.name.ToLower().Contains("cnpb")))
      {
        for (int index = 0; index < TorunamentRulesManager.itemscnpb.Count; ++index)
        {
          int listid = TorunamentRulesManager.itemscnpb[index];
          if (!TorunamentRulesManager.IsBlocked(listid, equip._primary, ref list, Translation.GetLabel("ClassicCategory1")) && !TorunamentRulesManager.IsBlocked(listid, equip._secondary, ref list, Translation.GetLabel("ClassicCategory2")) && (!TorunamentRulesManager.IsBlocked(listid, equip._melee, ref list, Translation.GetLabel("ClassicCategory3")) && !TorunamentRulesManager.IsBlocked(listid, equip._grenade, ref list, Translation.GetLabel("ClassicCategory4"))) && (!TorunamentRulesManager.IsBlocked(listid, equip._special, ref list, Translation.GetLabel("ClassicCategory5")) && !TorunamentRulesManager.IsBlocked(listid, equip._red, ref list, Translation.GetLabel("ClassicCategory6")) && (!TorunamentRulesManager.IsBlocked(listid, equip._blue, ref list, Translation.GetLabel("ClassicCategory7")) && !TorunamentRulesManager.IsBlocked(listid, equip._helmet, ref list, Translation.GetLabel("ClassicCategory8")))) && !TorunamentRulesManager.IsBlocked(listid, equip._dino, ref list, Translation.GetLabel("ClassicCategory9")))
            TorunamentRulesManager.IsBlocked(listid, equip._beret, ref list, Translation.GetLabel("ClassicCategory10"));
        }
      }
      if (room.name.ToLower().Contains("@79") || room.name.ToLower().Contains("@79") || (room.name.ToLower().Contains(" @79") || room.name.ToLower().Contains("79")))
      {
        for (int index = 0; index < TorunamentRulesManager.items79.Count; ++index)
        {
          int listid = TorunamentRulesManager.items79[index];
          if (!TorunamentRulesManager.IsBlocked(listid, equip._primary, ref list, Translation.GetLabel("ClassicCategory1")) && !TorunamentRulesManager.IsBlocked(listid, equip._secondary, ref list, Translation.GetLabel("ClassicCategory2")) && (!TorunamentRulesManager.IsBlocked(listid, equip._melee, ref list, Translation.GetLabel("ClassicCategory3")) && !TorunamentRulesManager.IsBlocked(listid, equip._grenade, ref list, Translation.GetLabel("ClassicCategory4"))) && (!TorunamentRulesManager.IsBlocked(listid, equip._special, ref list, Translation.GetLabel("ClassicCategory5")) && !TorunamentRulesManager.IsBlocked(listid, equip._red, ref list, Translation.GetLabel("ClassicCategory6")) && (!TorunamentRulesManager.IsBlocked(listid, equip._blue, ref list, Translation.GetLabel("ClassicCategory7")) && !TorunamentRulesManager.IsBlocked(listid, equip._helmet, ref list, Translation.GetLabel("ClassicCategory8")))) && !TorunamentRulesManager.IsBlocked(listid, equip._dino, ref list, Translation.GetLabel("ClassicCategory9")))
            TorunamentRulesManager.IsBlocked(listid, equip._beret, ref list, Translation.GetLabel("ClassicCategory10"));
        }
      }
      if (room.name.ToLower().Contains("@lan") || room.name.ToLower().Contains("@Lan"))
      {
        for (int index = 0; index < TorunamentRulesManager.itemslan.Count; ++index)
        {
          int listid = TorunamentRulesManager.itemslan[index];
          if (!TorunamentRulesManager.IsBlocked(listid, equip._primary, ref list, Translation.GetLabel("ClassicCategory1")) && !TorunamentRulesManager.IsBlocked(listid, equip._secondary, ref list, Translation.GetLabel("ClassicCategory2")) && (!TorunamentRulesManager.IsBlocked(listid, equip._melee, ref list, Translation.GetLabel("ClassicCategory3")) && !TorunamentRulesManager.IsBlocked(listid, equip._grenade, ref list, Translation.GetLabel("ClassicCategory4"))) && (!TorunamentRulesManager.IsBlocked(listid, equip._special, ref list, Translation.GetLabel("ClassicCategory5")) && !TorunamentRulesManager.IsBlocked(listid, equip._red, ref list, Translation.GetLabel("ClassicCategory6")) && (!TorunamentRulesManager.IsBlocked(listid, equip._blue, ref list, Translation.GetLabel("ClassicCategory7")) && !TorunamentRulesManager.IsBlocked(listid, equip._helmet, ref list, Translation.GetLabel("ClassicCategory8")))) && !TorunamentRulesManager.IsBlocked(listid, equip._dino, ref list, Translation.GetLabel("ClassicCategory9")))
            TorunamentRulesManager.IsBlocked(listid, equip._beret, ref list, Translation.GetLabel("ClassicCategory10"));
        }
      }
      if (list.Count <= 0)
        return false;
      p.SendPacket((SendPacket) new SERVER_MESSAGE_ANNOUNCE_PAK(Translation.GetLabel("ClassicModeWarn", (object) string.Join(", ", list.ToArray()))));
      return true;
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Room room = player._room;
        Channel ch;
        SLOT slot;
        if (room == null || room.getLeader() == null || (!room.getChannel(out ch) || !room.getSlot(player._slotId, out slot)))
          return;
        if (slot._equip == null)
        {
          this._client.SendPacket((SendPacket) new BATTLE_READY_ERROR_PAK(2147487915U));
        }
        else
        {
          bool isBotMode = room.isBotMode();
          slot.specGM = this.erro == 1 && player.IsGM();
          player.DebugPing = false;
          if (ConfigGS.EnableTournamentRules && this.ClassicModeCheck(player, room))
            return;
          if (room._leader == player._slotId)
          {
            if (room._state != RoomState.Ready && room._state != RoomState.CountDown)
              return;
            int TotalEnemys = 0;
            int redPlayers = 0;
            int bluePlayers = 0;
            this.GetReadyPlayers(room, ref redPlayers, ref bluePlayers, ref TotalEnemys);
            if (ConfigGS.isTestMode && ConfigGS.udpType == SERVER_UDP_STATE.RELAY)
              TotalEnemys = 1;
            if (room.stage4v4 == (byte) 1 && (redPlayers >= 4 || bluePlayers >= 4))
            {
              this._client.SendPacket((SendPacket) new BATTLE_4VS4_ERROR_PAK());
            }
            else
            {
              if (this.ClanMatchCheck(room, ch._type, TotalEnemys))
                return;
              if (isBotMode || room.room_type == (byte) 10 || TotalEnemys > 0 && !isBotMode)
              {
                room.changeSlotState(slot, SLOT_STATE.READY, false);
                if (room._state != RoomState.CountDown)
                  this.TryBalanceTeams(room, isBotMode);
                if (room.thisModeHaveCD())
                {
                  if (room._state == RoomState.Ready)
                  {
                    room._state = RoomState.CountDown;
                    room.updateRoomInfo();
                    room.StartCountDown();
                  }
                  else if (room._state == RoomState.CountDown)
                  {
                    room.changeSlotState(room._leader, SLOT_STATE.NORMAL, false);
                    room.StopCountDown(CountDownEnum.StopByHost, true);
                  }
                }
                else
                  room.StartBattle(false);
                room.updateSlotsInfo();
              }
              else
              {
                if (TotalEnemys != 0 || isBotMode)
                  return;
                this._client.SendPacket((SendPacket) new BATTLE_READY_ERROR_PAK(2147487753U));
              }
            }
          }
          else if (room._slots[room._leader].state >= SLOT_STATE.LOAD)
          {
            if (slot.state != SLOT_STATE.NORMAL)
              return;
            if (room.autobalans == 1 && !isBotMode)
              AllUtils.TryBalancePlayer(room, player, true, ref slot);
            room.changeSlotState(slot, SLOT_STATE.LOAD, true);
            slot.SetMissionsClone(player._mission);
            this._client.SendPacket((SendPacket) new BATTLE_READYBATTLE_PAK(room));
            this._client.SendPacket((SendPacket) new BATTLE_READY_ERROR_PAK((uint) slot.state));
            using (BATTLE_READYBATTLE2_PAK battleReadybattlE2Pak = new BATTLE_READYBATTLE2_PAK(slot, player._titles))
              room.SendPacketToPlayers((SendPacket) battleReadybattlE2Pak, SLOT_STATE.READY, 1, slot._id);
          }
          else if (slot.state == SLOT_STATE.NORMAL)
          {
            room.changeSlotState(slot, SLOT_STATE.READY, true);
            if (room._state != RoomState.CountDown)
              return;
            this.TryBalanceTeams(room, isBotMode);
          }
          else
          {
            if (slot.state != SLOT_STATE.READY)
              return;
            room.changeSlotState(slot, SLOT_STATE.NORMAL, false);
            if (room._state == RoomState.CountDown && room.getPlayingPlayers(room._leader % 2 == 0 ? 1 : 0, SLOT_STATE.READY, 0) == 0)
            {
              room.changeSlotState(room._leader, SLOT_STATE.NORMAL, false);
              room.StopCountDown(CountDownEnum.StopByPlayer, true);
            }
            room.updateSlotsInfo();
          }
        }
      }
      catch (Exception ex)
      {
        Logger.info("BATTLE_READYBATTLE_REC: " + ex.ToString());
      }
    }

    private void GetReadyPlayers(Room room, ref int redPlayers, ref int bluePlayers, ref int TotalEnemys)
    {
      for (int index = 0; index < 16; ++index)
      {
        SLOT slot = room._slots[index];
        if (slot.state == SLOT_STATE.READY)
        {
          if (slot._team == 0)
            ++redPlayers;
          else
            ++bluePlayers;
        }
      }
      if (room._leader % 2 == 0)
        TotalEnemys = bluePlayers;
      else
        TotalEnemys = redPlayers;
    }

    private bool ClanMatchCheck(Room room, int type, int TotalEnemys)
    {
      if (ConfigGS.isTestMode || type != 4)
        return false;
      if (!AllUtils.Have2ClansToClanMatch(room))
      {
        this._client.SendPacket((SendPacket) new BATTLE_READY_ERROR_PAK(2147487857U));
        return true;
      }
      if (TotalEnemys <= 0 || AllUtils.HavePlayersToClanMatch(room))
        return false;
      this._client.SendPacket((SendPacket) new BATTLE_READY_ERROR_PAK(2147487858U));
      return true;
    }

    private void TryBalanceTeams(Room room, bool isBotMode)
    {
      if (room.autobalans != 1 | isBotMode)
        return;
      int[] numArray1;
      switch (AllUtils.getBalanceTeamIdx(room, false, -1))
      {
        case -1:
          return;
        case 1:
          numArray1 = room.RED_TEAM;
          break;
        default:
          numArray1 = room.BLUE_TEAM;
          break;
      }
      int[] numArray2 = numArray1;
      SLOT mySlot = (SLOT) null;
      for (int index = numArray2.Length - 1; index >= 0; --index)
      {
        SLOT slot = room._slots[numArray2[index]];
        if (slot.state == SLOT_STATE.READY && room._leader != slot._id)
        {
          mySlot = slot;
          break;
        }
      }
      Account player;
      if (mySlot == null || !room.getPlayerBySlot(mySlot, out player))
        return;
      AllUtils.TryBalancePlayer(room, player, false, ref mySlot);
    }
  }
}
