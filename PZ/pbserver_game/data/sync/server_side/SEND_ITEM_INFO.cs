
using Core.models.account.players;
using Core.models.servers;
using Core.server;
using Game.data.model;

namespace Game.data.sync.server_side
{
  public class SEND_ITEM_INFO
  {
    public static void LoadItem(Account player, ItemsModel item)
    {
      if (player == null || player._status.serverId == (byte) 0)
        return;
      GameServerModel server = Game_SyncNet.GetServer(player._status);
      if (server == null)
        return;
      using (SendGPacket sendGpacket = new SendGPacket())
      {
        sendGpacket.writeH((short) 18);
        sendGpacket.writeQ(player.player_id);
        sendGpacket.writeQ(item._objId);
        sendGpacket.writeD(item._id);
        sendGpacket.writeC((byte) item._equip);
        sendGpacket.writeC((byte) item._category);
        sendGpacket.writeD(item._count);
        Game_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), server.Connection);
      }
    }

    public static void LoadGoldCash(Account player)
    {
      if (player == null)
        return;
      GameServerModel server = Game_SyncNet.GetServer(player._status);
      if (server == null)
        return;
      using (SendGPacket sendGpacket = new SendGPacket())
      {
        sendGpacket.writeH((short) 19);
        sendGpacket.writeQ(player.player_id);
        sendGpacket.writeC((byte) 0);
        sendGpacket.writeC((byte) player._rank);
        sendGpacket.writeD(player._gp);
        sendGpacket.writeD(player._money);
        Game_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), server.Connection);
      }
    }
  }
}
