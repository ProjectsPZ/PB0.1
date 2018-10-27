
using Battle.data.models;

namespace Battle.network.actions.user
{
  public class a2_unk
  {
    public static a2_unk.Struct ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
    {
      a2_unk.Struct @struct = new a2_unk.Struct()
      {
        _unkV = p.readUH()
      };
      if (genLog)
        Logger.warning("Slot " + (object) ac._slot + " is moving the crosshair position: posV (" + (object) @struct._unkV + ")", false);
      return @struct;
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
    {
      a2_unk.Struct @struct = a2_unk.ReadInfo(ac, p, genLog);
      s.writeH(@struct._unkV);
    }

    public class Struct
    {
      public ushort _unkV;
    }
  }
}
