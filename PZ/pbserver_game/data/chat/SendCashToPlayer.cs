
using Core;
using Core.managers;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.data.sync.server_side;
using Game.global.serverpacket;

namespace Game.data.chat
{
  public static class SendCashToPlayer
  {
    public static string SendByNick(string str)
    {
      return SendCashToPlayer.BaseGiveCash(AccountManager.getAccount(str.Substring(3), 1, 0));
    }

    public static string SendById(string str)
    {
      return SendCashToPlayer.BaseGiveCash(AccountManager.getAccount(long.Parse(str.Substring(4)), 0));
    }

    private static string BaseGiveCash(Account pR)
    {
      if (pR == null)
        return Translation.GetLabel("GiveCashFail");
      if (!PlayerManager.updateAccountCash(pR.player_id, pR._money + 3000))
        return Translation.GetLabel("GiveCashFail2");
      pR._money += 3000;
      pR.SendPacket((SendPacket) new AUTH_WEB_CASH_PAK(0, pR._gp, pR._money), false);
      SEND_ITEM_INFO.LoadGoldCash(pR);
      return Translation.GetLabel("GiveCashSuccess", (object) pR.player_name);
    }
  }
}
