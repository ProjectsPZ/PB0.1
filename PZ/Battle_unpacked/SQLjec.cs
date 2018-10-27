
using Battle.config;
using Npgsql;
using System.Runtime.Remoting.Contexts;

namespace Battle
{
  [Synchronization]
  public class SQLjec
  {
    private static SQLjec sql = new SQLjec();
    protected NpgsqlConnectionStringBuilder connBuilder;

    public SQLjec()
    {
      this.connBuilder = new NpgsqlConnectionStringBuilder()
      {
        Database = Config.dbName,
        Host = Config.dbHost,
        Username = Config.dbUser,
        Password = Config.dbPass,
        Port = Config.dbPort
      };
    }

    public static SQLjec getInstance()
    {
      return SQLjec.sql;
    }

    public NpgsqlConnection conn()
    {
      return new NpgsqlConnection(this.connBuilder.ConnectionString);
    }
  }
}
