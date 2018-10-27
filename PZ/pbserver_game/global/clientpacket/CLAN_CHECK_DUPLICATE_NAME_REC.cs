﻿
using Core.server;
using Game.data.managers;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class CLAN_CHECK_DUPLICATE_NAME_REC : ReceiveGamePacket
  {
    private string clanName;

    public CLAN_CHECK_DUPLICATE_NAME_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.clanName = this.readS((int) this.readC());
    }

    public override void run()
    {
      if (this._client == null)
        return;
      if (this._client._player == null)
        return;
      try
      {
        this._client.SendPacket((SendPacket) new CLAN_CHECK_DUPLICATE_NAME_PAK(!ClanManager.isClanNameExist(this.clanName) ? 0U : 2147483648U));
      }
      catch
      {
      }
    }
  }
}
