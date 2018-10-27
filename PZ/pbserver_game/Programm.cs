
using Core;
using Core.filters;
using Core.managers;
using Core.managers.events;
using Core.managers.server;
using Core.models.account.players;
using Core.server;
using Core.sql;
using Core.xml;
using CrashReporterDotNET;
using Game.data.managers;
using Game.data.sync;
using Game.data.xml;
using Npgsql;
using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Game
{
  public class Programm
  {
    private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      Programm.ReportCrash(e.Exception, "");
    }

    public static void ReportCrash(Exception exception, string developerMessage = "")
    {
      new ReportCrash("hamiltonmdg@gmail.com")
      {
        DeveloperMessage = developerMessage
      }.Send(exception);
    }

    private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
    {
      Programm.ReportCrash((Exception) unhandledExceptionEventArgs.ExceptionObject, "");
      Environment.Exit(0);
    }

    public static void Main(string[] args)
    {
      
      
      {
        Application.Run((Form) new ip());
       
      }

      Console.Clear();
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Programm.CurrentDomainOnUnhandledException);
      Console.Title = "Iniciando o Point Blank Game Server...";
      Logger.StartedFor = "game";
      Logger.checkDirectorys();
      StringUtil stringUtil = new StringUtil();
      stringUtil.AppendLine("               ________  _____  __      ______ _______          ");
      stringUtil.AppendLine("              / ____/  |/  / / / /     / /  / / /  / /          ");
      stringUtil.AppendLine("             / __/ / /|_/ / / / /     / /__/_/ /__/ /           ");
      stringUtil.AppendLine("            / /___/ /  / / /_/ / _   / /    / /  / /            ");
      stringUtil.AppendLine("                                                                ");
      string str = ComDiv.GetLinkerTime(Assembly.GetExecutingAssembly(), (TimeZoneInfo) null).ToString("dd/MM/yyyy HH:mm");
      stringUtil.AppendLine("             Data de Inicialização: " + str + "                 ");
      Logger.info(stringUtil.getString());
      ConfigGS.Load();
      ComDiv.GetDate();
      BasicInventoryXML.Load();
      ServerConfigSyncer.GenerateConfig(ConfigGS.configId);
      ServersXML.Load();
      ChannelsXML.Load(ConfigGS.serverId);
      EventLoader.LoadAll();
      TitlesXML.Load();
      TitleAwardsXML.Load();
      ClanManager.Load();
      NickFilter.Load();
      MissionCardXML.LoadBasicCards(1);
      BattleServerXML.Load();
      RankXML.Load();
      RankXML.LoadAwards();
      ClanRankXML.Load();
      MissionAwards.Load();
      MissionsXML.Load();
      Translation.Load();
      ShopManager.Load(1);
      TorunamentRulesManager.LoadList();
      RandomBoxXML.LoadBoxes();
      CupomEffectManager.LoadCupomFlags();
      bool flag1 = true;
      foreach (string text in args)
      {
        if (ComDiv.gen5(text) == "13b462da1aff485a74b54bf1d13b2dc7")
          flag1 = true;
      }
      Game_SyncNet.Start();
      if (flag1)
      {
        bool flag2 = GameManager.Start();
        Logger.warning("[Aviso] Padrão de textos: " + ConfigGB.EncodeText.EncodingName);
        Logger.warning("[Aviso] Modo atual: " + (ConfigGS.isTestMode ? "Testes" : "Público"));
        Logger.warning(Programm.StartSuccess());
        if (flag2)
          LoggerGS.updateRAM();
      }
      Process.GetCurrentProcess().WaitForExit();
    }

    private static string StartSuccess()
    {
      if (Logger.erro)
        return "[Aviso] Falha na inicialização.";
      return "[Aviso] Servidor ativo. (" + DateTime.Now.ToString("yy/MM/dd HH:mm:ss") + ")";
    }

    public static bool Create(int rank, ItemsModel msg)
    {
      try
      {
        using (NpgsqlConnection npgsqlConnection = SQLjec.getInstance().conn())
        {
          NpgsqlCommand command = npgsqlConnection.CreateCommand();
          npgsqlConnection.Open();
          command.Parameters.AddWithValue("@rank", (object) rank);
          command.Parameters.AddWithValue("@id", (object) msg._id);
          command.Parameters.AddWithValue("@name", (object) msg._name);
          command.Parameters.AddWithValue("@count", (object) (int) msg._count);
          command.Parameters.AddWithValue("@equip", (object) msg._equip);
          command.CommandType = CommandType.Text;
          command.CommandText = "INSERT INTO info_rank_awards(rank_id,item_id,item_name,item_count,item_equip)VALUES(@rank,@id,@name,@count,@equip)";
          command.ExecuteNonQuery();
          command.Dispose();
          npgsqlConnection.Dispose();
          npgsqlConnection.Close();
          return true;
        }
      }
      catch
      {
        return false;
      }
    }
  }
}
