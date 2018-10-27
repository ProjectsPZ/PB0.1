
using Core;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CLAN_ROOM_INVITED_REC : ReceiveGamePacket
  {
    private long pId;

    public CLAN_ROOM_INVITED_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.pId = this.readQ();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null || player.clanId == 0)
          return;
        Account account = AccountManager.getAccount(this.pId, 0);
        if (account == null || account.clanId != player.clanId)
          return;
        account.SendPacket((SendPacket) new CLAN_ROOM_INVITE_RESULT_PAK(this._client.player_id), false);
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
