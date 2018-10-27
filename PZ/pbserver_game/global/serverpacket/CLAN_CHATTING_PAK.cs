
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class CLAN_CHATTING_PAK : SendPacket
  {
    private string text;
    private Account p;
    private int type;
    private int bantime;

    public CLAN_CHATTING_PAK(string text, Account player)
    {
      this.text = text;
      this.p = player;
    }

    public CLAN_CHATTING_PAK(int type, int bantime)
    {
      this.type = type;
      this.bantime = bantime;
    }

    public override void write()
    {
      this.writeH((short) 1359);
      this.writeC((byte) this.type);
      if (this.type == 0)
      {
        this.writeC((byte) (this.p.player_name.Length + 1));
        this.writeS(this.p.player_name, this.p.player_name.Length + 1);
        this.writeC(this.p.UseChatGM());
        this.writeC((byte) (this.text.Length + 1));
        this.writeS(this.text, this.text.Length + 1);
      }
      else
        this.writeD(this.bantime);
    }
  }
}
