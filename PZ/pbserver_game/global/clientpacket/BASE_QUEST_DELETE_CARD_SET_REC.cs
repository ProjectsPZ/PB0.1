
using Core;
using Core.managers;
using Core.models.account.players;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class BASE_QUEST_DELETE_CARD_SET_REC : ReceiveGamePacket
  {
    private uint erro;
    private int missionIdx;

    public BASE_QUEST_DELETE_CARD_SET_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.missionIdx = (int) this.readC();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        PlayerMissions mission = player._mission;
        bool flag = false;
        if (this.missionIdx >= 3 || this.missionIdx == 0 && mission.mission1 == 0 || (this.missionIdx == 1 && mission.mission2 == 0 || this.missionIdx == 2 && mission.mission3 == 0))
          flag = true;
        if (!flag && PlayerManager.updateMissionId(player.player_id, 0, this.missionIdx))
        {
          if (ComDiv.updateDB("player_missions", "owner_id", (object) player.player_id, new string[2]
          {
            "card" + (object) (this.missionIdx + 1),
            "mission" + (object) (this.missionIdx + 1)
          }, (object) 0, (object) new byte[0]))
          {
            if (this.missionIdx == 0)
            {
              mission.mission1 = 0;
              mission.card1 = 0;
              mission.list1 = new byte[40];
              goto label_12;
            }
            else if (this.missionIdx == 1)
            {
              mission.mission2 = 0;
              mission.card2 = 0;
              mission.list2 = new byte[40];
              goto label_12;
            }
            else if (this.missionIdx == 2)
            {
              mission.mission3 = 0;
              mission.card3 = 0;
              mission.list3 = new byte[40];
              goto label_12;
            }
            else
              goto label_12;
          }
        }
        this.erro = 2147487824U;
label_12:
        this._client.SendPacket((SendPacket) new BASE_QUEST_DELETE_CARD_SET_PAK(this.erro, player));
      }
      catch (Exception ex)
      {
        Logger.info("BASE_QUEST_DELETE_CARD_SET_REC: " + ex.ToString());
      }
    }
  }
}
