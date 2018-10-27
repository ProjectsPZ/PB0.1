
using Core.server;
using Game.data.model;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class LOBBY_GET_PLAYERINFO2_REC : ReceiveGamePacket
  {
    private uint sessionId;

    public LOBBY_GET_PLAYERINFO2_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.sessionId = this.readUD();
    }

    public override void run()
    {
      Account player1 = this._client._player;
      if (player1 == null)
        return;
      long player2 = 0;
      try
      {
        player2 = player1.getChannel().getPlayer(this.sessionId)._playerId;
      }
      catch
      {
      }
      this._client.SendPacket((SendPacket) new LOBBY_GET_PLAYERINFO2_PAK(player2));
    }
  }
}
