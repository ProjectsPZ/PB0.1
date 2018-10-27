﻿
using Core;
using Core.server;
using Game.data.managers;
using Game.data.model;
using Game.global.serverpacket;
using System.Collections.Generic;

namespace Game.data.chat
{
  public static class NickHistory
  {
    public static string GetHistoryById(string str, Account player)
    {
      List<NHistoryModel> history = NickHistoryManager.getHistory((object) long.Parse(str.Substring(7)), 1);
      string msg = Translation.GetLabel("NickHistory1_Title");
      foreach (NHistoryModel nhistoryModel in history)
        msg = msg + "\n" + Translation.GetLabel("NickHistory1_Item", (object) nhistoryModel.from_nick, (object) nhistoryModel.to_nick, (object) nhistoryModel.date, (object) nhistoryModel.motive);
      player.SendPacket((SendPacket) new SERVER_MESSAGE_ANNOUNCE_PAK(msg));
      return Translation.GetLabel("NickHistory1_Result", (object) history.Count);
    }

    public static string GetHistoryByNewNick(string str, Account player)
    {
      List<NHistoryModel> history = NickHistoryManager.getHistory((object) str.Substring(7), 0);
      string msg = Translation.GetLabel("NickHistory2_Title");
      foreach (NHistoryModel nhistoryModel in history)
        msg = msg + "\n" + Translation.GetLabel("NickHistory2_Item", (object) nhistoryModel.from_nick, (object) nhistoryModel.to_nick, (object) nhistoryModel.player_id, (object) nhistoryModel.date, (object) nhistoryModel.motive);
      player.SendPacket((SendPacket) new SERVER_MESSAGE_ANNOUNCE_PAK(msg));
      return Translation.GetLabel("NickHistory2_Result", (object) history.Count);
    }
  }
}
