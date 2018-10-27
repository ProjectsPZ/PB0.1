
using Core;
using Core.server;
using Game.data.model;
using Game.data.utils;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class LOBBY_LEAVE_REC : ReceiveGamePacket
  {
    private uint erro;

    public LOBBY_LEAVE_REC(GameClient client, byte[] data)
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
        if (this._client == null || this._client._player == null)
          return;
        Account player = this._client._player;
        Channel channel = player.getChannel();
        if (player._room != null || player._match != null)
          return;
        if (channel == null || player.Session == null || !channel.RemovePlayer(player))
          this.erro = 2147483648U;
        this._client.SendPacket((SendPacket) new LOBBY_LEAVE_PAK(this.erro));
        if (this.erro == 0U)
        {
          player.ResetPages();
          player._status.updateChannel(byte.MaxValue);
          AllUtils.syncPlayerToFriends(player, false);
          AllUtils.syncPlayerToClanMembers(player);
        }
        else
          this._client.Close(1000, false);
      }
      catch (Exception ex)
      {
        Logger.info("LOBBY_LEAVE_REC: " + ex.ToString());
        this._client.SendPacket((SendPacket) new LOBBY_LEAVE_PAK(2147483648U));
        this._client.Close(1000, false);
      }
    }
  }
}
