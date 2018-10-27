
namespace Battle.config
{
  public static class Config
  {
    public static string dbName;
    public static string dbHost;
    public static string dbUser;
    public static string dbPass;
    public static string hosIp;
    public static string serverIp;
    public static string udpVersion;
    public static int dbPort;
    public static ushort hosPort;
    public static ushort maxDrop;
    public static ushort syncPort;
    public static bool isTestMode;
    public static bool sendInfoToServ;
    public static bool sendFailMsg;
    public static bool enableLog;
    public static bool useMaxAmmoInDrop;
    public static bool useHitMarker;
    public static float plantDuration;
    public static float defuseDuration;

    public static void Load()
    {
      ConfigFile configFile = new ConfigFile("config/battle.ini");
      Config.dbHost = configFile.readString("dbhost", "localhost");
      Config.dbName = configFile.readString("dbname", "");
      Config.dbUser = configFile.readString("dbuser", "root");
      Config.dbPass = configFile.readString("dbpass", "");
      Config.dbPort = configFile.readInt32("dbport", 0);
      Config.hosIp = configFile.readString("udpIp", "0.0.0.0");
      Config.serverIp = configFile.readString("serverIp", "0.0.0.0");
      Config.hosPort = configFile.readUInt16("udpPort", (ushort) 40000);
      Config.isTestMode = configFile.readBoolean("isTestMode", true);
      Config.sendInfoToServ = configFile.readBoolean("sendInfoToServ", true);
      Config.sendFailMsg = configFile.readBoolean("sendFailMsg", true);
      Config.enableLog = configFile.readBoolean("enableLog", true);
      Config.maxDrop = configFile.readUInt16("maxDrop", (ushort) 0);
      Config.syncPort = configFile.readUInt16("syncPort", (ushort) 0);
      Config.plantDuration = configFile.readFloat("plantDuration", 1f);
      Config.defuseDuration = configFile.readFloat("defuseDuration", 1f);
      Config.useHitMarker = configFile.readBoolean("useHitMarker", false);
      Config.useMaxAmmoInDrop = configFile.readBoolean("useMaxAmmoInDrop", true);
      Config.udpVersion = configFile.readString("UDPVersion", "0.0");
    }
  }
}
