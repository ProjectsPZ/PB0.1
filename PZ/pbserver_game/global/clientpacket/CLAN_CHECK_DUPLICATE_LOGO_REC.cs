
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class CLAN_CHECK_DUPLICATE_LOGO_REC : ReceiveGamePacket
  {
    private uint logo;
    private uint erro;

    public CLAN_CHECK_DUPLICATE_LOGO_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.logo = this.readUD();
    }

    public override void run()
    {
      Account player = this._client._player;
      if (player == null || (int) ClanManager.getClan(player.clanId)._logo == (int) this.logo || ClanManager.isClanLogoExist(this.logo))
        this.erro = 2147483648U;
      this._client.SendPacket((SendPacket) new CLAN_CHECK_DUPLICATE_MARK_PAK(this.erro));
    }
  }
}
