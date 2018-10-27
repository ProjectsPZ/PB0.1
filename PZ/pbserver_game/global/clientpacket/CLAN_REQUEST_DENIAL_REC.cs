
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
  public class CLAN_REQUEST_DENIAL_REC : ReceiveGamePacket
  {
    private int result;

    public CLAN_REQUEST_DENIAL_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      Account player = this._client._player;
      if (player == null)
        return;
      Clan clan = ClanManager.getClan(player.clanId);
      if (clan._id <= 0 || (player.clanAccess < 1 || player.clanAccess > 2) && clan.owner_id != player.player_id)
        return;
      int num1 = (int) this.readC();
      for (int index = 0; index < num1; ++index)
      {
        long num2 = this.readQ();
        if (PlayerManager.DeleteInviteDb(clan._id, num2))
        {
          if (MessageManager.getMsgsCount(num2) < 100)
          {
            Message message = this.CreateMessage(clan, num2, player.player_id);
            if (message != null)
            {
              Account account = AccountManager.getAccount(num2, 0);
              if (account != null && account._isOnline)
                account.SendPacket((SendPacket) new BOX_MESSAGE_RECEIVE_PAK(message), false);
            }
          }
          ++this.result;
        }
      }
    }

    public override void run()
    {
      try
      {
        this._client.SendPacket((SendPacket) new CLAN_REQUEST_DENIAL_PAK(this.result));
      }
      catch (Exception ex)
      {
        Logger.info("[CLAN_REQUEST_DENIAL_REC] " + ex.ToString());
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
        cB = NoteMessageClan.InviteDenial
      };
      if (!MessageManager.CreateMessage(owner, msg))
        return (Message) null;
      return msg;
    }
  }
}
