
using Core;
using Core.server;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class BASE_USER_EXIT_REC : ReceiveGamePacket
  {
    public BASE_USER_EXIT_REC(GameClient client, byte[] data)
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
        this._client.SendPacket((SendPacket) new BASE_USER_EXIT_PAK());
        this._client.Close(1000, false);
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
        this._client.Close(0, false);
      }
    }
  }
}
