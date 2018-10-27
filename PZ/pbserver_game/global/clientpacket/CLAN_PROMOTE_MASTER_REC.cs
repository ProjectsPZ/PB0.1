
using Core;
using Core.managers;
using Core.models.account;
using Core.models.account.clan;
using Core.models.enums;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CLAN_PROMOTE_MASTER_REC : ReceiveGamePacket
  {
    private long memberId;
    private uint erro;

    public CLAN_PROMOTE_MASTER_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.memberId = this.readQ();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null || player.clanAccess != 1)
          return;
        Account account = AccountManager.getAccount(this.memberId, 0);
        int clanId = player.clanId;
        if (account == null || account.clanId != clanId)
          this.erro = 2147483648U;
        else if (account._rank > 10)
        {
          Clan clan = ClanManager.getClan(clanId);
          if (clan._id > 0 && clan.owner_id == this._client.player_id && (account.clanAccess == 2 && ComDiv.updateDB("clan_data", "owner_id", (object) this.memberId, "clan_id", (object) clanId)) && (ComDiv.updateDB("accounts", "clanaccess", (object) 1, "player_id", (object) this.memberId) && ComDiv.updateDB("accounts", "clanaccess", (object) 2, "player_id", (object) player.player_id)))
          {
            account.clanAccess = 1;
            player.clanAccess = 2;
            clan.owner_id = this.memberId;
            if (MessageManager.getMsgsCount(account.player_id) < 100)
            {
              Message message = this.CreateMessage(clan, account.player_id, player.player_id);
              if (message != null && account._isOnline)
                account.SendPacket((SendPacket) new BOX_MESSAGE_RECEIVE_PAK(message), false);
            }
            if (account._isOnline)
              account.SendPacket((SendPacket) new CLAN_PRIVILEGES_MASTER_PAK(), false);
          }
          else
            this.erro = 2147487744U;
        }
        else
          this.erro = 2147487928U;
        this._client.SendPacket((SendPacket) new CLAN_COMMISSION_MASTER_PAK(this.erro));
      }
      catch (Exception ex)
      {
        Logger.info("[CLAN_PROMOTE_MASTER_REC] " + ex.ToString());
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
        state = 1,
        cB = NoteMessageClan.Master
      };
      if (!MessageManager.CreateMessage(owner, msg))
        return (Message) null;
      return msg;
    }
  }
}
