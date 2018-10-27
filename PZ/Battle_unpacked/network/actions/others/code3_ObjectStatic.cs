
namespace Battle.network.actions.others
{
  public class code3_ObjectStatic
  {
    public static byte[] ReadInfo(ReceivePacket p)
    {
      return p.readB(3);
    }

    public static code3_ObjectStatic.Struct ReadInfo(ReceivePacket p, bool genLog)
    {
      code3_ObjectStatic.Struct @struct = new code3_ObjectStatic.Struct()
      {
        Life = p.readUH(),
        DestroyedBySlot = p.readC()
      };
      if (genLog)
        Logger.warning("[code3_ObjectStatic] Life: " + (object) @struct.Life + "; DestroyedBy: " + (object) @struct.DestroyedBySlot, false);
      return @struct;
    }

    public static void writeInfo(SendPacket s, ReceivePacket p)
    {
      s.writeB(code3_ObjectStatic.ReadInfo(p));
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
    {
      code3_ObjectStatic.Struct @struct = code3_ObjectStatic.ReadInfo(p, genLog);
      s.writeH(@struct.Life);
      s.writeC(@struct.DestroyedBySlot);
    }

    public class Struct
    {
      public byte DestroyedBySlot;
      public ushort Life;
    }
  }
}
