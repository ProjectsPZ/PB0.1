
using Core;

namespace Game.data.chat
{
  public static class AFK_Interaction
  {
    public static string GetAFKCount(string str)
    {
      return Translation.GetLabel("AFK_Count_Success", (object) GameManager.GetInactiveClientsCount(double.Parse(str.Substring(9))));
    }

    public static string KickAFKPlayers(string str)
    {
      return Translation.GetLabel("AFK_Kick_Success", (object) GameManager.KickInactiveClients(double.Parse(str.Substring(8))));
    }
  }
}
