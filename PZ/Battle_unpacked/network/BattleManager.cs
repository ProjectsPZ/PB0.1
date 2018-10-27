
using Battle.config;
using System;
using System.Net;
using System.Net.Sockets;

namespace Battle.network
{
  public class BattleManager
  {
    private static UdpClient udpClient;

    public static void init()
    {
      try
      {
        BattleManager.udpClient = new UdpClient();
        uint num = 2147483648u;
        uint num2 = 402653184u;
        uint ioControlCode = num | num2 | 0xC;
        BattleManager.udpClient.Client.IOControl((int) num, new byte[1]
        {
          Convert.ToByte(false)
        }, (byte[]) null);
        IPEndPoint e = new IPEndPoint(IPAddress.Parse(Config.hosIp), (int) Config.hosPort);
        BattleManager.UdpState udpState = new BattleManager.UdpState(e, BattleManager.udpClient);
        BattleManager.udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        BattleManager.udpClient.Client.Bind((EndPoint) e);
        BattleManager.udpClient.BeginReceive(new AsyncCallback(BattleManager.gerenciaRetorno), (object) udpState);
        Logger.warning("[Aviso] Portas abertas! (" + DateTime.Now.ToString("yy/MM/dd HH:mm:ss") + ")", false);
      }
      catch (Exception ex)
      {
        Logger.error(ex.ToString() + "\r\nOcorreu um erro ao listar as conexões UDP!!", false);
      }
    }

    private static void read(BattleManager.UdpState state)
    {
      try
      {
        BattleManager.udpClient.BeginReceive(new AsyncCallback(BattleManager.gerenciaRetorno), (object) state);
      }
      catch (Exception ex)
      {
        Logger.error(ex.ToString(), false);
      }
    }

    private static void gerenciaRetorno(IAsyncResult ar)
    {
      if (!ar.IsCompleted)
        Logger.warning("ar is not completed.", false);
      ar.AsyncWaitHandle.WaitOne(5000);
      DateTime now = DateTime.Now;
      IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
      UdpClient c = ((BattleManager.UdpState) ar.AsyncState).c;
      IPEndPoint e = ((BattleManager.UdpState) ar.AsyncState).e;
      try
      {
        byte[] buff = c.EndReceive(ar, ref remoteEP);
        if (buff.Length >= 22)
        {
          BattleHandler battleHandler = new BattleHandler(BattleManager.udpClient, buff, remoteEP, now);
        }
        else
          Logger.warning("No length (22) buffer: " + BitConverter.ToString(buff), false);
      }
      catch (Exception ex)
      {
        Logger.warning("[Exception]: " + (object) remoteEP.Address + ":" + (object) remoteEP.Port, false);
        Logger.warning(ex.ToString(), false);
      }
      BattleManager.read(new BattleManager.UdpState(e, c));
    }

    public static void Send(byte[] data, IPEndPoint ip)
    {
      BattleManager.udpClient.Send(data, data.Length, ip);
    }

    private class UdpState
    {
      public IPEndPoint e;
      public UdpClient c;

      public UdpState(IPEndPoint e, UdpClient c)
      {
        this.e = e;
        this.c = c;
      }
    }
  }
}
