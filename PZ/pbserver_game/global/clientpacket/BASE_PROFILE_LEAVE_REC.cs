
using Core;
using Core.models.enums;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class BASE_PROFILE_LEAVE_REC : ReceiveGamePacket
  {
    public BASE_PROFILE_LEAVE_REC(GameClient client, byte[] data)
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
        player._room.changeSlotState(player._slotId, SLOT_STATE.NORMAL, true);
        this._client.SendPacket((SendPacket) new BASE_PROFILE_LEAVE_PAK());
      }
      catch (Exception ex)
      {
        Logger.info(ex.ToString());
      }
    }
  }
}
