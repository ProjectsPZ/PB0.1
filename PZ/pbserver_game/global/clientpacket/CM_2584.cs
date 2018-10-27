
using Core;
using Core.server;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class CM_2584 : ReceiveGamePacket
  {
    public byte[] unk;

    public CM_2584(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.unk = this.readB(59);
    }

    public override void run()
    {
      try
      {
        this._client.SendPacket((SendPacket) new BASE_HACK_PAK(this.unk));
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
