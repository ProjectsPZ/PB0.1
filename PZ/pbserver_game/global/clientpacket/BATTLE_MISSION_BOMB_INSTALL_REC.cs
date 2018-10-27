
using Core;
using Core.models.enums;
using Core.models.room;
using Game.data.model;
using Game.data.sync.client_side;
using System;

namespace Game.global.clientpacket
{
  public class BATTLE_MISSION_BOMB_INSTALL_REC : ReceiveGamePacket
  {
    private int slotIdx;
    private float x;
    private float y;
    private float z;
    private byte area;

    public BATTLE_MISSION_BOMB_INSTALL_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.slotIdx = this.readD();
      this.area = this.readC();
      this.x = this.readT();
      this.y = this.readT();
      this.z = this.readT();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        Room room = player == null ? (Room) null : player._room;
        if (room == null || room.round.Timer != null || (room._state != RoomState.Battle || room.C4_actived))
          return;
        SLOT slot = room.getSlot(this.slotIdx);
        if (slot == null || slot.state != SLOT_STATE.BATTLE)
          return;
        Net_Room_C4.InstallBomb(room, slot, (int) this.area, this.x, this.y, this.z);
      }
      catch (Exception ex)
      {
        Logger.info("[BATTLE_MISSION_BOMB_INSTALL_REC]: " + ex.ToString());
      }
    }
  }
}
