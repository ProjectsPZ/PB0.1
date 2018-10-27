
using Core.server;

namespace Game.global.serverpacket
{
  public class BASE_TITLE_GET_PAK : SendPacket
  {
    private int _slots;
    private uint _erro;

    public BASE_TITLE_GET_PAK(uint erro, int slots)
    {
      this._erro = erro;
      this._slots = slots;
    }

    public override void write()
    {
      this.writeH((short) 2620);
      this.writeD(this._erro);
      this.writeD(this._slots);
    }
  }
}
