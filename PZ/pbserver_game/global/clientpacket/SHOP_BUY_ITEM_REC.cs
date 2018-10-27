
using Core;
using Core.managers;
using Core.models.shop;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
  public class SHOP_BUY_ITEM_REC : ReceiveGamePacket
  {
    private List<CartGoods> ShopCart = new List<CartGoods>();

    public SHOP_BUY_ITEM_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      int num = (int) this.readC();
      for (int index = 0; index < num; ++index)
        this.ShopCart.Add(new CartGoods()
        {
          GoodId = this.readD(),
          BuyType = (int) this.readC()
        });
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null || player.player_name.Length == 0)
          this._client.SendPacket((SendPacket) new SHOP_BUY_PAK(2147487767U, (List<GoodItem>) null, (Account) null));
        else if (player._inventory._items.Count >= 500)
        {
          this._client.SendPacket((SendPacket) new SHOP_BUY_PAK(2147487929U, (List<GoodItem>) null, (Account) null));
        }
        else
        {
          int GoldPrice;
          int CashPrice;
          List<GoodItem> goods = ShopManager.getGoods(this.ShopCart, out GoldPrice, out CashPrice);
          if (goods.Count == 0)
            this._client.SendPacket((SendPacket) new SHOP_BUY_PAK(2147487767U, (List<GoodItem>) null, (Account) null));
          else if (0 > player._gp - GoldPrice || 0 > player._money - CashPrice)
            this._client.SendPacket((SendPacket) new SHOP_BUY_PAK(2147487768U, (List<GoodItem>) null, (Account) null));
          else if (PlayerManager.updateAccountCashing(player.player_id, player._gp - GoldPrice, player._money - CashPrice))
          {
            player._gp -= GoldPrice;
            player._money -= CashPrice;
            this._client.SendPacket((SendPacket) new SHOP_BUY_PAK(1U, goods, player));
          }
          else
            this._client.SendPacket((SendPacket) new SHOP_BUY_PAK(2147487769U, (List<GoodItem>) null, (Account) null));
        }
      }
      catch (Exception ex)
      {
        Logger.info("SHOP_BUY_ITEM_REC: " + ex.ToString());
      }
    }
  }
}
