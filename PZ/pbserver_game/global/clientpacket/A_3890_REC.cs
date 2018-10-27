
using Core;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class A_3890_REC : ReceiveGamePacket
  {
    private int Slot;

    public A_3890_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.Slot = (int) this.readC();
    }

    public override void run()
    {
      if (this._client == null)
        return;
      Account player = this._client._player;
      if (player == null || player._slotId == this.Slot)
        return;
      if (!player.IsGM())
      {
        this._client.Close(1000, false);
      }
      else
      {
        try
        {
          Room room = player._room;
          if (room == null)
            return;
          Account playerBySlot = room.getPlayerBySlot(this.Slot);
          if (playerBySlot == null)
            return;
          playerBySlot.SendPacket((SendPacket) new AUTH_ACCOUNT_KICK_PAK(2));
          playerBySlot.Close(1000, true);
          Logger.warning("[3890] Slot: " + (object) this.Slot);
        }
        catch (Exception ex)
        {
          Logger.warning(ex.ToString());
        }
      }
    }
  }
}
