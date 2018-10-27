
using Core;
using Core.managers.server;
using Core.server;
using Game.data.model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Game
{
  public static class GameManager
  {
    public static ConcurrentDictionary<uint, GameClient> _socketList = new ConcurrentDictionary<uint, GameClient>();
    public static ServerConfig Config;
    public static Socket mainSocket;
    public static bool ServerIsClosed;

    public static bool Start()
    {
      try
      {
        GameManager.Config = ServerConfigSyncer.GenerateConfig(ConfigGS.configId);
        GameManager.mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ConfigGS.gameIp), ConfigGS.gamePort);
        GameManager.mainSocket.Bind((EndPoint) ipEndPoint);
        GameManager.mainSocket.Listen(10);
        GameManager.mainSocket.BeginAccept(new AsyncCallback(GameManager.AcceptCallback), (object) GameManager.mainSocket);
        return true;
      }
      catch (Exception ex)
      {
        Logger.error(ex.ToString());
        return false;
      }
    }

    private static void AcceptCallback(IAsyncResult result)
    {
      if (GameManager.ServerIsClosed)
        return;
      Socket asyncState = (Socket) result.AsyncState;
      try
      {
        Socket client = asyncState.EndAccept(result);
        if (client != null)
        {
          GameClient sck = new GameClient(client);
          GameManager.AddSocket(sck);
          if (sck == null)
            Console.WriteLine("GameClient destruído após falha ao adicionar na lista.");
          Thread.Sleep(5);
        }
      }
      catch
      {
        Logger.warning("[Failed a GC connection] " + DateTime.Now.ToString("dd/MM/yy HH:mm"));
      }
      GameManager.mainSocket.BeginAccept(new AsyncCallback(GameManager.AcceptCallback), (object) GameManager.mainSocket);
    }

    public static void AddSocket(GameClient sck)
    {
      if (sck == null)
        return;
      uint num = 0;
      while (num < 100000U)
      {
        uint key = ++num;
        if (!GameManager._socketList.ContainsKey(key) && GameManager._socketList.TryAdd(key, sck))
        {
          sck.SessionId = key;
          sck.Start();
          return;
        }
      }
      sck.Close(500, false);
    }

    public static bool RemoveSocket(GameClient sck)
    {
      if (sck == null || sck.SessionId == 0U || (!GameManager._socketList.ContainsKey(sck.SessionId) || !GameManager._socketList.TryGetValue(sck.SessionId, out sck)))
        return false;
      return GameManager._socketList.TryRemove(sck.SessionId, out sck);
    }

    public static int SendPacketToAllClients(SendPacket packet)
    {
      int num = 0;
      if (GameManager._socketList.Count == 0)
        return num;
      byte[] completeBytes = packet.GetCompleteBytes("GameManager.SendPacketToAllClients");
      foreach (GameClient gameClient in (IEnumerable<GameClient>) GameManager._socketList.Values)
      {
        Account player = gameClient._player;
        if (player != null && player._isOnline)
        {
          player.SendCompletePacket(completeBytes);
          ++num;
        }
      }
      return num;
    }

    public static Account GetActiveClient(long accountId)
    {
      if (GameManager._socketList.Count == 0)
        return (Account) null;
      foreach (GameClient gameClient in (IEnumerable<GameClient>) GameManager._socketList.Values)
      {
        Account player = gameClient._player;
        if (player != null && player.player_id == accountId)
          return player;
      }
      return (Account) null;
    }

    public static Account GetActiveClient(uint sessionId)
    {
      if (GameManager._socketList.Count == 0)
        return (Account) null;
      foreach (GameClient gameClient in (IEnumerable<GameClient>) GameManager._socketList.Values)
      {
        if ((int) gameClient.SessionId == (int) sessionId && gameClient._player != null)
          return gameClient._player;
      }
      return (Account) null;
    }

    public static int KickInactiveClients(double Hours)
    {
      int num = 0;
      DateTime now = DateTime.Now;
      foreach (GameClient gameClient in (IEnumerable<GameClient>) GameManager._socketList.Values)
      {
        Account player = gameClient._player;
        if (player != null && player._room == null && (player.channelId > -1 && !player.IsGM()) && (now - player.LastLobbyEnter).TotalHours >= Hours)
        {
          ++num;
          player.Close(5000, false);
        }
      }
      return num;
    }

    public static int GetInactiveClientsCount(double Hours)
    {
      int num = 0;
      DateTime now = DateTime.Now;
      foreach (GameClient gameClient in (IEnumerable<GameClient>) GameManager._socketList.Values)
      {
        Account player = gameClient._player;
        if (player != null && player._room == null && (player.channelId > -1 && !player.IsGM()) && (now - player.LastLobbyEnter).TotalHours >= Hours)
          ++num;
      }
      return num;
    }
  }
}
