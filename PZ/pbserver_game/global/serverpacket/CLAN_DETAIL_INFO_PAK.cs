
using Core.managers;
using Core.models.account.clan;
using Core.server;
using Game.data.managers;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_DETAIL_INFO_PAK : SendPacket
  {
    private Clan clan;
    private int _erro;

    public CLAN_DETAIL_INFO_PAK(int erro, Clan c)
    {
      this._erro = erro;
      this.clan = c;
    }

    public override void write()
    {
      Account account = AccountManager.getAccount(this.clan.owner_id, 0);
      int clanPlayers = PlayerManager.getClanPlayers(this.clan._id);
      this.writeH((short) 1305);
      this.writeD(this._erro);
      this.writeD(this.clan._id);
      this.writeS(this.clan._name, 17);
      this.writeC((byte) this.clan._rank);
      this.writeC((byte) clanPlayers);
      this.writeC((byte) this.clan.maxPlayers);
      this.writeD(this.clan.creationDate);
      this.writeD(this.clan._logo);
      this.writeC((byte) this.clan._name_color);
      this.writeC((byte) this.clan.getClanUnit());
      this.writeD(this.clan._exp);
      this.writeD(10);
      this.writeQ(this.clan.owner_id);
      this.writeS(account != null ? account.player_name : "", 33);
      this.writeC(account != null ? (byte) account._rank : (byte) 0);
      this.writeS(this.clan._info, (int) byte.MaxValue);
      this.writeS("Temp", 21);
      this.writeC((byte) this.clan.limite_rank);
      this.writeC((byte) this.clan.limite_idade);
      this.writeC((byte) this.clan.limite_idade2);
      this.writeC((byte) this.clan.autoridade);
      this.writeS(this.clan._news, (int) byte.MaxValue);
      this.writeD(this.clan.partidas);
      this.writeD(this.clan.vitorias);
      this.writeD(this.clan.derrotas);
      this.writeD(this.clan.partidas);
      this.writeD(this.clan.vitorias);
      this.writeD(this.clan.derrotas);
      this.writeQ(this.clan.BestPlayers.Exp.PlayerId);
      this.writeQ(this.clan.BestPlayers.Exp.PlayerId);
      this.writeQ(this.clan.BestPlayers.Wins.PlayerId);
      this.writeQ(this.clan.BestPlayers.Wins.PlayerId);
      this.writeQ(this.clan.BestPlayers.Kills.PlayerId);
      this.writeQ(this.clan.BestPlayers.Kills.PlayerId);
      this.writeQ(this.clan.BestPlayers.Headshot.PlayerId);
      this.writeQ(this.clan.BestPlayers.Headshot.PlayerId);
      this.writeQ(this.clan.BestPlayers.Participation.PlayerId);
      this.writeQ(this.clan.BestPlayers.Participation.PlayerId);
      this.writeT(this.clan._pontos);
    }
  }
}
