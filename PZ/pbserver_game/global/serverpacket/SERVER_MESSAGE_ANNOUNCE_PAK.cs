
using Core;
using Core.server;

namespace Game.global.serverpacket
{
  public class SERVER_MESSAGE_ANNOUNCE_PAK : SendPacket
  {
    private string _message;

    public SERVER_MESSAGE_ANNOUNCE_PAK(string msg)
    {
      this._message = msg;
      if (msg.Length < 1024)
        return;
      Logger.error("[GM] Mensagem com tamanho maior a 1024 enviada!!");
    }

    public override void write()
    {
      this.writeH((short) 2055);
      this.writeD(2);
      this.writeH((ushort) this._message.Length);
      this.writeS(this._message);
    }
  }
}
