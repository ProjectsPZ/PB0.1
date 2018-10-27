
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
  public class CLAN_SAVEINFO3_REC : ReceiveGamePacket
  {
    private int limite_rank;
    private int limite_idade;
    private int limite_idade2;
    private int autoridade;
    private uint erro;

    public CLAN_SAVEINFO3_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.autoridade = (int) this.readC();
      this.limite_rank = (int) this.readC();
      this.limite_idade = (int) this.readC();
      this.limite_idade2 = (int) this.readC();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Clan clan = ClanManager.getClan(player.clanId);
        if (clan._id > 0 && clan.owner_id == this._client.player_id && PlayerManager.updateClanInfo(clan._id, this.autoridade, this.limite_rank, this.limite_idade, this.limite_idade2))
        {
          clan.autoridade = this.autoridade;
          clan.limite_rank = this.limite_rank;
          clan.limite_idade = this.limite_idade;
          clan.limite_idade2 = this.limite_idade2;
        }
        else
          this.erro = 2147483648U;
        this._client.SendPacket((SendPacket) new CLAN_SAVEINFO3_PAK(this.erro));
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
