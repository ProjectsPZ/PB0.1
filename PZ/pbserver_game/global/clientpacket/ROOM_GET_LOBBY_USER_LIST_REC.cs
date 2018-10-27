
using Core;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class ROOM_GET_LOBBY_USER_LIST_REC : ReceiveGamePacket
  {
    public ROOM_GET_LOBBY_USER_LIST_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
    }

    public override void run()
    {
      Account player = this._client._player;
      if (player == null)
        return;
      try
      {
        Channel channel = player.getChannel();
        if (channel == null)
          return;
        this._client.SendPacket((SendPacket) new ROOM_GET_LOBBY_USER_LIST_PAK(channel));
      }
      catch (Exception ex)
      {
        Logger.warning(ex.ToString());
      }
    }
  }
}
