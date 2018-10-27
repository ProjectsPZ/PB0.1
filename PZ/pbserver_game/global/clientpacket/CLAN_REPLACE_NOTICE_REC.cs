
using Core.models.account.clan;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class CLAN_REPLACE_NOTICE_REC : ReceiveGamePacket
  {
    private string clan_news;
    private uint erro;

    public CLAN_REPLACE_NOTICE_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.clan_news = this.readS((int) this.readC());
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player != null)
        {
          Clan clan = ClanManager.getClan(player.clanId);
          if (clan._id > 0 && clan._news != this.clan_news && (clan.owner_id == this._client.player_id || player.clanAccess >= 1 && player.clanAccess <= 2))
          {
            if (ComDiv.updateDB("clan_data", "clan_news", (object) this.clan_news, "clan_id", (object) clan._id))
              clan._news = this.clan_news;
            else
              this.erro = 2147487859U;
          }
          else
            this.erro = 2147487835U;
        }
        else
          this.erro = 2147487835U;
      }
      catch
      {
        this.erro = 2147487859U;
      }
      this._client.SendPacket((SendPacket) new CLAN_REPLACE_NOTICE_PAK(this.erro));
    }
  }
}
