
using Core;
using Core.managers.events;
using Core.managers.server;
using Core.models.account;
using Core.models.enums;
using Core.models.enums.flags;
using Core.models.enums.friends;
using Core.models.enums.missions;
using Core.models.room;
using Core.models.servers;
using Core.server;
using Core.xml;
using Game.data.managers;
using Game.data.model;
using Game.data.sync.client_side;
using Game.data.utils;
using Game.data.xml;
using Game.global.serverpacket;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Game.data.sync
{
  public static class Game_SyncNet
  {
    private static DateTime LastSyncCount;
    public static UdpClient udp;

    public static void Start()
    {
      try
      {
        Game_SyncNet.udp = new UdpClient(ConfigGS.syncPort);
        uint num = 2147483648u;
        uint num2 = 402653184u;
        uint ioControlCode = num | num2 | 0xC;
        Game_SyncNet.udp.Client.IOControl((int) num, new byte[1]
        {
          Convert.ToByte(false)
        }, (byte[]) null);
        new Thread(new ThreadStart(Game_SyncNet.read)).Start();
      }
      catch (Exception ex)
      {
        Logger.error(ex.ToString());
      }
    }

    public static void read()
    {
      try
      {
        Game_SyncNet.udp.BeginReceive(new AsyncCallback(Game_SyncNet.recv), (object) null);
      }
      catch
      {
      }
    }

    private static void recv(IAsyncResult res)
    {
      if (GameManager.ServerIsClosed)
        return;
      IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 8000);
      byte[] buffer = Game_SyncNet.udp.EndReceive(res, ref remoteEP);
      Thread.Sleep(5);
      new Thread(new ThreadStart(Game_SyncNet.read)).Start();
      if (buffer.Length < 2)
        return;
      Game_SyncNet.LoadPacket(buffer);
    }

    private static void LoadPacket(byte[] buffer)
    {
      ReceiveGPacket p = new ReceiveGPacket(buffer);
      short num1 = p.readH();
      try
      {
        switch (num1)
        {
          case 1:
            Net_Room_Pass_Portal.Load(p);
            break;
          case 2:
            Net_Room_C4.Load(p);
            break;
          case 3:
            Net_Room_Death.Load(p);
            break;
          case 4:
            Net_Room_HitMarker.Load(p);
            break;
          case 5:
            Net_Room_Sabotage_Sync.Load(p);
            break;
          case 10:
            Account account1 = AccountManager.getAccount(p.readQ(), true);
            if (account1 == null)
              break;
            account1.SendPacket((SendPacket) new AUTH_ACCOUNT_KICK_PAK(1));
            account1.SendPacket((SendPacket) new SERVER_MESSAGE_ERROR_PAK(2147487744U));
            account1.Close(1000, false);
            break;
          case 11:
            int num2 = (int) p.readC();
            int num3 = (int) p.readC();
            Account account2 = AccountManager.getAccount(p.readQ(), 0);
            if (account2 == null)
              break;
            Account account3 = AccountManager.getAccount(p.readQ(), true);
            if (account3 == null)
              break;
            FriendState friendState = num3 == 1 ? FriendState.Online : FriendState.Offline;
            if (num2 == 0)
            {
              int index = -1;
              Friend friend = account3.FriendSystem.GetFriend(account2.player_id, out index);
              if (index == -1 || friend == null || friend.state != 0)
                break;
              account3.SendPacket((SendPacket) new FRIEND_UPDATE_PAK(FriendChangeState.Update, friend, friendState, index));
              break;
            }
            account3.SendPacket((SendPacket) new CLAN_MEMBER_INFO_CHANGE_PAK(account2, friendState));
            break;
          case 13:
            long id1 = p.readQ();
            byte num4 = p.readC();
            byte[] data = p.readB((int) p.readUH());
            Account account4 = AccountManager.getAccount(id1, true);
            if (account4 == null)
              break;
            if (num4 == (byte) 0)
            {
              account4.SendPacket(data);
              break;
            }
            account4.SendCompletePacket(data);
            break;
          case 15:
            int id2 = p.readD();
            int num5 = p.readD();
            GameServerModel server = ServersXML.getServer(id2);
            if (server == null)
              break;
            server._LastCount = num5;
            break;
          case 16:
            Net_Clan_Sync.Load(p);
            break;
          case 17:
            Net_Friend_Sync.Load(p);
            break;
          case 18:
            Net_Inventory_Sync.Load(p);
            break;
          case 19:
            Net_Player_Sync.Load(p);
            break;
          case 20:
            Net_Server_Warning.LoadGMWarning(p);
            break;
          case 21:
            Net_Clan_Servers_Sync.Load(p);
            break;
          case 22:
            Net_Server_Warning.LoadShopRestart(p);
            break;
          case 23:
            Net_Server_Warning.LoadServerUpdate(p);
            break;
          case 24:
            Net_Server_Warning.LoadShutdown(p);
            break;
          case 31:
            EventLoader.ReloadEvent((int) p.readC());
            Logger.warning("[Game_SyncNet] Evento re-carregado.");
            break;
          case 32:
            ServerConfigSyncer.GenerateConfig((int) p.readC());
            Logger.warning("[Game_SyncNet] Configurações (DB) resetadas.");
            break;
          default:
            Logger.warning("[Game_SyncNet] Tipo de conexão não encontrada: " + (object) num1);
            break;
        }
      }
      catch (Exception ex)
      {
        Logger.error("[Crash/Game_SyncNet] Tipo: " + (object) num1 + "\r\n" + ex.ToString());
        if (p == null)
          return;
        Logger.error("COMP: " + BitConverter.ToString(p.getBuffer()));
      }
    }

    public static void SendUDPPlayerSync(Room room, SLOT slot, CupomEffects effects, int type)
    {
      using (SendGPacket pk = new SendGPacket())
      {
        pk.writeH((short) 1);
        pk.writeD(room.UniqueRoomId);
        pk.writeD(room.mapId * 16 + (int) room.room_type);
        pk.writeQ(room.StartTick);
        pk.writeC((byte) type);
        pk.writeC((byte) room.rodada);
        pk.writeC((byte) slot._id);
        pk.writeC((byte) slot.spawnsCount);
        pk.writeC(BitConverter.GetBytes(slot._playerId)[0]);
        if (type == 0 || type == 2)
          Game_SyncNet.WriteCharaInfo(pk, room, slot, effects);
        Game_SyncNet.SendPacket(pk.mstream.ToArray(), room.UDPServer.Connection);
      }
    }

    private static void WriteCharaInfo(SendGPacket pk, Room room, SLOT slot, CupomEffects effects)
    {
      int id = room.room_type == (byte) 7 || room.room_type == (byte) 12 ? (room.rodada == 1 && slot._team == 1 || room.rodada == 2 && slot._team == 0 ? (room.rodada == 2 ? slot._equip._red : slot._equip._blue) : (room.TRex != slot._id ? slot._equip._dino : -1)) : (slot._team == 0 ? slot._equip._red : slot._equip._blue);
      int num = 0;
      if (effects.HasFlag((System.Enum) CupomEffects.Ketupat))
        num += 10;
      if (effects.HasFlag((System.Enum) CupomEffects.HP5))
        num += 5;
      if (effects.HasFlag((System.Enum) CupomEffects.HP10))
        num += 10;
      if (id == -1)
      {
        pk.writeC(byte.MaxValue);
        pk.writeH(ushort.MaxValue);
      }
      else
      {
        pk.writeC((byte) ComDiv.getIdStatics(id, 2));
        pk.writeH((short) ComDiv.getIdStatics(id, 4));
      }
      pk.writeC((byte) num);
      pk.writeC(effects.HasFlag((System.Enum) CupomEffects.C4SpeedKit));
    }

    public static void SendUDPRoundSync(Room room)
    {
      using (SendGPacket sendGpacket = new SendGPacket())
      {
        sendGpacket.writeH((short) 3);
        sendGpacket.writeD(room.UniqueRoomId);
        sendGpacket.writeD(room.mapId * 16 + (int) room.room_type);
        sendGpacket.writeC((byte) room.rodada);
        Game_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), room.UDPServer.Connection);
      }
    }

    public static GameServerModel GetServer(AccountStatus status)
    {
      return Game_SyncNet.GetServer((int) status.serverId);
    }

    public static GameServerModel GetServer(int serverId)
    {
      if (serverId == (int) byte.MaxValue || serverId == ConfigGS.serverId)
        return (GameServerModel) null;
      return ServersXML.getServer(serverId);
    }

    public static void UpdateGSCount(int serverId)
    {
      try
      {
        if ((DateTime.Now - Game_SyncNet.LastSyncCount).TotalSeconds < 2.5)
          return;
        Game_SyncNet.LastSyncCount = DateTime.Now;
        int num = 0;
        foreach (Channel channel in ChannelsXML._channels)
          num += channel._players.Count;
        foreach (GameServerModel server in ServersXML._servers)
        {
          if (server._id == serverId)
          {
            server._LastCount = num;
          }
          else
          {
            using (SendGPacket sendGpacket = new SendGPacket())
            {
              sendGpacket.writeH((short) 15);
              sendGpacket.writeD(serverId);
              sendGpacket.writeD(num);
              Game_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), server.Connection);
            }
          }
        }
      }
      catch (Exception ex)
      {
        Logger.warning("[Game_SyncNet.UpdateGSCount] " + ex.ToString());
      }
    }

    public static void SendBytes(long playerId, SendPacket sp, int serverId)
    {
      if (sp == null)
        return;
      GameServerModel server = Game_SyncNet.GetServer(serverId);
      if (server == null)
        return;
      byte[] bytes = sp.GetBytes("Game_SyncNet.SendBytes");
      using (SendGPacket sendGpacket = new SendGPacket())
      {
        sendGpacket.writeH((short) 13);
        sendGpacket.writeQ(playerId);
        sendGpacket.writeC((byte) 0);
        sendGpacket.writeH((ushort) bytes.Length);
        sendGpacket.writeB(bytes);
        Game_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), server.Connection);
      }
    }

    public static void SendBytes(long playerId, byte[] buffer, int serverId)
    {
      if (buffer.Length == 0)
        return;
      GameServerModel server = Game_SyncNet.GetServer(serverId);
      if (server == null)
        return;
      using (SendGPacket sendGpacket = new SendGPacket())
      {
        sendGpacket.writeH((short) 13);
        sendGpacket.writeQ(playerId);
        sendGpacket.writeC((byte) 0);
        sendGpacket.writeH((ushort) buffer.Length);
        sendGpacket.writeB(buffer);
        Game_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), server.Connection);
      }
    }

    public static void SendCompleteBytes(long playerId, byte[] buffer, int serverId)
    {
      if (buffer.Length == 0)
        return;
      GameServerModel server = Game_SyncNet.GetServer(serverId);
      if (server == null)
        return;
      using (SendGPacket sendGpacket = new SendGPacket())
      {
        sendGpacket.writeH((short) 13);
        sendGpacket.writeQ(playerId);
        sendGpacket.writeC((byte) 1);
        sendGpacket.writeH((ushort) buffer.Length);
        sendGpacket.writeB(buffer);
        Game_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), server.Connection);
      }
    }

    public static void SendPacket(byte[] data, IPEndPoint ip)
    {
      Game_SyncNet.udp.Send(data, data.Length, ip);
    }

    public static void genDeath(Room room, SLOT killer, FragInfos kills, bool isSuicide)
    {
      bool isBotMode = room.isBotMode();
      int score;
      Net_Room_Death.RegistryFragInfos(room, killer, out score, isBotMode, isSuicide, kills);
      if (isBotMode)
      {
        killer.Score += killer.killsOnLife + (int) room.IngameAiLevel + score;
        if (killer.Score > (int) ushort.MaxValue)
        {
          killer.Score = (int) ushort.MaxValue;
          Logger.warning("[PlayerId: " + (object) killer._id + "] chegou a pontuação máxima do modo BOT.");
        }
        kills.Score = killer.Score;
      }
      else
      {
        killer.Score += score;
        AllUtils.CompleteMission(room, killer, kills, MISSION_TYPE.NA, 0);
        kills.Score = score;
      }
      using (BATTLE_DEATH_PAK battleDeathPak = new BATTLE_DEATH_PAK(room, kills, killer, isBotMode))
        room.SendPacketToPlayers((SendPacket) battleDeathPak, SLOT_STATE.BATTLE, 0);
      Net_Room_Death.EndBattleByDeath(room, killer, isBotMode, isSuicide);
    }
  }
}
