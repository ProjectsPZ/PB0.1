
using Core;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
  public class CLAN_WAR_PARTY_LIST_REC : ReceiveGamePacket
  {
    private List<Match> partyList = new List<Match>();
    private int page;

    public CLAN_WAR_PARTY_LIST_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.page = (int) this.readC();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        if (player.clanId > 0)
        {
          Channel channel = player.getChannel();
          if (channel != null && channel._type == 4)
          {
            lock (channel._matchs)
            {
              foreach (Match match in channel._matchs)
              {
                if (match.clan._id == player.clanId)
                  this.partyList.Add(match);
              }
            }
          }
        }
        this._client.SendPacket((SendPacket) new CLAN_WAR_PARTY_LIST_PAK(player.clanId == 0 ? 91 : 0, this.partyList));
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
