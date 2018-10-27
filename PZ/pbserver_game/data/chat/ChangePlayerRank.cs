
using Core;
using Core.models.account.rank;
using Core.server;
using Core.xml;
using Game.data.managers;
using Game.data.model;
using Game.data.sync.server_side;
using Game.global.serverpacket;
using System;

namespace Game.data.chat
{
  public static class ChangePlayerRank
  {
    public static string SetPlayerRank(string str)
    {
      string[] strArray = str.Substring(str.IndexOf(" ") + 1).Split(' ');
      long int64 = Convert.ToInt64(strArray[0]);
      int int32 = Convert.ToInt32(strArray[1]);
      if (int32 > 60 || int32 == 56 || (int32 < 0 || int64 <= 0L))
        return Translation.GetLabel("ChangePlyRankWrongValue");
      Account account = AccountManager.getAccount(int64, 0);
      if (account == null)
        return Translation.GetLabel("ChangePlyRankFailPlayer");
      if (!ComDiv.updateDB("accounts", "rank", (object) int32, "player_id", (object) account.player_id))
        return Translation.GetLabel("ChangePlyRankFailUnk");
      RankModel rank = RankXML.getRank(int32);
      account._rank = int32;
      SEND_ITEM_INFO.LoadGoldCash(account);
      account.SendPacket((SendPacket) new BASE_RANK_UP_PAK(account._rank, rank != null ? rank._onNextLevel : 0), false);
      if (account._room != null)
        account._room.updateSlotsInfo();
      return Translation.GetLabel("ChangePlyRankSuccess", (object) int32);
    }
  }
}
