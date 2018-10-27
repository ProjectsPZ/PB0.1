
using Core.models.account;
using Core.models.servers;
using Core.server;
using Game.data.model;

namespace Game.data.sync.server_side
{
  public class SEND_FRIENDS_INFOS
  {
    public static void Load(Account player, Friend friend, int type)
    {
      if (player == null)
        return;
      GameServerModel server = Game_SyncNet.GetServer(player._status);
      if (server == null)
        return;
      using (SendGPacket sendGpacket = new SendGPacket())
      {
        sendGpacket.writeH((short) 17);
        sendGpacket.writeQ(player.player_id);
        sendGpacket.writeC((byte) type);
        sendGpacket.writeQ(friend.player_id);
        if (type != 2)
        {
          sendGpacket.writeC((byte) friend.state);
          sendGpacket.writeC(friend.removed);
        }
        Game_SyncNet.SendPacket(sendGpacket.mstream.ToArray(), server.Connection);
      }
    }
  }
}
