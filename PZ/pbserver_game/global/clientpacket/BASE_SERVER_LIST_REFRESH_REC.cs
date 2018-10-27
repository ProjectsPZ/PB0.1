
using Core.server;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class BASE_SERVER_LIST_REFRESH_REC : ReceiveGamePacket
  {
    public BASE_SERVER_LIST_REFRESH_REC(GameClient client, byte[] data)
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
      this._client.SendPacket((SendPacket) new BASE_SERVER_LIST_REFRESH_PAK());
    }
  }
}
