
using Core;
using Core.managers;
using Core.models.account;
using Core.models.account.clan;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
  public class CLAN_MSG_FOR_PLAYERS_REC : ReceiveGamePacket
  {
    private int type;
    private string message;

    public CLAN_MSG_FOR_PLAYERS_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.type = (int) this.readC();
      this.message = this.readS((int) this.readC());
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (this.message.Length > 120 || player == null)
          return;
        Clan clan = ClanManager.getClan(player.clanId);
        int count = 0;
        if (clan._id > 0 && clan.owner_id == this._client.player_id)
        {
          List<Account> clanPlayers = ClanManager.getClanPlayers(clan._id, this._client.player_id, true);
          for (int index = 0; index < clanPlayers.Count; ++index)
          {
            Account account = clanPlayers[index];
            if ((this.type == 0 || account.clanAccess == 2 && this.type == 1 || account.clanAccess == 3 && this.type == 2) && MessageManager.getMsgsCount(account.player_id) < 100)
            {
              ++count;
              Message message = this.CreateMessage(clan, account.player_id, this._client.player_id);
              if (message != null && account._isOnline)
                account.SendPacket((SendPacket) new BOX_MESSAGE_RECEIVE_PAK(message), false);
            }
          }
        }
        this._client.SendPacket((SendPacket) new CLAN_MSG_FOR_PLAYERS_PAK(count));
        if (count <= 0)
          return;
        this._client.SendPacket((SendPacket) new BOX_MESSAGE_SEND_PAK(0U));
      }
      catch (Exception ex)
      {
        Logger.info("CLAN_MSG_FOR_PLAYERS_REC: " + ex.ToString());
      }
    }

    private Message CreateMessage(Clan clan, long owner, long senderId)
    {
      Message msg = new Message(15.0)
      {
        sender_name = clan._name,
        sender_id = senderId,
        clanId = clan._id,
        type = 4,
        text = this.message,
        state = 1
      };
      if (!MessageManager.CreateMessage(owner, msg))
        return (Message) null;
      return msg;
    }
  }
}
