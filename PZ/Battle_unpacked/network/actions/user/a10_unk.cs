
using Battle.data.models;

namespace Battle.network.actions.user
{
  public class a10_unk
  {
    public static a10_unk.Struct readSyncInfo(ActionModel ac, ReceivePacket p, bool genLog)
    {
      a10_unk.Struct @struct = new a10_unk.Struct()
      {
        _unkV = p.readC(),
        _unkV2 = p.readC()
      };
      if (genLog)
        Logger.warning("Slot " + (object) ac._slot + " action 16: unk (" + (object) @struct._unkV + ";" + (object) @struct._unkV2 + ")", false);
      return @struct;
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
    {
      a10_unk.Struct @struct = a10_unk.readSyncInfo(ac, p, genLog);
      s.writeC(@struct._unkV);
      s.writeC(@struct._unkV2);
    }

    public class Struct
    {
      public byte _unkV;
      public byte _unkV2;
    }
  }
}
