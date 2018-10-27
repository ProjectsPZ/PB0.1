
using Core.server;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class BASE_CHANNEL_LIST_REC : ReceiveGamePacket
  {
    public BASE_CHANNEL_LIST_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
    }

    public override void run()
    {
      if (this._client._player == null)
        return;
      this._client.SendPacket((SendPacket) new BASE_CHANNEL_LIST_PAK());
    }
  }
}
