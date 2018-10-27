
using Core;
using Core.managers;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.data.sync.server_side;
using Game.global.serverpacket;

namespace Game.data.chat
{
  public static class SendGoldToPlayer
  {
    public static string SendByNick(string str)
    {
      return SendGoldToPlayer.BaseGiveGold(AccountManager.getAccount(str.Substring(3), 1, 0));
    }

    public static string SendById(string str)
    {
      return SendGoldToPlayer.BaseGiveGold(AccountManager.getAccount(long.Parse(str.Substring(4)), 0));
    }

    private static string BaseGiveGold(Account pR)
    {
      if (pR == null)
        return Translation.GetLabel("GiveGoldFail");
      if (!PlayerManager.updateAccountGold(pR.player_id, pR._gp + 10000))
        return Translation.GetLabel("GiveGoldFail2");
      pR._gp += 10000;
      pR.SendPacket((SendPacket) new AUTH_WEB_CASH_PAK(0, pR._gp, pR._money), false);
      SEND_ITEM_INFO.LoadGoldCash(pR);
      return Translation.GetLabel("GiveGoldSuccess", (object) pR.player_name);
    }
  }
}
