
using Core;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CLAN_WAR_PARTY_CONTEXT_REC : ReceiveGamePacket
  {
    private int matchs;

    public CLAN_WAR_PARTY_CONTEXT_REC(GameClient client, byte[] data)
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
        if (player != null && player.clanId > 0)
        {
          Channel channel = player.getChannel();
          if (channel != null && channel._type == 4)
          {
            lock (channel._matchs)
            {
              foreach (Match match in channel._matchs)
              {
                if (match.clan._id == player.clanId)
                  ++this.matchs;
              }
            }
          }
        }
        this._client.SendPacket((SendPacket) new CLAN_WAR_PARTY_CONTEXT_PAK(this.matchs));
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
