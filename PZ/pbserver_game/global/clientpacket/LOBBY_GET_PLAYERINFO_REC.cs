
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class LOBBY_GET_PLAYERINFO_REC : ReceiveGamePacket
  {
    private uint sessionId;

    public LOBBY_GET_PLAYERINFO_REC(GameClient client, byte[] data)
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
      if (player == null)
        return;
      Account account = (Account) null;
      try
      {
        account = AccountManager.getAccount(player.getChannel().getPlayer(this.sessionId)._playerId, true);
      }
      catch
      {
      }
      this._client.SendPacket((SendPacket) new LOBBY_GET_PLAYERINFO_PAK(account._statistic));
    }
  }
}
