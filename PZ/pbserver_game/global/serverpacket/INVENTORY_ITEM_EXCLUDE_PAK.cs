
using Core.server;

namespace Game.global.serverpacket
{
  public class INVENTORY_ITEM_EXCLUDE_PAK : SendPacket
  {
    private long _objId;
    private uint _erro;

    public INVENTORY_ITEM_EXCLUDE_PAK(uint erro, long objId = 0)
    {
      this._erro = erro;
      if (erro != 1U)
        return;
      this._objId = objId;
    }

    public override void write()
    {
      this.writeH((short) 543);
      this.writeD(this._erro);
      if (this._erro != 1U)
        return;
      this.writeQ(this._objId);
    }
  }
}
