
using Core;
using Core.models.enums;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class BASE_PROFILE_ENTER_REC : ReceiveGamePacket
  {
    public BASE_PROFILE_ENTER_REC(GameClient client, byte[] data)
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
        Room room = player == null ? (Room) null : player._room;
        if (room != null)
        {
          room.changeSlotState(player._slotId, SLOT_STATE.INFO, false);
          room.StopCountDown(player._slotId);
          room.updateSlotsInfo();
        }
        this._client.SendPacket((SendPacket) new BASE_PROFILE_ENTER_PAK());
      }
      catch (Exception ex)
      {
        Logger.warning(ex.ToString());
      }
    }
  }
}
