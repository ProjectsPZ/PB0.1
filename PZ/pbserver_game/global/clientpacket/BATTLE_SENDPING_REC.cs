
using Core;
using Core.models.enums;
using Game.data.model;
using Game.global.serverpacket;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
  public class BATTLE_SENDPING_REC : ReceiveGamePacket
  {
    private byte[] slots;
    private int ReadyPlayersCount;

    public BATTLE_SENDPING_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.slots = this.readB(16);
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        Room room = player._room;
        if (room == null || room._slots[player._slotId].state < SLOT_STATE.BATTLE_READY)
          return;
        if (room._state == RoomState.Battle)
          room._ping = (int) this.slots[room._leader];
        using (BATTLE_SENDPING_PAK battleSendpingPak = new BATTLE_SENDPING_PAK(this.slots))
        {
          List<Account> allPlayers = room.getAllPlayers(SLOT_STATE.READY, 1);
          if (allPlayers.Count == 0)
            return;
          byte[] completeBytes = battleSendpingPak.GetCompleteBytes("BATTLE_SENDPING_REC");
          foreach (Account account in allPlayers)
          {
            if (room._slots[account._slotId].state >= SLOT_STATE.BATTLE_READY)
              account.SendCompletePacket(completeBytes);
            else
              ++this.ReadyPlayersCount;
          }
        }
        if (this.ReadyPlayersCount != 0)
          return;
        room.SpawnReadyPlayers();
      }
      catch (Exception ex)
      {
        Logger.warning("[BATTLE_SENDPING_REC] " + ex.ToString());
      }
    }
  }
}
