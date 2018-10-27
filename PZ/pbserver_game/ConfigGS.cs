
using Core;
using Core.models.enums;
using System.Text;

namespace Game
{
  public static class ConfigGS
  {
    public static string passw;
    public static string gameIp;
    public static bool isTestMode;
    public static bool debugMode;
    public static bool winCashPerBattle;
    public static bool showCashReceiveWarn;
    public static bool EnableTournamentRules;
    public static SERVER_UDP_STATE udpType;
    public static float maxClanPoints;
    public static int serverId;
    public static int configId;
    public static int maxBattleLatency;
    public static int maxRepeatLatency;
    public static int syncPort;
    public static int maxActiveClans;
    public static int minRankVote;
    public static int maxNickSize;
    public static int minNickSize;
    public static int maxBattleXP;
    public static int maxBattleGP;
    public static int maxBattleMY;
    public static int maxChannelPlayers;
    public static int gamePort;
    public static int minCreateGold;
    public static int minCreateRank;

    public static void Load()
    {
      ConfigFile configFile = new ConfigFile("config/game.ini");
      ConfigGB.dbHost = configFile.readString("dbhost", "localhost");
      ConfigGB.dbName = configFile.readString("dbname", "");
      ConfigGB.dbUser = configFile.readString("dbuser", "root");
      ConfigGB.dbPass = configFile.readString("dbpass", "");
      ConfigGB.dbPort = configFile.readInt32("dbport", 0);
      ConfigGS.gameIp = configFile.readString("gameIp", "127.0.0.1");
      ConfigGS.serverId = configFile.readInt32("serverId", -1);
      ConfigGS.configId = configFile.readInt32("configId", 0);
      ConfigGS.gamePort = configFile.readInt32("gamePort", 39190);
      ConfigGS.syncPort = configFile.readInt32("syncPort", 0);
      ConfigGS.debugMode = configFile.readBoolean("debugMode", true);
      ConfigGS.isTestMode = configFile.readBoolean("isTestMode", true);
      ConfigGB.EncodeText = Encoding.GetEncoding(configFile.readInt32("EncodingPage", 0));
      ConfigGS.EnableTournamentRules = configFile.readBoolean("EnableTournamentRules", false);
      ConfigGS.winCashPerBattle = configFile.readBoolean("winCashPerBattle", true);
      ConfigGS.showCashReceiveWarn = configFile.readBoolean("showCashReceiveWarn", true);
      ConfigGS.minCreateRank = configFile.readInt32("minCreateRank", 15);
      ConfigGS.minCreateGold = configFile.readInt32("minCreateGold", 7500);
      ConfigGS.maxClanPoints = configFile.readFloat("maxClanPoints", 0.0f);
      ConfigGS.passw = configFile.readString("passw", "");
      ConfigGS.maxChannelPlayers = configFile.readInt32("maxChannelPlayers", 100);
      ConfigGS.maxBattleXP = configFile.readInt32("maxBattleXP", 1000);
      ConfigGS.maxBattleGP = configFile.readInt32("maxBattleGP", 1000);
      ConfigGS.maxBattleMY = configFile.readInt32("maxBattleMY", 1000);
      ConfigGS.udpType = (SERVER_UDP_STATE) configFile.readByte("udpType", (byte) 1);
      ConfigGS.minNickSize = configFile.readInt32("minNickSize", 0);
      ConfigGS.maxNickSize = configFile.readInt32("maxNickSize", 0);
      ConfigGS.minRankVote = configFile.readInt32("minRankVote", 0);
      ConfigGS.maxActiveClans = configFile.readInt32("maxActiveClans", 0);
      ConfigGS.maxBattleLatency = configFile.readInt32("maxBattleLatency", 0);
      ConfigGS.maxRepeatLatency = configFile.readInt32("maxRepeatLatency", 0);
    }
  }
}
