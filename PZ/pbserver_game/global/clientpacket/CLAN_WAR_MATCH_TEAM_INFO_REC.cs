
using Core;
using Core.server;
using Game.data.model;
using Game.data.xml;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CLAN_WAR_MATCH_TEAM_INFO_REC : ReceiveGamePacket
  {
    private int id;
    private int serverInfo;

    public CLAN_WAR_MATCH_TEAM_INFO_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.id = (int) this.readH();
      this.serverInfo = (int) this.readH();
    }

    public override void run()
    {
      Account player = this._client._player;
      if (player == null)
        return;
      if (player._match == null)
        return;
      try
      {
        Channel channel = ChannelsXML.getChannel(this.serverInfo - this.serverInfo / 10 * 10);
        if (channel != null)
        {
          Match match = channel.getMatch(this.id);
          if (match != null)
            this._client.SendPacket((SendPacket) new CLAN_WAR_MATCH_TEAM_INFO_PAK(0U, match.clan));
          else
            this._client.SendPacket((SendPacket) new CLAN_WAR_MATCH_TEAM_INFO_PAK(2147483648U));
        }
        else
          this._client.SendPacket((SendPacket) new CLAN_WAR_MATCH_TEAM_INFO_PAK(2147483648U));
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
