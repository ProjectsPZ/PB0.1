
using Battle.config;
using Battle.data.enums.weapon;
using Battle.data.models;

namespace Battle.network.actions.user
{
  public class a800_WeaponAmmo
  {
    public static a800_WeaponAmmo.Struct ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
    {
      a800_WeaponAmmo.Struct @struct = new a800_WeaponAmmo.Struct()
      {
        _weaponFlag = p.readC(),
        _weaponClass = p.readC(),
        _weaponId = p.readUH(),
        _ammoPrin = p.readC(),
        _ammoDual = p.readC(),
        _ammoTotal = p.readUH()
      };
      if (genLog)
        Logger.warning("Slot " + (object) ac._slot + " sync weapon ammo: wFl,wCl,wId,ammoP,ammoD,ammoT (" + (object) @struct._weaponFlag + ";" + (object) (ClassType) @struct._weaponClass + ";" + (object) @struct._weaponId + ";" + (object) @struct._ammoPrin + ";" + (object) @struct._ammoDual + ";" + (object) @struct._ammoTotal + ")", false);
      return @struct;
    }

    public static void ReadInfo(ReceivePacket p)
    {
      p.Advance(8);
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
    {
      a800_WeaponAmmo.Struct @struct = a800_WeaponAmmo.ReadInfo(ac, p, genLog);
      s.writeC(@struct._weaponFlag);
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
