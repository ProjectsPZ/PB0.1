
using Core;
using Core.managers;
using Core.models.enums;
using Core.server;
using Core.xml;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace Game.data.sync.client_side
{
  public class Net_Server_Warning
  {
    public static void LoadGMWarning(ReceiveGPacket p)
    {
      string text1 = p.readS((int) p.readC());
      string text2 = p.readS((int) p.readC());
      string msg = p.readS((int) p.readH());
      Account account = AccountManager.getAccount(text1, 0, 0);
      if (account == null || !(account.password == ComDiv.gen5(text2)) || account.access < AccessLevel.GameMaster)
        return;
      int num = 0;
      using (SERVER_MESSAGE_ANNOUNCE_PAK messageAnnouncePak = new SERVER_MESSAGE_ANNOUNCE_PAK(msg))
        num = GameManager.SendPacketToAllClients((SendPacket) messageAnnouncePak);
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
      string text1 = p.readS((int) p.readC());
      string text2 = p.readS((int) p.readC());
      Account account = AccountManager.getAccount(text1, 0, 0);
      if (account == null || !(account.password == ComDiv.gen5(text2)) || account.access < AccessLevel.GameMaster)
        return;
      int num = 0;
      foreach (GameClient gameClient in (IEnumerable<GameClient>) GameManager._socketList.Values)
      {
        gameClient._client.Shutdown(SocketShutdown.Both);
        gameClient.Close(5000, false);
        ++num;
      }
      Logger.warning("[SM] Clients downed due a shutdown: " + (object) num + ". (By: " + text1 + ")");
      GameManager.ServerIsClosed = true;
      GameManager.mainSocket.Close(5000);
      Logger.warning("[SM] Server receive code has been shutdowned for 5 seconds!");
      Thread.Sleep(5000);
      Game_SyncNet.udp.Close();
      Logger.warning("[SM] Starting step 2.");
      foreach (GameClient gameClient in (IEnumerable<GameClient>) GameManager._socketList.Values)
        gameClient.Close(0, false);
      Logger.warning("[SM] Server has been completely shutdowned.");
    }
  }
}
