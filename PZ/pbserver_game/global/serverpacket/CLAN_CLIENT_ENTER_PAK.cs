
using Core.server;
using Game.data.managers;
using System;

namespace Game.global.serverpacket
{
  public class CLAN_CLIENT_ENTER_PAK : SendPacket
  {
    private int _type;
    private int _clanId;

    public CLAN_CLIENT_ENTER_PAK(int id, int access)
    {
      this._clanId = id;
      this._type = access;
    }

    public override void write()
    {
      this.writeH((short) 1442);
      this.writeD(this._clanId);
      this.writeD(this._type);
      if (this._clanId != 0 && this._type != 0)
        return;
      this.writeD(ClanManager._clans.Count);
      this.writeC((byte) 170);
      this.writeH((ushort) Math.Ceiling((double) ClanManager._clans.Count / 170.0));
      this.writeD(uint.Parse(DateTime.Now.ToString("MMddHHmmss")));
    }
  }
}
