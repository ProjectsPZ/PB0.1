
using Core;
using Core.models.enums;
using Core.server;
using Game.data.model;
using Game.data.xml;
using Game.global.serverpacket;
using System;

namespace Game.data.sync.client_side
{
  public static class Net_Room_HitMarker
  {
    public static void Load(ReceiveGPacket p)
    {
      int id1 = (int) p.readH();
      int id2 = (int) p.readH();
      byte num1 = p.readC();
      byte num2 = p.readC();
      byte num3 = p.readC();
      int num4 = (int) p.readH();
      if (p.getBuffer().Length > 11)
        Logger.warning("[Invalid MARKER: " + BitConverter.ToString(p.getBuffer()) + "]");
      Channel channel = ChannelsXML.getChannel(id2);
      if (channel == null)
        return;
      Room room = channel.getRoom(id1);
      if (room == null || room._state != RoomState.Battle)
        return;
      Account playerBySlot = room.getPlayerBySlot((int) num1);
      if (playerBySlot == null)
        return;
      string message = "";
      if (num2 == (byte) 10)
      {
        message = Translation.GetLabel("LifeRestored", (object) num4);
      }
      else
      {
        switch (num3)
        {
          case 0:
            message = Translation.GetLabel("HitMarker1", (object) num4);
            break;
          case 1:
            message = Translation.GetLabel("HitMarker2", (object) num4);
            break;
          case 2:
            message = Translation.GetLabel("HitMarker3");
            break;
          case 3:
            message = Translation.GetLabel("HitMarker4");
            break;
        }
      }
      playerBySlot.SendPacket((SendPacket) new LOBBY_CHATTING_PAK(Translation.GetLabel("HitMarkerName"), playerBySlot.getSessionId(), 0, true, message));
    }
  }
}
