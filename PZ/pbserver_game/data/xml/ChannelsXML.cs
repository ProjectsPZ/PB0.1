﻿
using Core;
using Core.server;
using Core.sql;
using Game.data.model;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Game.data.xml
{
  public static class ChannelsXML
  {
    public static List<Channel> _channels = new List<Channel>();

    public static void Load(int serverId)
    {
      try
      {
        using (NpgsqlConnection npgsqlConnection = SQLjec.getInstance().conn())
        {
          NpgsqlCommand command = npgsqlConnection.CreateCommand();
          npgsqlConnection.Open();
          command.Parameters.AddWithValue("@server", (object) serverId);
          command.CommandText = "SELECT * FROM info_channels WHERE server_id=@server ORDER BY channel_id ASC";
          NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
          while (npgsqlDataReader.Read())
            ChannelsXML._channels.Add(new Channel()
            {
              serverId = npgsqlDataReader.GetInt32(0),
              _id = npgsqlDataReader.GetInt32(1),
              _type = npgsqlDataReader.GetInt32(2),
              _announce = npgsqlDataReader.GetString(3)
            });
          command.Dispose();
          npgsqlDataReader.Close();
          npgsqlConnection.Dispose();
          npgsqlConnection.Close();
        }
      }
      catch (Exception ex)
      {
        Logger.error(ex.ToString());
      }
    }

    public static Channel getChannel(int id)
    {
      try
      {
        return ChannelsXML._channels[id];
      }
      catch
      {
        return (Channel) null;
      }
    }

    public static bool updateNotice(int serverId, int channelId, string text)
    {
      return ComDiv.updateDB("info_channels", "announce", (object) text, "server_id", (object) serverId, "channel_id", (object) channelId);
    }

    public static bool updateNotice(string text)
    {
      return ComDiv.updateDB("info_channels", "announce", (object) text);
    }
  }
}
