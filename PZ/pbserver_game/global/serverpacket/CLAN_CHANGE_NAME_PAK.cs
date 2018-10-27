
using Core.server;

namespace Game.global.serverpacket
{
  public class CLAN_CHANGE_NAME_PAK : SendPacket
  {
    private string _name;

    public CLAN_CHANGE_NAME_PAK(string name)
    {
      this._name = name;
    }

    public override void write()
    {
      this.writeH((short) 1368);
      this.writeS(this._name, 17);
    }
  }
}
