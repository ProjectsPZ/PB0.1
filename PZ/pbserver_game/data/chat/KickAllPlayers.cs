﻿
using Core;
using Core.models.enums;
using Game.data.model;
using Game.global.serverpacket;
using System.Collections.Generic;

namespace Game.data.chat
{
  public static class KickAllPlayers
  {
    public static string KickPlayers()
    {
      int num = 0;
      using (AUTH_ACCOUNT_KICK_PAK authAccountKickPak = new AUTH_ACCOUNT_KICK_PAK(0))
      {
        if (GameManager._socketList.Count > 0)
        {
          byte[] completeBytes = authAccountKickPak.GetCompleteBytes("KickAllPlayers.genCode");
          foreach (GameClient gameClient in (IEnumerable<GameClient>) GameManager._socketList.Values)
          {
            Account player = gameClient._player;
            if (player != null && player._isOnline && player.access <= AccessLevel.Streamer)
            {
              player.SendCompletePacket(completeBytes);
              player.Close(1000, true);
              ++num;
            }
          }
        }
      }
      return Translation.GetLabel("KickAllWarn", (object) num);
    }
  }
}
