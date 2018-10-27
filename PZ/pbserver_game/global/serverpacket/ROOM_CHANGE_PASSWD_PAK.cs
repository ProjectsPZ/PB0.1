
using Core.server;

namespace Game.global.serverpacket
{
  public class ROOM_CHANGE_PASSWD_PAK : SendPacket
  {
    private string _pass;

    public ROOM_CHANGE_PASSWD_PAK(string pass)
    {
      this._pass = pass;
    }

    public override void write()
    {
      this.writeH((short) 3907);
      this.writeS(this._pass, 4);
    }
  }
}
