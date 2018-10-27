
using Core.server;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class BATTLE_ENDTUTORIAL_REC : ReceiveGamePacket
  {
    public BATTLE_ENDTUTORIAL_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
    }

    public override void run()
    {
      if (this._client == null || this._client._player == null)
        return;
      this._client.SendPacket((SendPacket) new BATTLE_TUTORIAL_ROUND_END_PAK());
      this._client.SendPacket((SendPacket) new BATTLE_ENDBATTLE_PAK(this._client._player));
    }
  }
}
