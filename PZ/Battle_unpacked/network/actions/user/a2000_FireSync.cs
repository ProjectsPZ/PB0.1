
namespace Battle.network.actions.user
{
  public class a2000_FireSync
  {
    public static a2000_FireSync.Struct ReadInfo(ReceivePacket p, bool genLog)
    {
      return new a2000_FireSync.Struct()
      {
        _shotId = p.readUH(),
        _shotIndex = p.readUH(),
        _camX = p.readUH(),
        _camY = p.readUH(),
        _camZ = p.readUH(),
        _weaponNumber = p.readD()
      };
    }

    public static void ReadInfo(ReceivePacket p)
    {
      p.Advance(14);
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
    {
      a2000_FireSync.Struct @struct = a2000_FireSync.ReadInfo(p, genLog);
      s.writeH(@struct._shotId);
      s.writeH(@struct._shotIndex);
      s.writeH(@struct._camX);
      s.writeH(@struct._camY);
      s.writeH(@struct._camZ);
      s.writeD(@struct._weaponNumber);
    }

    public class Struct
    {
      public ushort _shotId;
      public ushort _shotIndex;
      public ushort _camX;
      public ushort _camY;
      public ushort _camZ;
      public int _weaponNumber;
    }
  }
}
