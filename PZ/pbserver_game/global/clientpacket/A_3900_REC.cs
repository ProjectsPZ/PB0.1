
using Core;

namespace Game.global.clientpacket
{
  public class A_3900_REC : ReceiveGamePacket
  {
    private int Slot;
    private string Reason;

    public A_3900_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.Slot = (int) this.readC();
      this.Reason = this.readS((int) this.readC());
    }

    public override void run()
    {
      if (this._client == null)
        return;
      if (this._client._player == null)
        return;
      try
      {
        Logger.warning("[3900] Slot: " + (object) this.Slot + "; Reason: " + this.Reason);
      }
      catch
      {
      }
    }
  }
}
