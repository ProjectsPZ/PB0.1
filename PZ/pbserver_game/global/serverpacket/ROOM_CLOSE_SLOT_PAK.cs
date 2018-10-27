
using Core.server;

namespace Game.global.serverpacket
{
  public class ROOM_CLOSE_SLOT_PAK : SendPacket
  {
    private uint _erro;

    public ROOM_CLOSE_SLOT_PAK(uint erro)
    {
      this._erro = erro;
    }

    public override void write()
    {
      this.writeH((short) 3850);
      this.writeD(this._erro);
    }
  }
}
