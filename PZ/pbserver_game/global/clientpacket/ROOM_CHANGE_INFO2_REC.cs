﻿
using Core;
using Core.models.enums;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class ROOM_CHANGE_INFO2_REC : ReceiveGamePacket
  {
    private string leader;

    public ROOM_CHANGE_INFO2_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      try
      {
        Account player = this._client._player;
        Room room = player == null ? (Room) null : player._room;
        if (room == null || room._leader != player._slotId || room._state != RoomState.Ready)
          return;
        this.leader = this.readS(33);
        room.killtime = this.readD();
        room.limit = this.readC();
        room.seeConf = this.readC();
        room.autobalans = (int) this.readH();
        using (ROOM_CHANGE_INFO_PAK roomChangeInfoPak = new ROOM_CHANGE_INFO_PAK(room, this.leader))
          room.SendPacketToPlayers((SendPacket) roomChangeInfoPak);
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }

    public override void run()
    {
    }
  }
}
