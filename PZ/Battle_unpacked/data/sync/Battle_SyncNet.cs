
using Battle.config;
using Battle.data.models;
using Battle.data.sync.client_side;
using Battle.network;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Battle.data.sync
{
  public class Battle_SyncNet
  {
    private static UdpClient udp;

    public static void Start()
    {
      try
      {
        Battle_SyncNet.udp = new UdpClient((int) Config.syncPort);
        uint num = 2147483648u;
        uint num2 = 402653184u;
        uint ioControlCode = num | num2 | 0xC;
        Battle_SyncNet.udp.Client.IOControl((int) num, new byte[1]
        {
          Convert.ToByte(false)
        }, (byte[]) null);
        new Thread(new ThreadStart(Battle_SyncNet.read)).Start();
      }
      catch (Exception ex)
      {
        Logger.warning(ex.ToString(), false);
      }
    }

    public static void read()
    {
      try
      {
        Battle_SyncNet.udp.BeginReceive(new AsyncCallback(Battle_SyncNet.recv), (object) null);
      }
      catch (Exception ex)
      {
        Logger.error(ex.ToString(), false);
      }
    }

    private static void recv(IAsyncResult res)
    {
      IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 8000);
      byte[] buffer = Battle_SyncNet.udp.EndReceive(res, ref remoteEP);
      new Thread(new ThreadStart(Battle_SyncNet.read)).Start();
      if (buffer.Length < 2)
        return;
      Battle_SyncNet.LoadPacket(buffer);
    }

    private static void LoadPacket(byte[] buffer)
    {
      ReceivePacket p = new ReceivePacket(buffer);
      switch (p.readH())
      {
        case 1:
          RespawnSync.Load(p);
          break;
        case 2:
          RemovePlayerSync.Load(p);
          break;
        case 3:
          uint UniqueRoomId = p.readUD();
          int gen2 = p.readD();
          int num = (int) p.readC();
          Room room = RoomsManager.getRoom(UniqueRoomId, gen2);
          if (room != null)
            room._serverRound = num;
          break;
      }
    }

    public static void SendPortalPass(Room room, Player pl, int portalIdx)
    {
      if (room.stageType != 7)
        return;
      pl._life = pl._maxLife;
      using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
      {
        using (SendPacket sendPacket = new SendPacket())
        {
          sendPacket.writeH((short) 1);
          sendPacket.writeH((short) room._roomId);
          sendPacket.writeH((short) room._channelId);
          sendPacket.writeC((byte) pl._slot);
          sendPacket.writeC((byte) portalIdx);
          Battle_SyncNet.SendData(room, socket, sendPacket.mstream.ToArray());
        }
      }
    }

    public static void SendDeathSync(Room room, Player killer, int objId, int weaponId, List<DeathServerData> deaths)
    {
      using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
      {
        using (SendPacket sendPacket = new SendPacket())
        {
          sendPacket.writeH((short) 3);
          sendPacket.writeH((short) room._roomId);
          sendPacket.writeH((short) room._channelId);
          sendPacket.writeC((byte) killer._slot);
          sendPacket.writeC((byte) objId);
          sendPacket.writeD(weaponId);
          sendPacket.writeTVector(killer.Position);
          sendPacket.writeC((byte) deaths.Count);
          for (int index = 0; index < deaths.Count; ++index)
          {
            DeathServerData death = deaths[index];
            sendPacket.writeC((byte) death._player.WeaponClass);
            sendPacket.writeC((byte) ((int) death._deathType * 16 + death._player._slot));
            sendPacket.writeTVector(death._player.Position);
            sendPacket.writeC((byte) 0);
          }
          Battle_SyncNet.SendData(room, socket, sendPacket.mstream.ToArray());
        }
      }
    }

    public static void SendBombSync(Room room, Player pl, int type, int bombArea)
    {
      using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
      {
        using (SendPacket sendPacket = new SendPacket())
        {
          sendPacket.writeH((short) 2);
          sendPacket.writeH((short) room._roomId);
          sendPacket.writeH((short) room._channelId);
          sendPacket.writeC((byte) type);
          sendPacket.writeC((byte) pl._slot);
          if (type == 0)
          {
            sendPacket.writeC((byte) bombArea);
            sendPacket.writeTVector(pl.Position);
            room.BombPosition = pl.Position;
          }
          Battle_SyncNet.SendData(room, socket, sendPacket.mstream.ToArray());
        }
      }
    }

    public static void SendHitMarkerSync(Room room, Player pl, int deathType, int hitEnum, int damage)
    {
      using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
      {
        using (SendPacket sendPacket = new SendPacket())
        {
          sendPacket.writeH((short) 4);
          sendPacket.writeH((short) room._roomId);
          sendPacket.writeH((short) room._channelId);
          sendPacket.writeC((byte) pl._slot);
          sendPacket.writeC((byte) deathType);
          sendPacket.writeC((byte) hitEnum);
          sendPacket.writeH((short) damage);
          Battle_SyncNet.SendData(room, socket, sendPacket.mstream.ToArray());
        }
      }
    }

    public static void SendSabotageSync(Room room, Player pl, int damage, int ultraSYNC)
    {
      using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
      {
        using (SendPacket sendPacket = new SendPacket())
        {
          sendPacket.writeH((short) 5);
          sendPacket.writeH((short) room._roomId);
          sendPacket.writeH((short) room._channelId);
          sendPacket.writeC((byte) pl._slot);
          sendPacket.writeH((ushort) room._bar1);
          sendPacket.writeH((ushort) room._bar2);
          sendPacket.writeC((byte) ultraSYNC);
          sendPacket.writeH((ushort) damage);
          Battle_SyncNet.SendData(room, socket, sendPacket.mstream.ToArray());
        }
      }
    }

    private static void SendData(Room room, Socket socket, byte[] data)
    {
      if (!Config.sendInfoToServ)
        return;
      socket.SendTo(data, (EndPoint) room.gs.Connection);
    }
  }
}
