
using Battle.config;
using Battle.data.enums.weapon;
using System;

namespace Battle.network.actions.user
{
  public class a1000_DropWeapon
  {
    public static a1000_DropWeapon.Struct ReadInfo(ReceivePacket p, bool genLog)
    {
      a1000_DropWeapon.Struct @struct = new a1000_DropWeapon.Struct()
      {
        _weaponFlag = p.readC(),
        _weaponClass = p.readC(),
        _weaponId = p.readUH(),
        _ammoPrin = p.readC(),
        _ammoDual = p.readC(),
        _ammoTotal = p.readUH()
      };
      if (genLog)
      {
        Logger.warning("[ActionBuffer]: " + BitConverter.ToString(p.getBuffer()), false);
        Logger.warning("[DropWeapon] Flag: " + (object) @struct._weaponFlag + "; Class: " + (object) (ClassType) @struct._weaponClass + "; Id: " + (object) @struct._weaponId, false);
      }
      return @struct;
    }

    public static void ReadInfo(ReceivePacket p)
    {
      p.Advance(8);
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog, int count)
    {
      a1000_DropWeapon.Struct @struct = a1000_DropWeapon.ReadInfo(p, genLog);
      s.writeC((byte) ((uint) @struct._weaponFlag + (uint) count));
      s.writeC(@struct._weaponClass);
      s.writeH(@struct._weaponId);
      if (Config.useMaxAmmoInDrop)
      {
        s.writeC(byte.MaxValue);
        s.writeC(@struct._ammoDual);
        s.writeH((short) 10000);
      }
      else
      {
        s.writeC(@struct._ammoPrin);
        s.writeC(@struct._ammoDual);
        s.writeH(@struct._ammoTotal);
      }
    }

    public class Struct
    {
      public byte _weaponFlag;
      public byte _weaponClass;
      public byte _ammoPrin;
      public byte _ammoDual;
      public ushort _weaponId;
      public ushort _ammoTotal;
    }
  }
}
