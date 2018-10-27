
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class GM_LOG_LOBBY_REC : ReceiveGamePacket
  {
    private uint sessionId;

    public GM_LOG_LOBBY_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.sessionId = this.readUD();
    }

    public override void run()
    {
      Account player = this._client._player;
      if (player == null || !player.IsGM())
        return;
      Account p = (Account) null;
      try
      {
        p = AccountManager.getAccount(player.getChannel().getPlayer(this.sessionId)._playerId, true);
      }
      catch
      {
      }
      if (p == null)
        return;
      this._client.SendPacket((SendPacket) new GM_LOG_LOBBY_PAK(p));
    }
  }
}
