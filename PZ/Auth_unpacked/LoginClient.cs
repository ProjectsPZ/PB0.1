
using Auth.data.model;
using Auth.data.sync;
using Auth.data.sync.server_side;
using Auth.global;
using Auth.global.clientpacket;
using Auth.global.serverpacket;
using Core;
using Core.server;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

namespace Auth
{
  public class LoginClient : IDisposable
  {
    private SafeHandle handle = (SafeHandle) new SafeFileHandle(IntPtr.Zero, true);
    public Socket _client;
    public Account _player;
    public DateTime ConnectDate;
    public uint SessionId;
    public ushort SessionSeed;
    public int Shift;
    public int NextSessionSeed;
    public int firstPacketId;
    private byte[] lastCompleteBuffer;
    private bool disposed;
    private bool closed;

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      this._player = (Account) null;
      if (this._client != null)
      {
        this._client.Dispose();
        this._client = (Socket) null;
      }
      if (disposing)
        this.handle.Dispose();
      this.disposed = true;
    }

    public LoginClient(Socket client)
    {
      this._client = client;
      this._client.NoDelay = true;
    }

    public void Start()
    {
      this.SessionSeed = (ushort) new Random().Next(0, (int) short.MaxValue);
      this.NextSessionSeed = (int) this.SessionSeed;
      this.Shift = (int) (this.SessionId % 7U) + 1;
      new Thread(new ThreadStart(this.init)).Start();
      new Thread(new ThreadStart(this.read)).Start();
      new Thread(new ThreadStart(this.ConnectionCheck)).Start();
      this.ConnectDate = DateTime.Now;
    }

    private void ConnectionCheck()
    {
      Thread.Sleep(10000);
      if (this._client == null)
        return;
      int firstPacketId = this.firstPacketId;
    }

    public string GetIPAddress()
    {
      if (this._client != null && this._client.RemoteEndPoint != null)
        return ((IPEndPoint) this._client.RemoteEndPoint).Address.ToString();
      return "";
    }

    public IPAddress GetAddress()
    {
      if (this._client != null && this._client.RemoteEndPoint != null)
        return ((IPEndPoint) this._client.RemoteEndPoint).Address;
      return (IPAddress) null;
    }

    private void init()
    {
      this.SendPacket((SendPacket) new BASE_SERVER_LIST_PAK(this));
    }

