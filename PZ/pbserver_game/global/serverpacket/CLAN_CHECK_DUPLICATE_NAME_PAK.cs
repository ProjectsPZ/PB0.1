﻿
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CHECK_DUPLICATE_NAME_PAK : SendPacket
  {
    private uint _erro;

    public CLAN_CHECK_DUPLICATE_NAME_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 1448);
      this.writeD(this._erro);
    }
  }
}
