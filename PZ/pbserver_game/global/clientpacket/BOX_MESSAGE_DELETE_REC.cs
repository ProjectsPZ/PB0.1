
using Core;
using Core.managers;
using Core.server;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
  public class BOX_MESSAGE_DELETE_REC : ReceiveGamePacket
  {
    private List<object> objs = new List<object>();
    private uint erro;

    public BOX_MESSAGE_DELETE_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      int num = (int) this.readC();
      for (int index = 0; index < num; ++index)
        this.objs.Add((object) this.readD());
    }

    public override void run()
    {
      if (this._client._player == null)
        return;
      try
      {
        if (!MessageManager.DeleteMessages(this.objs, this._client.player_id))
          this.erro = 2147483648U;
        this._client.SendPacket((SendPacket) new BOX_MESSAGE_DELETE_PAK(this.erro, this.objs));
        this.objs = (List<object>) null;
      }
      catch (Exception ex)
      {
        Logger.info("[BOX_MESSAGE_DELETE_REC] " + ex.ToString());
      }
    }
  }
}
