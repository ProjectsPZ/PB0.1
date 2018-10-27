
using Auth.data.model;
using Auth.global.serverpacket;
using Core;
using Core.managers;
using Core.models.account;
using Core.server;
using System;
using System.Collections.Generic;

namespace Auth.global.clientpacket
{
  public class BASE_USER_GIFTLIST_REC : ReceiveLoginPacket
  {
    public BASE_USER_GIFTLIST_REC(LoginClient lc, byte[] buff)
    {
      this.makeme(lc, buff);
    }

    public override void read()
    {
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null || !LoginManager.Config.GiftSystem)
          return;
        List<Message> gifts = MessageManager.getGifts(player.player_id);
        if (gifts.Count <= 0)
          return;
        MessageManager.RecicleMessages(player.player_id, gifts);
        if (gifts.Count <= 0)
          return;
        this._client.SendPacket((SendPacket) new BASE_USER_GIFT_LIST_PAK(0, gifts));
      }
      catch (Exception ex)
      {
        Logger.warning(ex.ToString());
      }
    }
  }
}
