
using Core.managers;
using Core.server;

namespace Game.global.serverpacket
{
  public class SHOP_GET_MATCHING_PAK : SendPacket
  {
    private int _tudo;
    private ShopData data;

    public SHOP_GET_MATCHING_PAK(ShopData data, int tudo)
    {
      this.data = data;
      this._tudo = tudo;
    }

    public override void write()
    {
      this.writeH((short) 527);
      this.writeD(this._tudo);
      this.writeD(this.data.ItemsCount);
      this.writeD(this.data.Offset);
      this.writeB(this.data.Buffer);
      this.writeD(44);
    }
  }
}
