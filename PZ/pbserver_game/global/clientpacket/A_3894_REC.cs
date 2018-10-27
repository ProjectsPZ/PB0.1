
using Core;

namespace Game.global.clientpacket
{
  public class A_3894_REC : ReceiveGamePacket
  {
    private int Slot;

    public A_3894_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.Slot = (int) this.readC();
    }

    public override void run()
    {
      if (this._client == null)
        return;
      if (this._client._player == null)
        return;
      try
      {
        Logger.warning("[3894] Slot: " + (object) this.Slot);
      }
      catch
      {
      }
    }
  }
}
