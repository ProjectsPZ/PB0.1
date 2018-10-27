
using Core;
using Core.models.room;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class BATTLE_3329_REC : ReceiveGamePacket
  {
    public BATTLE_3329_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Room room = player._room;
        Logger.warning("BATTLE_3329_REC. (PlayerID: " + (object) player.player_id + "; Name: " + player.player_name + "; Room: " + (object) (player._room != null ? player._room._roomId : -1) + "; Channel: " + (object) player.channelId + ")");
        if (room != null)
        {
          Logger.warning("Room3329; BOT: " + room.isBotMode().ToString());
          SLOT slot = room.getSlot(player._slotId);
          if (slot != null)
            Logger.warning("SLOT Id: " + (object) slot._id + "; State: " + (object) slot.state);
        }
        this._client.SendPacket((SendPacket) new A_3329_PAK());
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
