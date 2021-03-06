﻿
using Core;
using Core.managers;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.data.sync.server_side;
using Game.global.serverpacket;
using System;

namespace Game.data.chat
{
  public static class SetGoldToPlayer
  {
    public static string SetGdToPlayer(string str)
    {
      string[] strArray = str.Substring(str.IndexOf(" ") + 1).Split(' ');
      long int64 = Convert.ToInt64(strArray[0]);
      int int32 = Convert.ToInt32(strArray[1]);
      Account account = AccountManager.getAccount(int64, 0);
      if (account == null || account._gp + int32 > 999999999 || int32 < 0)
        return Translation.GetLabel("[*]SendGold_Fail4");
      if (!PlayerManager.updateAccountCash(account.player_id, account._gp = int32))
        return Translation.GetLabel("[*]GiveGoldFail2");
      account._gp = int32;
      account.SendPacket((SendPacket) new AUTH_WEB_CASH_PAK(0, account._gp, account._money), false);
      SEND_ITEM_INFO.LoadGoldCash(account);
      return Translation.GetLabel("GiveGoldSuccessD", (object) account._gp, (object) account.player_name);
    }
  }
}
