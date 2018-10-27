
using Core;
using Core.models.account.clan;
using Core.models.enums;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
  public class LOBBY_GET_ROOMLIST_REC : ReceiveGamePacket
  {
    public LOBBY_GET_ROOMLIST_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Channel channel = player.getChannel();
        if (channel == null)
          return;
        channel.RemoveEmptyRooms();
        List<Room> rooms = channel._rooms;
        List<Account> waitPlayers = channel.getWaitPlayers();
        int num1 = (int) Math.Ceiling((double) rooms.Count / 15.0);
        int num2 = (int) Math.Ceiling((double) waitPlayers.Count / 10.0);
        if (player.LastRoomPage >= num1)
          player.LastRoomPage = 0;
        if (player.LastPlayerPage >= num2)
          player.LastPlayerPage = 0;
        int count1 = 0;
        int count2 = 0;
        byte[] roomListData = this.GetRoomListData(player.LastRoomPage, ref count1, rooms);
        byte[] playerListData = this.GetPlayerListData(player.LastPlayerPage, ref count2, waitPlayers);
        this._client.SendPacket((SendPacket) new LOBBY_GET_ROOMLIST_PAK(rooms.Count, waitPlayers.Count, player.LastRoomPage++, player.LastPlayerPage++, count1, count2, roomListData, playerListData));
      }
      catch (Exception ex)
      {
        Logger.warning("[LOBBY_GET_ROOMLIST_REC] " + ex.ToString());
      }
    }

    private byte[] GetRoomListData(int page, ref int count, List<Room> list)
    {
      using (SendGPacket p = new SendGPacket())
      {
        for (int index = page * 15; index < list.Count; ++index)
        {
          this.WriteRoomData(list[index], p);
          if (++count == 15)
            break;
        }
        return p.mstream.ToArray();
      }
    }

    private void WriteRoomData(Room room, SendGPacket p)
    {
      int num = 0;
      p.writeD(room._roomId);
      p.writeS(room.name, 23);
      p.writeH((short) room.mapId);
      p.writeC(room.stage4v4);
      p.writeC(room.room_type);
      p.writeC((byte) room._state);
      p.writeC((byte) room.getAllPlayers().Count);
      p.writeC((byte) room.getSlotCount());
      p.writeC((byte) room._ping);
      p.writeC(room.weaponsFlag);
      if (room.random_map > (byte) 0)
        num += 2;
      if (room.password.Length > 0)
        num += 4;
      if (room.limit > (byte) 0 && room._state > RoomState.Ready)
        num += 128;
      p.writeC((byte) num);
      p.writeC(room.special);
    }

    private void WritePlayerData(Account pl, SendGPacket p)
    {
      Clan clan = ClanManager.getClan(pl.clanId);
      p.writeD(pl.getSessionId());
      p.writeD(clan._logo);
      p.writeS(clan._name, 17);
      p.writeH((short) pl.getRank());
      p.writeS(pl.player_name, 33);
      p.writeC((byte) pl.name_color);
      p.writeC((byte) 31);
    }

    private byte[] GetPlayerListData(int page, ref int count, List<Account> list)
    {
      using (SendGPacket p = new SendGPacket())
      {
        for (int index = page * 10; index < list.Count; ++index)
        {
          this.WritePlayerData(list[index], p);
          if (++count == 10)
            break;
        }
        return p.mstream.ToArray();
      }
    }
  }
}
