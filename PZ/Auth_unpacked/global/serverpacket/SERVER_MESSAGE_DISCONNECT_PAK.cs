
using Core.server;
using System;

namespace Auth.global.serverpacket
{
  public class SERVER_MESSAGE_DISCONNECT_PAK : SendPacket
  {
    private uint _erro;
    private bool type;

    public SERVER_MESSAGE_DISCONNECT_PAK(uint erro, bool HackUse)
    {
      this._erro = erro;
      this.type = HackUse;
    }

    public override void write()
    {
      this.writeH((short) 2062);
      this.writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
      this.writeD(this._erro);
      this.writeD(this.type);
      if (!this.type)
        return;
      this.writeD(0);
    }
  }
}
