
using Auth.data.managers;
using Auth.data.model;
using Auth.global.serverpacket;
using Core;
using Core.managers;
using Core.server;
using Core.xml;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace Auth.data.sync.client_side
{
  public static class Net_Server_Warning
  {
    public static void LoadGMWarning(ReceiveGPacket p)
    {
      string str1 = p.readS((int) p.readC());
      string text = p.readS((int) p.readC());
      string msg = p.readS((int) p.readH());
      string str2 = ComDiv.gen5(text);
      Account accountDb = AccountManager.getInstance().getAccountDB((object) str1, (object) str2, 2, 0);
      if (accountDb == null || accountDb.access <= 3)
        return;
      int num = 0;
      using (SERVER_MESSAGE_ANNOUNCE_PAK messageAnnouncePak = new SERVER_MESSAGE_ANNOUNCE_PAK(msg))
        num = LoginManager.SendPacketToAllClients((SendPacket) messageAnnouncePak);
      Logger.warning("[SM] Aviso gerado a " + (object) num + " jogadores: " + msg);
    }

    public static void LoadShopRestart(ReceiveGPacket p)
    {
      int type = (int) p.readC();
      ShopManager.Reset();
      ShopManager.Load(type);
      Logger.warning("[SM] Shop reiniciada. (Type: " + (object) type + ")");
    }

    public static void LoadServerUpdate(ReceiveGPacket p)
    {
      int serverId = (int) p.readC();
      ServersXML.UpdateServer(serverId);
      Logger.warning("[SM] Servidor " + (object) serverId + " atualizado.");
    }

    public static void LoadShutdown(ReceiveGPacket p)
    {
      string str1 = p.readS((int) p.readC());
      string str2 = ComDiv.gen5(p.readS((int) p.readC()));
      Account accountDb = AccountManager.getInstance().getAccountDB((object) str1, (object) str2, 2, 0);
      if (accountDb == null || !(accountDb.password == str2) || accountDb.access < 4)
        return;
      int num = 0;
      foreach (LoginClient loginClient in (IEnumerable<LoginClient>) LoginManager._socketList.Values)
      {
        loginClient._client.Shutdown(SocketShutdown.Both);
        loginClient._client.Close(10000);
        ++num;
      }
      Logger.warning("[SM] Clients downed due a shutdown: " + (object) num + ". (By: " + str1 + ")");
      LoginManager.ServerIsClosed = true;
      LoginManager.mainSocket.Close(5000);
      Logger.warning("[SM] Server receive code has been shutdowned for 5 seconds!");
      Thread.Sleep(5000);
      Auth_SyncNet.udp.Close();
      Logger.warning("[SM] Starting step 2.");
      foreach (LoginClient loginClient in (IEnumerable<LoginClient>) LoginManager._socketList.Values)
        loginClient.Close(0, true);
      Logger.warning("[SM] Server has been completely shutdowned.");
    }
  }
}
