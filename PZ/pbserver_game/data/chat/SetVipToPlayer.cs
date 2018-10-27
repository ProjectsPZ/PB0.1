
using Core;
using Core.managers;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.data.chat
{
  public static class SetVipToPlayer
  {
    public static string SetVipPlayer(string str)
    {
      string[] strArray = str.Substring(str.IndexOf(" ") + 1).Split(' ');
      long int64 = Convert.ToInt64(strArray[0]);
      int int32 = Convert.ToInt32(strArray[1]);
      Account account = AccountManager.getAccount(int64, 0);
      if (account == null)
        return Translation.GetLabel("[*]SetVip_Fail4");
      switch (int32)
      {
        case 0:
        case 1:
        case 2:
          if (!PlayerManager.updateAccountVip(account.player_id, int32))
            return Translation.GetLabel("SetVipF");
          try
          {
            account.SendPacket((SendPacket) new AUTH_ACCOUNT_KICK_PAK(2), false);
            account.Close(1000, true);
            return Translation.GetLabel("SetVipS", (object) int32, (object) account.player_name);
          }
          catch
          {
            return Translation.GetLabel("SetVipF");
          }
        default:
          return Translation.GetLabel("[*]SetVip_Fail4");
      }
    }
  }
}
