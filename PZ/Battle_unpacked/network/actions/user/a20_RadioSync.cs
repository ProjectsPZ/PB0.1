
using Battle.data.models;

namespace Battle.network.actions.user
{
  public class a20_RadioSync
  {
    public static a20_RadioSync.Struct readSyncInfo(ActionModel ac, ReceivePacket p, bool genLog)
    {
      a20_RadioSync.Struct @struct = new a20_RadioSync.Struct()
      {
        _radioId = p.readC(),
        _areaId = p.readC()
      };
      if (genLog)
        Logger.warning("Slot " + (object) ac._slot + " released a radio chat: radId, areaId [" + (object) @struct._radioId + ";" + (object) @struct._areaId + "]", false);
      return @struct;
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
    {
      a20_RadioSync.Struct @struct = a20_RadioSync.readSyncInfo(ac, p, genLog);
      s.writeC(@struct._radioId);
      s.writeC(@struct._areaId);
    }

    public class Struct
    {
      public byte _radioId;
      public byte _areaId;
    }
  }
}
