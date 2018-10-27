
using Core;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class ROOM_CHANGE_PASSW_REC : ReceiveGamePacket
  {
    private string pass;

    public ROOM_CHANGE_PASSW_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.pass = this.readS(4);
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Room room = player._room;
        if (room == null || room._leader != player._slotId || !(room.password != this.pass))
          return;
        room.password = this.pass;
        using (ROOM_CHANGE_PASSWD_PAK roomChangePasswdPak = new ROOM_CHANGE_PASSWD_PAK(this.pass))
          room.SendPacketToPlayers((SendPacket) roomChangePasswdPak);
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
