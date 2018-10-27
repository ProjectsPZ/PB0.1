
using Battle.data.enums;
using Battle.data.models;

namespace Battle.network.actions.user
{
  public class a8_MoveSync
  {
    public static a8_MoveSync.Struct readSyncInfo(ActionModel ac, ReceivePacket p, bool genLog)
    {
      a8_MoveSync.Struct @struct = new a8_MoveSync.Struct()
      {
        _spaceFlags = (CharaMoves) p.readC(),
        _objId = p.readUH()
      };
      if (genLog)
        Logger.warning("Slot " + (object) ac._slot + " action 8: (" + (object) @struct._spaceFlags + ";" + (object) @struct._objId + ")", false);
      return @struct;
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
    {
      a8_MoveSync.Struct info = a8_MoveSync.readSyncInfo(ac, p, genLog);
      a8_MoveSync.writeInfo(s, info);
    }

    public static void writeInfo(SendPacket s, a8_MoveSync.Struct info)
    {
      s.writeC((byte) info._spaceFlags);
      s.writeH(info._objId);
    }

    public class Struct
    {
      public CharaMoves _spaceFlags;
      public ushort _objId;
    }
  }
}
