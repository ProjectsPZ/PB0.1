
using Core;
using Core.managers;
using Core.managers.events;
using Core.models.account;
using Core.models.account.players;
using Core.models.enums.errors;
using Core.models.shop;
using Core.server;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class EVENT_VISIT_REWARD_REC : ReceiveGamePacket
  {
    private EventErrorEnum erro = EventErrorEnum.VisitEvent_Success;
    private int eventId;
    private int type;

    public EVENT_VISIT_REWARD_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.eventId = this.readD();
      this.type = (int) this.readC();
    }

    public override void run()
    {
      try
      {
        if (this._client == null)
          return;
        Account player = this._client._player;
        if (player == null || player.player_name.Length == 0 || this.type > 1)
          this.erro = EventErrorEnum.VisitEvent_UserFail;
        else if (player._event != null)
        {
          if (player._event.LastVisitSequence1 == player._event.LastVisitSequence2)
          {
            this.erro = EventErrorEnum.VisitEvent_AlreadyCheck;
          }
          else
          {
            EventVisitModel eventVisitModel = EventVisitSyncer.getEvent(this.eventId);
            if (eventVisitModel == null)
              this.erro = EventErrorEnum.VisitEvent_Unknown;
            else if (eventVisitModel.EventIsEnabled())
            {
              VisitItem reward = eventVisitModel.getReward(player._event.LastVisitSequence2, this.type);
              if (reward != null)
              {
                GoodItem good = ShopManager.getGood(reward.good_id);
                if (good != null)
                {
                  PlayerEvent playerEvent = player._event;
                  DateTime dateTime = DateTime.Now;
                  dateTime = dateTime.AddDays(1.0);
                  int num = int.Parse(dateTime.ToString("yyMMdd"));
                  playerEvent.NextVisitDate = num;
                  ComDiv.updateDB("player_events", "player_id", (object) player.player_id, new string[2]
                  {
                    "next_visit_date",
                    "last_visit_sequence2"
                  }, (object) player._event.NextVisitDate, (object) ++player._event.LastVisitSequence2);
                  this._client.SendPacket((SendPacket) new INVENTORY_ITEM_CREATE_PAK(1, player, new ItemsModel(good._item._id, good._item._category, good._item._name, good._item._equip, (uint) reward.count, 0L)));
                }
                else
                  this.erro = EventErrorEnum.VisitEvent_NotEnough;
              }
              else
                this.erro = EventErrorEnum.VisitEvent_Unknown;
            }
            else
              this.erro = EventErrorEnum.VisitEvent_WrongVersion;
          }
        }
        else
          this.erro = EventErrorEnum.VisitEvent_Unknown;
        this._client.SendPacket((SendPacket) new EVENT_VISIT_REWARD_PAK(this.erro));
      }
      catch (Exception ex)
      {
        Logger.info("[EVENT_VERIFICATION_REWARD_REC] " + ex.ToString());
      }
    }
  }
}
