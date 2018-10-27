
using Core;
using Core.models.account.clan;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CLAN_CHECK_CREATE_INVITE_REC : ReceiveGamePacket
  {
    private int clanId;
    private uint erro;

    public CLAN_CHECK_CREATE_INVITE_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.clanId = this.readD();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Clan clan = ClanManager.getClan(this.clanId);
        if (clan._id == 0)
          this.erro = 2147483648U;
        else if (clan.limite_rank > player._rank)
          this.erro = 2147487867U;
        this._client.SendPacket((SendPacket) new CLAN_CHECK_CREATE_INVITE_PAK(this.erro));
      }
      catch (Exception ex)
      {
        Logger.info("CLAN_CHECK_CREATE_INVITE_REC: " + ex.ToString());
      }
    }
  }
}
