
using Core;
using Core.managers;
using Core.sql;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Game.data.managers
{
  public static class TorunamentRulesManager
  {
    public static List<int> itemscamp = new List<int>();
    public static List<int> itemscnpb = new List<int>();
    public static List<int> items79 = new List<int>();
    public static List<int> itemslan = new List<int>();

    public static void LoadList()
    {
      try
      {
        using (NpgsqlConnection npgsqlConnection = SQLjec.getInstance().conn())
        {
          NpgsqlCommand command = npgsqlConnection.CreateCommand();
          npgsqlConnection.Open();
          command.CommandText = "SELECT * FROM tournament_rules";
          command.CommandType = CommandType.Text;
          NpgsqlDataReader npgsqlDataReader = command.ExecuteReader();
          while (npgsqlDataReader.Read())
          {
            string str = npgsqlDataReader.GetString(0);
            string txt = npgsqlDataReader.GetString(1);
            if (str == "camp")
              ShopManager.IsBlocked(txt, TorunamentRulesManager.itemscamp);
            if (str == "cnpb")
              ShopManager.IsBlocked(txt, TorunamentRulesManager.itemscnpb);
            if (str == "79")
              ShopManager.IsBlocked(txt, TorunamentRulesManager.items79);
            if (str == "lan")
              ShopManager.IsBlocked(txt, TorunamentRulesManager.itemslan);
          }
          command.Dispose();
          npgsqlDataReader.Close();
          npgsqlConnection.Dispose();
          npgsqlConnection.Close();
        }
        Logger.warning("Trounament Rules @Camp Count: " + (object) TorunamentRulesManager.itemscamp.Count);
        Logger.warning("Trounament Rules @Cnpb Count: " + (object) TorunamentRulesManager.itemscnpb.Count);
        Logger.warning("Trounament Rules @79 Count: " + (object) TorunamentRulesManager.items79.Count);
        Logger.warning("Trounament Rules @lan Count: " + (object) TorunamentRulesManager.itemslan.Count);
      }
      catch (Exception ex)
      {
        Logger.error("Ocorreu um problema ao carregar os Tournament Rules!\r\n" + ex.ToString());
      }
    }

    public static bool IsBlocked(int listid, int id)
    {
      return listid == id;
    }

    public static bool IsBlocked(int listid, int id, ref List<string> list, string category)
    {
      if (listid != id)
        return false;
      list.Add(category);
      return true;
    }
  }
}
