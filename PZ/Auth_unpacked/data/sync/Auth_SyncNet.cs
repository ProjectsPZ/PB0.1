
using Auth.data.managers;
using Auth.data.model;
using Auth.data.sync.client_side;
using Auth.global.serverpacket;
using Core;
using Core.managers.events;
using Core.managers.server;
using Core.models.account;
using Core.models.enums.friends;
using Core.models.servers;
using Core.server;
using Core.xml;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Auth.data.sync
{
  public class Auth_SyncNet
  {
    private static DateTime LastSyncCount;
    public static UdpClient udp;

    public static void Start()
    {
      try
      {
        Auth_SyncNet.udp = new UdpClient(ConfigGA.syncPort);
        uint num = 2147483648u;
        uint num2 = 402653184u;
        uint ioControlCode = num | num2 | 0xC;
        Auth_SyncNet.udp.Client.IOControl((int) num, new byte[1]
        {
          Convert.ToByte(false)
        }, (byte[]) null);
        new Thread(new ThreadStart(Auth_SyncNet.read)).Start();
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
        Auth_SyncNet.udp.BeginReceive(new AsyncCallback(Auth_SyncNet.recv), (object) null);
      }
      catch
      {
      }
    }

    private static void recv(IAsyncResult res)
    {
      if (LoginManager.ServerIsClosed)
        return;
      IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 8000);
      byte[] buffer = Auth_SyncNet.udp.EndReceive(res, ref remoteEP);
      Thread.Sleep(5);
      new Thread(new ThreadStart(Auth_SyncNet.read)).Start();
      if (buffer.Length < 2)
        return;
      Auth_SyncNet.LoadPacket(buffer);
    }

    private static void LoadPacket(byte[] buffer)
    {
      ReceiveGPacket p = new ReceiveGPacket(buffer);
      short num1 = p.readH();
      switch (num1)
      {
        case 11:
          int num2 = (int) p.readC();
          int num3 = (int) p.readC();
          Account account1 = AccountManager.getInstance().getAccount(p.readQ(), true);
          if (account1 == null)
            break;
          Account account2 = AccountManager.getInstance().getAccount(p.readQ(), true);
          if (account2 == null)
            break;
          FriendState friendState = num3 == 1 ? FriendState.Online : FriendState.Offline;
          if (num2 == 0)
          {
            int index = -1;
            Friend friend = account2.FriendSystem.GetFriend(account1.player_id, out index);
            if (index == -1 || friend == null)
              break;
            account2.SendPacket((SendPacket) new FRIEND_UPDATE_PAK(FriendChangeState.Update, friend, friendState, index));
            break;
          }
          account2.SendPacket((SendPacket) new CLAN_MEMBER_INFO_CHANGE_PAK(account1, friendState));
          break;
        case 13:
          long id1 = p.readQ();
          byte num4 = p.readC();
          byte[] data = p.readB((int) p.readUH());
          Account account3 = AccountManager.getInstance().getAccount(id1, true);
          if (account3 == null)
            break;
          if (num4 == (byte) 0)
          {
            account3.SendPacket(data);
            break;
          }
          account3.SendCompletePacket(data);
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
        case 19:
          Net_Player_Sync.Load(p);
          break;
        case 20:
          Net_Server_Warning.LoadGMWarning(p);
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
          Logger.warning("[Auth_SyncNet] Evento re-carregado.");
          break;
        case 32:
          ServerConfigSyncer.GenerateConfig((int) p.readC());
          Logger.warning("[Auth_SyncNet] Configurações (DB) resetadas.");
          break;
        default:
          Logger.warning("[Auth_SyncNet] Tipo de conexão não encontrada: " + (object) num1);
          break;
      }
    }

    public static void UpdateGSCount(int serverId)
    {
      try
      {
        if ((DateTime.Now - Auth_SyncNet.LastSyncCount).TotalSeconds < 2.5)
          return;
        Auth_SyncNet.LastSyncCount = DateTime.Now;
        int count = LoginManager._socketList.Count;
        foreach (GameServerModel server in ServersXML._servers)
        {
          if (server._id == serverId)
          {
            server._LastCount = count;
          }
          else
          {
            using (SendGPacket sendGpacket = new SendGPacket())
            {
              sendGpacket.writeH((short) 15);
              sendGpacket.writeD(serverId);
              sendGpacket.writeD(count);
              Auth_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), server.Connection);
            }
          }
        }
      }
      catch (Exception ex)
      {
        Logger.warning(ex.ToString());
      }
    }

    public static void SendLoginKickInfo(Account player)
    {
      int serverId = (int) player._status.serverId;
      switch (serverId)
      {
        case 0:
        case (int) byte.MaxValue:
          player.setOnlineStatus(false);
          break;
        default:
          GameServerModel server = ServersXML.getServer(serverId);
          if (server == null)
            break;
          using (SendGPacket sendGpacket = new SendGPacket())
          {
            sendGpacket.writeH((short) 10);
            sendGpacket.writeQ(player.player_id);
            Auth_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), server.Connection);
            break;
          }
      }
    }

    public static void SendPacket(byte[] data, IPEndPoint ip)
    {
      Auth_SyncNet.udp.Send(data, data.Length, ip);
    }
  }
}
