﻿
using Core.server;

namespace Game.global.serverpacket
{
  public class FRIEND_ACCEPT_PAK : SendPacket
  {
    private uint _erro;

    public FRIEND_ACCEPT_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 281);
      this.writeD(this._erro);
    }
  }
}
