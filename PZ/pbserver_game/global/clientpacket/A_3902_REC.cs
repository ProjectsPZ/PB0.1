
using Core;

namespace Game.global.clientpacket
{
  public class A_3902_REC : ReceiveGamePacket
  {
    public A_3902_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
    }

    public override void run()
    {
      if (this._client == null)
        return;
      if (this._client._player == null)
        return;
      try
      {
        Logger.warning("[3902]");
      }
      catch
      {
      }
    }
  }
}
