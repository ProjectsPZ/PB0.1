
using Auth.global.serverpacket;
using Core;
using Core.server;
using System;

namespace Auth.global.clientpacket
{
  public class BASE_SERVER_CHANGE_REC : ReceiveLoginPacket
  {
    public BASE_SERVER_CHANGE_REC(LoginClient client, byte[] data)
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
        if (this._client == null || this._client._player == null)
          return;
        this._client.SendPacket((SendPacket) new BASE_SERVER_CHANGE_PAK(0));
        this._client.Close(0, false);
      }
      catch (Exception ex)
      {
        Logger.warning(ex.ToString());
      }
    }
  }
}
