
using Core.models.account.clan;
using Core.server;
using Game.data.managers;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_NEW_INFOS_PAK : SendPacket
  {
    private Clan clan;
    private Account p;
    private int players;

    public CLAN_NEW_INFOS_PAK(Clan c, Account owner, int clanPlayers)
    {
      this.clan = c;
      this.p = owner;
      this.players = clanPlayers;
    }

    public CLAN_NEW_INFOS_PAK(Clan c, int clanPlayers)
    {
      this.clan = c;
      this.p = AccountManager.getAccount(this.clan.owner_id, 0);
      this.players = clanPlayers;
    }

    public override void write()
    {
      this.writeH((short) 1328);
      this.writeD(this.clan._id);
      this.writeS(this.clan._name, 17);
      this.writeC((byte) this.clan._rank);
      this.writeC((byte) this.players);
      this.writeC((byte) this.clan.maxPlayers);
      this.writeD(this.clan.creationDate);
      this.writeD(this.clan._logo);
      this.writeC((byte) this.clan._name_color);
      this.writeC((byte) this.clan.getClanUnit(this.players));
      this.writeD(this.clan._exp);
      this.writeD(0);
      this.writeQ(this.clan.owner_id);
      this.writeS(this.p != null ? this.p.player_name : "", 33);
      this.writeC(this.p != null ? (byte) this.p._rank : (byte) 0);
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