    public void SendCompletePacket(byte[] data)
    {
      try
      {
        if (data.Length < 4)
          return;
        if (ConfigGA.debugMode)
        {
          ushort uint16 = BitConverter.ToUInt16(data, 2);
          string str1 = "";
          string str2 = BitConverter.ToString(data);
          char[] chArray = new char[5]
          {
            '-',
            ',',
            '.',
            ':',
            '\t'
          };
          foreach (string str3 in str2.Split(chArray))
            str1 = str1 + " " + str3;
          Logger.warning("[" + (object) uint16 + "]" + str1);
        }
        this._client.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), (object) this._client);
      }
      catch
      {
        this.Close(0, true);
      }
    }

    public void SendPacket(byte[] data)
    {
      try
      {
        if (data.Length < 2)
          return;
        ushort uint16_1 = Convert.ToUInt16(data.Length - 2);
        List<byte> byteList = new List<byte>(data.Length + 2);
        byteList.AddRange((IEnumerable<byte>) BitConverter.GetBytes(uint16_1));
        byteList.AddRange((IEnumerable<byte>) data);
        byte[] array = byteList.ToArray();
        if (ConfigGA.debugMode)
        {
          ushort uint16_2 = BitConverter.ToUInt16(data, 0);
          string str1 = "";
          string str2 = BitConverter.ToString(array);
          char[] chArray = new char[5]
          {
            '-',
            ',',
            '.',
            ':',
            '\t'
          };
          foreach (string str3 in str2.Split(chArray))
            str1 = str1 + " " + str3;
          Logger.warning("[" + (object) uint16_2 + "]" + str1);
        }
        if (array.Length != 0)
          this._client.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), (object) this._client);
        byteList.Clear();
      }
      catch
      {
        this.Close(0, true);
      }
    }

    public void SendPacket(SendPacket bp)
    {
      try
      {
        using (bp)
        {
          bp.write();
          byte[] array1 = bp.mstream.ToArray();
          if (array1.Length < 2)
            return;
          ushort uint16_1 = Convert.ToUInt16(array1.Length - 2);
          List<byte> byteList = new List<byte>(array1.Length + 2);
          byteList.AddRange((IEnumerable<byte>) BitConverter.GetBytes(uint16_1));
          byteList.AddRange((IEnumerable<byte>) array1);
          byte[] array2 = byteList.ToArray();
          if (ConfigGA.debugMode)
          {
            ushort uint16_2 = BitConverter.ToUInt16(array1, 0);
            string str1 = "";
            string str2 = BitConverter.ToString(array2);
            char[] chArray = new char[5]
            {
              '-',
              ',',
              '.',
              ':',
              '\t'
            };
            foreach (string str3 in str2.Split(chArray))
              str1 = str1 + " " + str3;
            Logger.warning("[" + (object) uint16_2 + "]" + str1);
          }
          if (array2.Length != 0)
            this._client.BeginSend(array2, 0, array2.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), (object) this._client);
          bp.mstream.Close();
          byteList.Clear();
        }
      }
      catch
      {
        this.Close(0, true);
      }
    }

    private void SendCallback(IAsyncResult ar)
    {
      try
      {
        Socket asyncState = (Socket) ar.AsyncState;
        if (asyncState == null || !asyncState.Connected)
          return;
        asyncState.EndSend(ar);
      }
      catch
      {
        this.Close(0, true);
      }
    }

    private void read()
    {
      try
      {
        LoginClient.StateObject stateObject = new LoginClient.StateObject();
        stateObject.workSocket = this._client;
        this._client.BeginReceive(stateObject.buffer, 0, 8096, SocketFlags.None, new AsyncCallback(this.OnReceiveCallback), (object) stateObject);
      }
      catch
      {
        this.Close(0, true);
      }
    }

    public void Close(int time, bool destroyConnection)
    {
      if (this.closed)
        return;
      try
      {
        this.closed = true;
        LoginManager.RemoveSocket(this);
        Account player = this._player;
        if (destroyConnection)
        {
          if (player != null)
          {
            player.setOnlineStatus(false);
            if (player._status.serverId == (byte) 0)
              SEND_REFRESH_ACC.RefreshAccount(player, false);
            player._status.ResetData(player.player_id);
            player.SimpleClear();
            player.updateCacheInfo();
            this._player = (Account) null;
          }
          this._client.Close(time);
          Thread.Sleep(time);
          this.Dispose();
        }
        else if (player != null)
        {
          player.SimpleClear();
          player.updateCacheInfo();
          this._player = (Account) null;
        }
        Auth_SyncNet.UpdateGSCount(0);
      }
      catch (Exception ex)
      {
        Logger.warning("[LoginClient.Close] " + ex.ToString());
      }
    }

    private void OnReceiveCallback(IAsyncResult ar)
    {
      LoginClient.StateObject asyncState = (LoginClient.StateObject) ar.AsyncState;
      try
      {
        int length = asyncState.workSocket.EndReceive(ar);
        if (length <= 0)
          return;
        byte[] buffer = new byte[length];
        Array.Copy((Array) asyncState.buffer, 0, (Array) buffer, 0, length);
        int FirstLength = (int) BitConverter.ToUInt16(buffer, 0) & (int) short.MaxValue;
        byte[] numArray1 = new byte[FirstLength + 2];
        Array.Copy((Array) buffer, 2, (Array) numArray1, 0, numArray1.Length);
        this.lastCompleteBuffer = buffer;
        byte[] numArray2 = ComDiv.decrypt(numArray1, this.Shift);
        if (!this.CheckSeed(numArray2, true))
        {
          this.Close(0, true);
        }
        else
        {
          this.RunPacket(numArray2, numArray1);
          this.checkoutN(buffer, FirstLength);
          new Thread(new ThreadStart(this.read)).Start();
        }
      }
      catch (ObjectDisposedException ex)
      {
      }
      catch
      {
        this.Close(0, true);
      }
    }

    public bool CheckSeed(byte[] decryptedData, bool isTheFirstPacket)
    {
      int uint16 = (int) BitConverter.ToUInt16(decryptedData, 2);
      if (uint16 == this.GetNextSessionSeed())
        return true;
      Logger.warning("[Date: " + DateTime.Now.ToString("HH:mm") + "; SessionId: " + (object) this.SessionId + "] A seed: " + (object) uint16 + " foi bloqueada. [Esperava-se: " + (object) this.NextSessionSeed + "; Original: " + (object) this.SessionSeed + "]");
      if (this._player != null)
        Logger.warning("Conta que teve o seed bloqueado. [Id: " + (object) this._player.player_id + "; Login: " + this._player.login + "]");
      if (isTheFirstPacket)
        new Thread(new ThreadStart(this.read)).Start();
      return false;
    }

    private int GetNextSessionSeed()
    {
      this.NextSessionSeed = (int) (ushort) (this.NextSessionSeed * 214013 + 2531011 >> 16 & (int) short.MaxValue);
      return this.NextSessionSeed;
    }

    public void checkoutN(byte[] buffer, int FirstLength)
    {
      int length = buffer.Length;
      try
      {
        byte[] numArray1 = new byte[length - FirstLength - 4];
        Array.Copy((Array) buffer, FirstLength + 4, (Array) numArray1, 0, numArray1.Length);
        if (numArray1.Length == 0)
          return;
        int FirstLength1 = (int) BitConverter.ToUInt16(numArray1, 0) & (int) short.MaxValue;
        byte[] data = new byte[FirstLength1 + 2];
        Array.Copy((Array) numArray1, 2, (Array) data, 0, data.Length);
        byte[] numArray2 = new byte[FirstLength1 + 2];
        Array.Copy((Array) ComDiv.decrypt(data, this.Shift), 0, (Array) numArray2, 0, numArray2.Length);
        if (!this.CheckSeed(numArray2, false))
          return;
        this.RunPacket(numArray2, numArray1);
        this.checkoutN(numArray1, FirstLength1);
      }
      catch
      {
      }
    }

    private void FirstPacketCheck(ushort packetId)
    {
      if (this.firstPacketId != 0)
        return;
      this.firstPacketId = (int) packetId;
      if (packetId == (ushort) 2561 && packetId == (ushort) 2672)
        return;
      this.Close(0, true);
      Logger.warning("Connection destroyed due to Unknown first packet. [" + (object) packetId + "]");
    }

    private void RunPacket(byte[] buff, byte[] simple)
    {
      ushort uint16 = BitConverter.ToUInt16(buff, 0);
      if (this.closed)
        return;
      ReceiveLoginPacket receiveLoginPacket = (ReceiveLoginPacket) null;
      switch (uint16)
      {
        case 528:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_USER_GIFTLIST_REC(this, buff);
          goto case 2575;
        case 2561:
        case 2563:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_LOGIN_REC(this, buff);
          goto case 2575;
        case 2565:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_USER_INFO_REC(this, buff);
          goto case 2575;
        case 2567:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_USER_CONFIGS_REC(this, buff);
          goto case 2575;
        case 2575:
          if (receiveLoginPacket == null)
            break;
          new Thread(new ThreadStart(receiveLoginPacket.run)).Start();
          break;
        case 2577:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_SERVER_CHANGE_REC(this, buff);
          goto case 2575;
        case 2579:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_USER_ENTER_REC(this, buff);
          goto case 2575;
        case 2581:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_CONFIG_SAVE_REC(this, buff);
          goto case 2575;
        case 2642:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_SERVER_LIST_REFRESH_REC(this, buff);
          goto case 2575;
        case 2654:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_USER_EXIT_REC(this, buff);
          goto case 2575;
        case 2666:
          receiveLoginPacket = (ReceiveLoginPacket) new A_2666_REC(this, buff);
          Console.WriteLine("A_2666_REC");
          goto case 2575;
        case 2672:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_LOGIN_THAI_REC(this, buff);
          Console.WriteLine("BASE_LOGIN_THAI_REC");
          goto case 2575;
        case 2678:
          receiveLoginPacket = (ReceiveLoginPacket) new A_2678_REC(this, buff);
          goto case 2575;
        case 2698:
          receiveLoginPacket = (ReceiveLoginPacket) new BASE_USER_INVENTORY_REC(this, buff);
          goto case 2575;
        default:
          StringUtil stringUtil = new StringUtil();
          stringUtil.AppendLine("|[LC]| Opcode não encontrado " + (object) uint16);
          stringUtil.AppendLine("Encry/SemLength/Cheio: " + BitConverter.ToString(simple));
          stringUtil.AppendLine("SemEnc/SemLength/Cheio: " + BitConverter.ToString(buff));
          stringUtil.AppendLine("Enc/ComLength/TUDO: " + BitConverter.ToString(this.lastCompleteBuffer));
          stringUtil.AppendLine("SessionId: " + (object) this.SessionId + "; SessionSeed: " + (object) this.SessionSeed);
          Logger.error(stringUtil.getString());
          goto case 2575;
      }
    }

    private class StateObject
    {
      public byte[] buffer = new byte[8096];
      public Socket workSocket;
      public const int BufferSize = 8096;
    }
  }
}
