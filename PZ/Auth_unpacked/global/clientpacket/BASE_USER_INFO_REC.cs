
using Auth.global.serverpacket;
using Core;
using Core.server;
using System;

namespace Auth.global.clientpacket
{
  public class BASE_USER_INFO_REC : ReceiveLoginPacket
  {
    public BASE_USER_INFO_REC(LoginClient client, byte[] data)
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
        this._client.SendPacket((SendPacket) new BASE_USER_INFO_PAK(this._client._player));
      }
      catch (Exception ex)
      {
        Logger.warning("[BASE_USER_INFO_REC] " + ex.ToString());
      }
    }
  }
}
