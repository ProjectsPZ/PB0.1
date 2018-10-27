
using Auth.data.configs;
using Auth.data.sync;
using Auth.data.utils;
using Core;
using Core.managers;
using Core.managers.events;
using Core.managers.server;
using Core.models.account.players;
using Core.server;
using Core.xml;
using CrashReporterDotNET;
using CronMz;
using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Auth
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

    private static void v1(ItemsModel item)
    {
      new ItemsModel(item)._objId = item._objId;
    }

    private static void v2(ItemsModel item)
    {
      item.DeepCopy();
    }

    private static void bb(out byte[] a1)
    {
      a1 = new byte[144];
      using (SendGPacket sendGpacket = new SendGPacket())
      {
        for (int index = 0; index < 16; ++index)
        {
          sendGpacket.writeH(index * 2, (ushort) 10);
          sendGpacket.writeH(32 + index * 2, (ushort) 20);
          sendGpacket.writeH(64 + index * 2, (ushort) 30);
          sendGpacket.writeH(96 + index * 2, (ushort) 40);
          sendGpacket.writeC(128 + index, (byte) 50);
        }
        sendGpacket.mstream.ToArray();
      }
    }

    private static void bb(out byte[] a1, out byte[] a2, out byte[] a3, out byte[] a4, out byte[] a5)
    {
      a1 = new byte[32];
      a2 = new byte[32];
      a3 = new byte[32];
      a4 = new byte[32];
      a5 = new byte[16];
      using (SendGPacket sendGpacket1 = new SendGPacket())
      {
        using (SendGPacket sendGpacket2 = new SendGPacket())
        {
          using (SendGPacket sendGpacket3 = new SendGPacket())
          {
            using (SendGPacket sendGpacket4 = new SendGPacket())
            {
              using (SendGPacket sendGpacket5 = new SendGPacket())
              {
                for (int index = 0; index < 16; ++index)
                {
                  sendGpacket1.writeH((ushort) 10);
                  sendGpacket2.writeH((ushort) 20);
                  sendGpacket3.writeH((ushort) 30);
                  sendGpacket4.writeH((ushort) 40);
                  sendGpacket5.writeC((byte) 50);
                }
                sendGpacket1.mstream.ToArray();
                sendGpacket2.mstream.ToArray();
                sendGpacket3.mstream.ToArray();
                sendGpacket4.mstream.ToArray();
                sendGpacket5.mstream.ToArray();
              }
            }
          }
        }
      }
    }

    private static void testcron()
    {
      Logger.warning("Cron triggered.");
      CronManager.BuildCron(DateTime.Now.AddMinutes(1.0), new Action(Programm.testcron), false);
    }

    private static void Main(string[] args)
    {

      {
        Application.Run((Form) new ip());
      }
      Console.Clear();
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Programm.CurrentDomainOnUnhandledException);
      Console.Title = "Iniciando o Point Blank Auth Server...";
      Logger.StartedFor = "auth";
      Logger.checkDirectorys();
      StringUtil stringUtil = new StringUtil();
      stringUtil.AppendLine("               ________  _____  __      ______ _______          ");
      stringUtil.AppendLine("              / ____/  |/  / / / /     / /  / / /  / /          ");
      stringUtil.AppendLine("             / __/ / /|_/ / / / /     / /__/_/ /__/ /           ");
      stringUtil.AppendLine("            / /___/ /  / / /_/ / _   / /    / /  / /            ");
      stringUtil.AppendLine("                                                                ");
      DateTime dateTime1 = ComDiv.GetLinkerTime(Assembly.GetExecutingAssembly(), (TimeZoneInfo) null);
      string str = dateTime1.ToString("dd/MM/yyyy HH:mm");
      stringUtil.AppendLine("             Data de Inicialização: " + str + "                 ");
      Logger.info(stringUtil.getString());
      ConfigGA.Load();
      ConfigMaps.Load();
      ServerConfigSyncer.GenerateConfig(ConfigGA.configId);
      EventLoader.LoadAll();
      DirectXML.Start();
      BasicInventoryXML.Load();
      ServersXML.Load();
      MissionCardXML.LoadBasicCards(2);
      MapsXML.Load();
      RegionXML.Load();
      ShopManager.Load(2);
      CupomEffectManager.LoadCupomFlags();
      MissionsXML.Load();
      bool flag1 = true;
      foreach (string text in args)
      {
       // if (ComDiv.gen5(text) == "e5cb4b8a5474496fb2f2cddb5dbb07a7")
        if (ComDiv.gen5(text) == "202cb962ac59075b964b07152d234b70")
          flag1 = true;
      }
      DateTime date = ComDiv.GetDate();
      DateTime dateTime2 = date;
      dateTime1 = new DateTime();
      DateTime dateTime3 = dateTime1;
      bool flag2 = dateTime2 == dateTime3 || long.Parse(date.ToString("yyMMddHHmmss")) >= 181024000000L;
      Auth_SyncNet.Start();
      if (flag1)
      {
        bool flag3 = LoginManager.Start();
        Logger.warning("[Servidor] Hospedado: " + ConfigGB.EncodeText.EncodingName);
        Logger.warning("[Servidor] Modo: " + (ConfigGA.isTestMode ? "Testes" : "Público"));
        Logger.warning(Programm.StartSuccess());
        if (flag3)
          LoggerGA.updateRAM2();
      }
      Process.GetCurrentProcess().WaitForExit();
    }

    private static string StartSuccess()
    {
      if (Logger.erro)
        return "[Aviso] Falha na inicialização.";
      return "[Servidor] O Servidor foi iniciado. (" + DateTime.Now.ToString("yy/MM/dd HH:mm:ss") + ")";
    }
  }
}
