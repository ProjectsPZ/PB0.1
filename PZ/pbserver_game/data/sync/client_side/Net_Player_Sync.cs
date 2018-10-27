
using Core.server;
using Game.data.managers;
using Game.data.model;

namespace Game.data.sync.client_side
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
      Account account = AccountManager.getAccount(id, true);
      if (account == null || num1 != 0)
        return;
      account._rank = num2;
      account._gp = num3;
      account._money = num4;
    }
  }
}
