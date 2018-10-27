
using Core;
using Core.models.enums;
using Core.server;
using Game.data.model;
using Game.data.utils;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class LOBBY_ENTER_REC : ReceiveGamePacket
  {
    public LOBBY_ENTER_REC(GameClient client, byte[] data)
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
        if (this._client == null)
          return;
        Account player = this._client._player;
        if (player == null)
          return;
        player.LastLobbyEnter = DateTime.Now;
        if (player.channelId >= 0)
          player.getChannel().AddPlayer(player.Session);
        Room room = player._room;
        if (room != null)
        {
          if (player._slotId < 0 || room._state < RoomState.Loading || room._slots[player._slotId].state < SLOT_STATE.LOAD)
            room.RemovePlayer(player, false, 0);
          else
            goto label_9;
        }
        AllUtils.syncPlayerToFriends(player, false);
        AllUtils.syncPlayerToClanMembers(player);
        AllUtils.GetXmasReward(player);
label_9:
        this._client.SendPacket((SendPacket) new LOBBY_ENTER_PAK());
      }
      catch (Exception ex)
      {
        Logger.warning("[LOBBY_ENTER_REC] " + ex.ToString());
      }
    }
  }
}
