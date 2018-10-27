﻿
using Core;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class AUTH_SEND_WHISPER2_REC : ReceiveGamePacket
  {
    private long receiverId;
    private string receiverName;
    private string text;

    public AUTH_SEND_WHISPER2_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.receiverId = this.readQ();
      this.receiverName = this.readS(33);
      this.text = this.readS((int) this.readH());
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null || player.player_id == this.receiverId || player.player_name == this.receiverName)
          return;
        Account account = AccountManager.getAccount(this.receiverId, 0);
        if (account == null || account.player_name != this.receiverName || !account._isOnline)
          this._client.SendPacket((SendPacket) new AUTH_SEND_WHISPER_PAK(this.receiverName, this.text, 2147483648U));
        else
          account.SendPacket((SendPacket) new AUTH_RECV_WHISPER_PAK(player.player_name, this.text, player.UseChatGM()), false);
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
