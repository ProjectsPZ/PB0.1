
using Core;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class ROOM_GET_PLAYERINFO_REC : ReceiveGamePacket
  {
    private int slotId;

    public ROOM_GET_PLAYERINFO_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.slotId = this.readD();
    }

    public override void run()
    {
      Account player = this._client._player;
      if (player == null)
        return;
      Room room = player._room;
      try
      {
        this._client.SendPacket((SendPacket) new ROOM_GET_PLAYERINFO_PAK(room.getPlayerBySlot(this.slotId)));
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
