
using Auth.data.model;
using Auth.global.serverpacket;
using Core;
using Core.server;
using System;

namespace Auth.global.clientpacket
{
  public class BASE_USER_INVENTORY_REC : ReceiveLoginPacket
  {
    public BASE_USER_INVENTORY_REC(LoginClient client, byte[] data)
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
        if (player == null)
          return;
        this._client.SendPacket((SendPacket) new BASE_USER_INVENTORY_PAK(player._inventory._items));
      }
      catch (Exception ex)
      {
        Logger.warning("[BASE_INVENTORY_REC] " + ex.ToString());
      }
    }
  }
}
