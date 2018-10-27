
using System;
using System.Threading.Tasks;

namespace Game
{
  public static class LoggerGS
  {
    public static int TestSlot = 1;

    public static async void updateRAM()
    {
      while (true)
      {
        Console.Title = "[GAME] Servidor iniciado com sucesso. [Usuários online: " + (object) GameManager._socketList.Count + "]";
        await Task.Delay(1000);
      }
    }
  }
}
