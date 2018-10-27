
using Auth.global.serverpacket;
using Core;
using Core.server;
using System;

namespace Auth.global.clientpacket
{
  public class A_2678_REC : ReceiveLoginPacket
  {
    public A_2678_REC(LoginClient lc, byte[] buff)
    {
      this.makeme(lc, buff);
    }

    public override void read()
    {
    }

    public override void run()
    {
      try
      {
        this._client.SendPacket((SendPacket) new A_2678_PAK());
      }
      catch (Exception ex)
      {
        Logger.warning(ex.ToString());
      }
    }
  }
}
