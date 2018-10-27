﻿
using Auth.data.managers;
using Auth.data.model;
using Core.server;

namespace Auth.data.sync.client_side
{
  public static class Net_Player_Sync
  {
    public static void Load(ReceiveGPacket p)
    {
      long id = p.readQ();
      int num1 = (int) p.readC();
      int num2 = (int) p.readC();
      int num3 = p.readD();
      int num4 = p.readD();
      Account account = AccountManager.getInstance().getAccount(id, true);
      if (account == null || num1 != 0)
        return;
      account._rank = num2;
      account._gp = num3;
      account._money = num4;
    }
  }
}
