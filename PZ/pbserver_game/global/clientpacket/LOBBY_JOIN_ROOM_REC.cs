
using Core;
using Core.models.enums;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class LOBBY_JOIN_ROOM_REC : ReceiveGamePacket
  {
    private int roomId;
    private int type;
    private string password;

    public LOBBY_JOIN_ROOM_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.roomId = this.readD();
      this.password = this.readS(4);
      this.type = (int) this.readC2();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        Channel channel;
        if (player != null && player.player_name.Length > 0 && (player._room == null && player._match == null) && player.getChannel(out channel))
        {
          Room room = channel.getRoom(this.roomId);
          Account p;
          if (room != null && room.getLeader(out p))
          {
            if (room.room_type == (byte) 10)
              this._client.SendPacket((SendPacket) new LOBBY_JOIN_ROOM_PAK(2147487868U, (Account) null, (Account) null));
            else if (room.password.Length > 0 && this.password != room.password && (player._rank != 53 && !player.HaveGMLevel()) && this.type != 1)
              this._client.SendPacket((SendPacket) new LOBBY_JOIN_ROOM_PAK(2147487749U, (Account) null, (Account) null));
            else if (room.limit == (byte) 1 && room._state >= RoomState.CountDown && !player.HaveGMLevel() || room.special == (byte) 5)
              this._client.SendPacket((SendPacket) new LOBBY_JOIN_ROOM_PAK(2147487763U, (Account) null, (Account) null));
            else if (room.kickedPlayers.Contains(player.player_id) && !player.HaveGMLevel())
              this._client.SendPacket((SendPacket) new LOBBY_JOIN_ROOM_PAK(2147487756U, (Account) null, (Account) null));
            else if (room.addPlayer(player) >= 0)
            {
              player.ResetPages();
              using (ROOM_GET_SLOTONEINFO_PAK getSlotoneinfoPak = new ROOM_GET_SLOTONEINFO_PAK(player))
                room.SendPacketToPlayers((SendPacket) getSlotoneinfoPak, player.player_id);
              this._client.SendPacket((SendPacket) new LOBBY_JOIN_ROOM_PAK(0U, player, p));
            }
            else
              this._client.SendPacket((SendPacket) new LOBBY_JOIN_ROOM_PAK(2147487747U, (Account) null, (Account) null));
          }
          else
            this._client.SendPacket((SendPacket) new LOBBY_JOIN_ROOM_PAK(2147487748U, (Account) null, (Account) null));
        }
        else
          this._client.SendPacket((SendPacket) new LOBBY_JOIN_ROOM_PAK(2147487748U, (Account) null, (Account) null));
      }
      catch (Exception ex)
      {
        Logger.warning("[ROOM_JOIN_NORMAL_REC] " + ex.ToString());
      }
    }
  }
}
