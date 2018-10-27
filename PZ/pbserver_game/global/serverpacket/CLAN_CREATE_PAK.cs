
using Core.managers;
using Core.models.account.clan;
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_CREATE_PAK : SendPacket
  {
    private Account _p;
    private Clan clan;
    private uint _erro;

    public CLAN_CREATE_PAK(uint erro, Clan clan, Account player)
    {
      this._erro = erro;
      this.clan = clan;
      this._p = player;
    }

    public override void write()
    {
      this.writeH((short) 1311);
      this.writeD(this._erro);
      if (this._erro != 0U)
        return;
      this.writeD(this.clan._id);
      this.writeS(this.clan._name, 17);
      this.writeC((byte) this.clan._rank);
      this.writeC((byte) PlayerManager.getClanPlayers(this.clan._id));
      this.writeC((byte) this.clan.maxPlayers);
      this.writeD(this.clan.creationDate);
      this.writeD(this.clan._logo);
      this.writeB(new byte[10]);
      this.writeQ(this.clan.owner_id);
      this.writeS(this._p.player_name, 33);
      this.writeC((byte) this._p._rank);
      this.writeS(this.clan._info, (int) byte.MaxValue);
      this.writeS("Temp", 21);
      this.writeC((byte) this.clan.limite_rank);
      this.writeC((byte) this.clan.limite_idade);
      this.writeC((byte) this.clan.limite_idade2);
      this.writeC((byte) this.clan.autoridade);
      this.writeS("", (int) byte.MaxValue);
      this.writeB(new byte[104]);
      this.writeT(this.clan._pontos);
      this.writeD(this._p._gp);
    }
  }
}
