
using Core;
using Core.server;
using Game.data.model;
using Game.data.xml;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CLAN_WAR_JOIN_TEAM_REC : ReceiveGamePacket
  {
    private int matchId;
    private int serverInfo;
    private int type;
    private uint erro;

    public CLAN_WAR_JOIN_TEAM_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.matchId = (int) this.readH();
      this.serverInfo = (int) this.readH();
      this.type = (int) this.readC();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (this.type >= 2 || player == null || (player._match != null || player._room != null))
        {
          this._client.SendPacket((SendPacket) new CLAN_WAR_JOIN_TEAM_PAK(2147483648U, (Match) null));
        }
        else
        {
          Channel channel = ChannelsXML.getChannel(this.type == 0 ? this.serverInfo - this.serverInfo / 10 * 10 : player.channelId);
          if (channel != null)
          {
            if (player.clanId == 0)
            {
              this._client.SendPacket((SendPacket) new CLAN_WAR_JOIN_TEAM_PAK(2147487835U, (Match) null));
            }
            else
            {
              Match mt = this.type == 1 ? channel.getMatch(this.matchId, player.clanId) : channel.getMatch(this.matchId);
              if (mt != null)
                this.JoinPlayer(player, mt);
              else
                this._client.SendPacket((SendPacket) new CLAN_WAR_JOIN_TEAM_PAK(2147483648U, (Match) null));
            }
          }
          else
            this._client.SendPacket((SendPacket) new CLAN_WAR_JOIN_TEAM_PAK(2147483648U, (Match) null));
        }
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }

    private void JoinPlayer(Account p, Match mt)
    {
      if (!mt.addPlayer(p))
        this.erro = 2147483648U;
      this._client.SendPacket((SendPacket) new CLAN_WAR_JOIN_TEAM_PAK(this.erro, mt));
      if (this.erro != 0U)
        return;
      using (CLAN_WAR_REGIST_MERCENARY_PAK registMercenaryPak = new CLAN_WAR_REGIST_MERCENARY_PAK(mt))
        mt.SendPacketToPlayers((SendPacket) registMercenaryPak);
    }
  }
}
