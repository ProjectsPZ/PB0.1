
using Core;
using Core.managers.server;
using Game.data.model;

namespace Game.data.chat
{
  public static class EnableMissions
  {
    public static string genCode1(string str, Account player)
    {
      bool mission = bool.Parse(str.Substring(8));
      if (!ServerConfigSyncer.updateMission(GameManager.Config, mission))
        return Translation.GetLabel("ActivateMissionsMsg2");
      Logger.warning(Translation.GetLabel("ActivateMissionsWarn", (object) mission, (object) player.player_name));
      return Translation.GetLabel("ActivateMissionsMsg1");
    }
  }
}
