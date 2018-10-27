
using Auth.data.model;
using Core;
using Core.managers.server;
using Core.server;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Auth
{
  public class LoginManager
  {
    public static ConcurrentDictionary<uint, LoginClient> _socketList = new ConcurrentDictionary<uint, LoginClient>();
    public static List<LoginClient> _loginQueue = new List<LoginClient>();
    public static ServerConfig Config;
    public static Socket mainSocket;
    public static bool ServerIsClosed;

    public static bool Start()
    {
      try
      {
        LoginManager.Config = ServerConfigSyncer.GenerateConfig(ConfigGA.configId);
        LoginManager.mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ConfigGA.authIp), ConfigGA.authPort);
        LoginManager.mainSocket.Bind((EndPoint) ipEndPoint);
        LoginManager.mainSocket.Listen(10);
        LoginManager.mainSocket.BeginAccept(new AsyncCallback(LoginManager.AcceptCallback), (object) LoginManager.mainSocket);
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
      if (LoginManager.ServerIsClosed)
        return;
      Socket asyncState = (Socket) result.AsyncState;
      try
      {
        Socket client = asyncState.EndAccept(result);
        if (client != null)
        {
          LoginClient sck = new LoginClient(client);
          LoginManager.AddSocket(sck);
          if (sck == null)
            Console.WriteLine("LoginClient destruído após falha ao adicionar na lista.");
          Thread.Sleep(5);
        }
      }
      catch
      {
        Logger.warning("[Failed a LC connection] " + DateTime.Now.ToString("dd/MM/yy HH:mm"));
      }
      LoginManager.mainSocket.BeginAccept(new AsyncCallback(LoginManager.AcceptCallback), (object) LoginManager.mainSocket);
    }

    public static void AddSocket(LoginClient sck)
    {
      if (sck == null)
        return;
      uint num = 0;
      while (num < 100000U)
      {
        uint key = ++num;
        if (!LoginManager._socketList.ContainsKey(key) && LoginManager._socketList.TryAdd(key, sck))
        {
          sck.SessionId = key;
          sck.Start();
          return;
        }
      }
      sck.Close(500, true);
    }

    public static int EnterQueue(LoginClient sck)
    {
      if (sck == null)
        return -1;
      lock (LoginManager._loginQueue)
      {
        if (LoginManager._loginQueue.Contains(sck))
          return -1;
        LoginManager._loginQueue.Add(sck);
        return LoginManager._loginQueue.IndexOf(sck);
      }
    }

    public static bool RemoveSocket(LoginClient sck)
    {
      if (sck == null || sck.SessionId == 0U || (!LoginManager._socketList.ContainsKey(sck.SessionId) || !LoginManager._socketList.TryGetValue(sck.SessionId, out sck)))
        return false;
      return LoginManager._socketList.TryRemove(sck.SessionId, out sck);
    }

    public static int SendPacketToAllClients(SendPacket packet)
    {
      int num = 0;
      if (LoginManager._socketList.Count > 0)
      {
        byte[] completeBytes = packet.GetCompleteBytes("GameManager.SendPacketToAllClients");
        foreach (LoginClient loginClient in (IEnumerable<LoginClient>) LoginManager._socketList.Values)
        {
          Account player = loginClient._player;
          if (player != null && player._isOnline)
          {
            player.SendCompletePacket(completeBytes);
            ++num;
          }
        }
      }
      return num;
    }

    public static Account GetActiveClient(long accountId)
    {
      if (LoginManager._socketList.Count == 0)
        return (Account) null;
      foreach (LoginClient loginClient in (IEnumerable<LoginClient>) LoginManager._socketList.Values)
      {
        Account player = loginClient._player;
        if (player != null && player.player_id == accountId)
          return player;
      }
      return (Account) null;
    }
  }
}
