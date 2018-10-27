
using Battle.data.models;

namespace Battle.network.actions.user
{
  public class a40000_DeathData
  {
    public static a40000_DeathData.Struct ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
    {
      a40000_DeathData.Struct @struct = new a40000_DeathData.Struct()
      {
        _deathType = p.readC(),
        _hitPart = p.readC(),
        _camX = p.readUH(),
        _camY = p.readUH(),
        _camZ = p.readUH(),
        _weaponId = p.readD()
      };
      if (genLog)
        Logger.warning(((int) ac._slot).ToString() + " | " + (object) @struct._deathType + ";" + (object) @struct._hitPart + ";" + (object) @struct._camX + ";" + (object) @struct._camY + ";" + (object) @struct._camZ + ";" + (object) @struct._weaponId, false);
      return @struct;
    }

    public static void ReadInfo(ReceivePacket p)
    {
      p.Advance(12);
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
    {
      a40000_DeathData.Struct info = a40000_DeathData.ReadInfo(ac, p, genLog);
      a40000_DeathData.writeInfo(s, info);
    }

    public static void writeInfo(SendPacket s, a40000_DeathData.Struct info)
    {
      s.writeC(info._deathType);
      s.writeC(info._hitPart);
      s.writeH(info._camX);
      s.writeH(info._camY);
      s.writeH(info._camZ);
      s.writeD(info._weaponId);
    }

    public class Struct
    {
      public byte _deathType;
      public byte _hitPart;
      public ushort _camX;
      public ushort _camY;
      public ushort _camZ;
      public int _weaponId;
    }
  }
}
