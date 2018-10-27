
using Core;
using Core.models.enums.global;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth
{
  public static class ConfigGA
  {
    public static string authIp = "127.0.0.1";
    public static bool isTestMode;
    public static bool Outpost;
    public static bool AUTO_ACCOUNTS;
    public static bool debugMode;
    public static int syncPort;
    public static int configId;
    public static int maxNickSize;
    public static int minNickSize;
    public static int minLoginSize;
    public static int minPassSize;
    public static int maxLoginSize;
    public static int maxPassSize;
    public static int authPort;
    public static float minTimeBetweenCreation;
    public static ulong LauncherKey;
    public static List<ClientLocale> GameLocales;

    public static void Load()
    {
      ConfigFile configFile = new ConfigFile("config/auth.ini");
      ConfigGB.dbHost = configFile.readString("dbhost", "localhost");
      ConfigGB.dbName = configFile.readString("dbname", "");
      ConfigGB.dbUser = configFile.readString("dbuser", "root");
      ConfigGB.dbPass = configFile.readString("dbpass", "");
      ConfigGB.dbPort = configFile.readInt32("dbport", 0);
      ConfigGA.authIp = configFile.readString("authIp", "127.0.0.1");
      ConfigGA.configId = configFile.readInt32("configId", 0);
      ConfigGA.authPort = configFile.readInt32("authPort", 39190);
      ConfigGA.syncPort = configFile.readInt32("syncPort", 0);
      ConfigGA.AUTO_ACCOUNTS = configFile.readBoolean("autoaccounts", false);
      ConfigGA.debugMode = configFile.readBoolean("debugMode", true);
      ConfigGA.isTestMode = configFile.readBoolean("isTestMode", true);
      ConfigGB.EncodeText = Encoding.GetEncoding(configFile.readInt32("EncodingPage", 0));
      ConfigGA.Outpost = configFile.readBoolean("Outpost", false);
      ConfigGA.LauncherKey = configFile.readUInt64("LauncherKey", 0UL);
      ConfigGA.minNickSize = configFile.readInt32("minNickSize", 0);
      ConfigGA.maxNickSize = configFile.readInt32("maxNickSize", 0);
      ConfigGA.minLoginSize = configFile.readInt32("minLoginSize", 0);
      ConfigGA.minPassSize = configFile.readInt32("minPassSize", 0);
      ConfigGA.maxLoginSize = configFile.readInt32("maxLoginSize", 0);
      ConfigGA.maxPassSize = configFile.readInt32("maxPassSize", 0);
      ConfigGA.minTimeBetweenCreation = configFile.readFloat("minTimeBetweenCreation", 0.0f);
      ConfigGA.GameLocales = new List<ClientLocale>();
      string str1 = configFile.readString("GameLocales", "None");
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        ClientLocale result;
        Enum.TryParse<ClientLocale>(str2, out result);
        ConfigGA.GameLocales.Add(result);
      }
    }
  }
}
