
using Core;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class LOBBY_GET_ROOMINFO_REC : ReceiveGamePacket
  {
    private int roomId;

    public LOBBY_GET_ROOMINFO_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.roomId = this.readD();
    }

    public override void run()
    {
      if (this._client == null)
        return;
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Channel channel = player.getChannel();
        if (channel == null)
          return;
        Room room = channel.getRoom(this.roomId);
        Account p;
        if (room == null || !room.getLeader(out p))
          return;
        this._client.SendPacket((SendPacket) new LOBBY_GET_ROOMINFO_PAK(room, p));
      }
      catch (Exception ex)
      {
        Logger.warning("[LOBBY_GET_ROOMINFO_REC] " + ex.ToString());
      }
    }
  }
}
