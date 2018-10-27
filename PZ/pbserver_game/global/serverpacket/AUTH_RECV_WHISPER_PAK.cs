
using Core.server;

namespace Game.global.serverpacket
{
  public class AUTH_RECV_WHISPER_PAK : SendPacket
  {
    private string _sender;
    private string _msg;
    private bool chatGM;

    public AUTH_RECV_WHISPER_PAK(string sender, string msg, bool chatGM)
    {
      this._sender = sender;
      this._msg = msg;
      this.chatGM = chatGM;
    }

    public override void write()
    {
      this.writeH((short) 294);
      this.writeS(this._sender, 33);
      this.writeC(this.chatGM);
      this.writeH((ushort) (this._msg.Length + 1));
      this.writeS(this._msg, this._msg.Length + 1);
    }
  }
}
