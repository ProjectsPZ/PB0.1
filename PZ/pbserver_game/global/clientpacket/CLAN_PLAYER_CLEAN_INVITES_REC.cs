
using Core;
using Core.managers;
using Core.server;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CLAN_PLAYER_CLEAN_INVITES_REC : ReceiveGamePacket
  {
    private uint erro;

    public CLAN_PLAYER_CLEAN_INVITES_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void run()
    {
      try
      {
        if (this._client == null || !PlayerManager.DeleteInviteDb(this._client.player_id))
          this.erro = 2147487835U;
        this._client.SendPacket((SendPacket) new CLAN_PLAYER_CLEAN_INVITES_PAK(this.erro));
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }

    public override void read()
    {
    }
  }
}
