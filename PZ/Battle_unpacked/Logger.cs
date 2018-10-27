
using System;
using System.IO;
using System.Threading;

namespace Battle
{
  public static class Logger
  {
    private static string name = "logs/battle/" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".log";
    private static object Sync = new object();

    private static void DrawText(string text, ConsoleColor color, bool IsAsync = false)
    {
      try
      {
        if (IsAsync)
          new Thread((ThreadStart) (() => Logger.DrawInternal(text, color))).Start();
        else
          Logger.DrawInternal(text, color);
      }
      catch
      {
      }
    }

    private static void DrawInternal(string text, ConsoleColor color)
    {
      lock (Logger.Sync)
      {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Logger.save(text);
      }
    }

    public static void error(string text, bool IsAsync = false)
    {
      Logger.DrawText(text, ConsoleColor.Red, IsAsync);
    }

    public static void warning(string text, bool IsAsync = false)
    {
      Logger.DrawText(text, ConsoleColor.Yellow, IsAsync);
    }

    public static void info(string text, bool IsAsync = false)
    {
      Logger.DrawText(text, ConsoleColor.Gray, IsAsync);
    }

    private static void save(string text)
    {
      using (FileStream fileStream = new FileStream(Logger.name, FileMode.Append))
      {
        using (StreamWriter streamWriter = new StreamWriter((Stream) fileStream))
        {
          try
          {
            if (streamWriter != null)
              streamWriter.WriteLine(text);
          }
          catch
          {
          }
          streamWriter.Close();
          fileStream.Close();
        }
      }
    }

    public static void checkDirectory()
    {
      if (Directory.Exists("logs/battle"))
        return;
      Directory.CreateDirectory("logs/battle");
    }
  }
}
