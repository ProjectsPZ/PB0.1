
using Core;
using Core.managers;
using Core.models.account.clan;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CLAN_CREATE_INVITE_REC : ReceiveGamePacket
  {
    private int clanId;
    private string text;
    private uint erro;

    public CLAN_CREATE_INVITE_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.clanId = this.readD();
      this.text = this.readS((int) this.readC());
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        ClanInvite invite = new ClanInvite()
        {
          clan_id = this.clanId,
          player_id = this._client.player_id,
          text = this.text,
          inviteDate = int.Parse(DateTime.Now.ToString("yyyyMMdd"))
        };
        if (player.clanId > 0 || player.player_name.Length == 0)
          this.erro = 2147487836U;
        else if (ClanManager.getClan(this.clanId)._id == 0)
          this.erro = 2147483648U;
        else if (PlayerManager.getRequestCount(this.clanId) >= 100)
          this.erro = 2147487831U;
        else if (!PlayerManager.CreateInviteInDb(invite))
          this.erro = 2147487848U;
        this._client.SendPacket((SendPacket) new CLAN_CREATE_INVITE_PAK(this.erro, this.clanId));
      }
      catch (Exception ex)
      {
        Logger.info("[CLAN_CREATE_INVITE_REC] " + ex.ToString());
      }
    }
  }
}
