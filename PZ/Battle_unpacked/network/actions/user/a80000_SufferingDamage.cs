
using Battle.data.models;

namespace Battle.network.actions.user
{
  public class a80000_SufferingDamage
  {
    public static a80000_SufferingDamage.Struct ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
    {
      a80000_SufferingDamage.Struct @struct = new a80000_SufferingDamage.Struct()
      {
        _hitEffects = p.readC(),
        _hitPart = p.readC()
      };
      if (genLog)
      {
        Logger.warning("[1] Effect: " + (object) ((int) @struct._hitEffects >> 4) + "; By slot: " + (object) ((int) @struct._hitEffects & 15), false);
        Logger.warning("[2] Slot " + (object) ac._slot + " action 524288: " + (object) @struct._hitEffects + ";" + (object) @struct._hitPart, false);
      }
      return @struct;
    }

    public static void ReadInfo(ReceivePacket p)
    {
      p.Advance(2);
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
    {
      a80000_SufferingDamage.Struct info = a80000_SufferingDamage.ReadInfo(ac, p, genLog);
      a80000_SufferingDamage.writeInfo(s, info);
    }

    public static void writeInfo(SendPacket s, a80000_SufferingDamage.Struct info)
    {
      s.writeC(info._hitEffects);
      s.writeC(info._hitPart);
    }

    public class Struct
    {
      public byte _hitEffects;
      public byte _hitPart;
    }
  }
}
