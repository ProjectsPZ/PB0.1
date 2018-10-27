
using Core;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CLAN_WAR_MATCH_TEAM_CONTEXT_REC : ReceiveGamePacket
  {
    public CLAN_WAR_MATCH_TEAM_CONTEXT_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null || player._match == null)
          return;
        Channel channel = player.getChannel();
        if (channel == null || channel._type != 4)
          return;
        this._client.SendPacket((SendPacket) new CLAN_WAR_MATCH_TEAM_CONTEXT_PAK(channel._matchs.Count));
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
