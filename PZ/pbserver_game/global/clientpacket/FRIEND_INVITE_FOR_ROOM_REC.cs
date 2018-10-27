﻿
using Core;
using Core.models.account;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class FRIEND_INVITE_FOR_ROOM_REC : ReceiveGamePacket
  {
    private int index;

    public FRIEND_INVITE_FOR_ROOM_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.index = (int) this.readC();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Account friend = this.GetFriend(player);
        if (friend != null)
        {
          if (friend._status.serverId == byte.MaxValue || friend._status.serverId == (byte) 0)
            this._client.SendPacket((SendPacket) new FRIEND_INVITE_FOR_ROOM_PAK(2147495938U));
          else if (friend.matchSlot >= 0)
          {
            this._client.SendPacket((SendPacket) new FRIEND_INVITE_FOR_ROOM_PAK(2147495939U));
          }
          else
          {
            int friendIdx = friend.FriendSystem.GetFriendIdx(player.player_id);
            if (friendIdx == -1)
              this._client.SendPacket((SendPacket) new FRIEND_INVITE_FOR_ROOM_PAK(2147487806U));
            else if (friend._isOnline)
              friend.SendPacket((SendPacket) new FRIEND_ROOM_INVITE_PAK(friendIdx), false);
            else
              this._client.SendPacket((SendPacket) new FRIEND_INVITE_FOR_ROOM_PAK(2147487807U));
          }
        }
        else
          this._client.SendPacket((SendPacket) new FRIEND_INVITE_FOR_ROOM_PAK(2147487805U));
      }
      catch (Exception ex)
      {
        Logger.info("[FRIEND_INVITE_FOR_ROOM_REC] " + ex.ToString());
      }
    }

    private Account GetFriend(Account p)
    {
      Friend friend = p.FriendSystem.GetFriend(this.index);
      if (friend == null)
        return (Account) null;
      return AccountManager.getAccount(friend.player_id, 32);
    }
  }
}
