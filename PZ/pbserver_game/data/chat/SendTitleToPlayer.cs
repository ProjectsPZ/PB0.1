
using Core;
using Core.managers;
using Core.models.account.title;
using Core.server;
using Core.xml;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.data.chat
{
  public static class SendTitleToPlayer
  {
    public static string SendTitlePlayer(string str)
    {
      Account account = AccountManager.getAccount(Convert.ToInt64(str.Substring(str.IndexOf(" ") + 1).Split(' ')[0]), 0);
      if (account._titles.ownerId == 0L)
      {
        TitleManager.getInstance().CreateTitleDB(account.player_id);
        account._titles = new PlayerTitles()
        {
          ownerId = account.player_id
        };
      }
      PlayerTitles titles = account._titles;
      int num = 0;
      for (int titleId = 1; titleId <= 44; ++titleId)
      {
        TitleQ title = TitlesXML.getTitle(titleId, true);
        if (title != null && !titles.Contains(title._flag))
        {
          ++num;
          titles.Add(title._flag);
          if (titles.Slots < title._slot)
            titles.Slots = title._slot;
        }
      }
      if (num > 0)
      {
        ComDiv.updateDB("player_titles", "titleslots", (object) titles.Slots, "owner_id", (object) account.player_id);
        TitleManager.getInstance().updateTitlesFlags(account.player_id, titles.Flags);
        account.SendPacket((SendPacket) new BASE_2626_PAK(account));
      }
      return Translation.GetLabel("TitleAcquisiton", (object) num);
    }
  }
}
