
using Core.models.enums;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class A_3428_REC : ReceiveGamePacket
  {
    public A_3428_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
    }

    public override void run()
    {
      if (this._client == null)
        return;
      if (this._client._player == null)
        return;
      try
      {
        Account player = this._client._player;
        Room room = player._room;
        if (room == null || room._state < RoomState.Loading || room._slots[player._slotId].state != SLOT_STATE.NORMAL)
          return;
        this._client.SendPacket((SendPacket) new A_3428_PAK(room));
      }
      catch
      {
      }
    }
  }
}
