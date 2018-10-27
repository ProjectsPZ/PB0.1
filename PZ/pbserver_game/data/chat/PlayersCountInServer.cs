
using Core;
using Core.models.servers;
using Core.xml;

namespace Game.data.chat
{
  public static class PlayersCountInServer
  {
    public static string GetMyServerPlayersCount()
    {
      return Translation.GetLabel("UsersCount", (object) GameManager._socketList.Count, (object) ConfigGS.serverId);
    }

    public static string GetServerPlayersCount(string str)
    {
      int id = int.Parse(str.Substring(9));
      GameServerModel server = ServersXML.getServer(id);
      if (server == null)
        return Translation.GetLabel("UsersInvalid");
      return Translation.GetLabel("UsersCount2", (object) server._LastCount, (object) server._maxPlayers, (object) id);
    }
  }
}
