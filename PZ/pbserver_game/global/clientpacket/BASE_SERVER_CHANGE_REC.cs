
using Core;
using Core.server;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class BASE_SERVER_CHANGE_REC : ReceiveGamePacket
  {
    public BASE_SERVER_CHANGE_REC(GameClient client, byte[] data)
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
