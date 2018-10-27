
using Battle.data.models;

namespace Battle.network.actions.user
{
  public class a80_WeaponRecoil
  {
    public static a80_WeaponRecoil.Struct ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
    {
      a80_WeaponRecoil.Struct @struct = new a80_WeaponRecoil.Struct()
      {
        _RecoilHorzAngle = p.readT(),
        _RecoilHorzMax = p.readT(),
        _RecoilVertAngle = p.readT(),
        _RecoilVertMax = p.readT(),
        _Deviation = p.readT(),
        _weaponId = p.readUH(),
        _weaponSlot = p.readC(),
        _unkV = p.readC(),
        _RecoilHorzCount = p.readC()
      };
      if (genLog)
        Logger.warning("Slot " + (object) ac._slot + " weapon info: (" + (object) @struct._RecoilHorzAngle + ";" + (object) @struct._RecoilHorzMax + ";" + (object) @struct._RecoilVertAngle + ";" + (object) @struct._RecoilVertMax + ";" + (object) @struct._Deviation + ";" + (object) @struct._weaponId + ";" + (object) @struct._weaponSlot + ";" + (object) @struct._unkV + ";" + (object) @struct._RecoilHorzCount + ")", false);
      return @struct;
    }

    public static void ReadInfo(ReceivePacket p)
    {
      p.Advance(25);
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
    {
      a80_WeaponRecoil.Struct @struct = a80_WeaponRecoil.ReadInfo(ac, p, genLog);
      s.writeT(@struct._RecoilHorzAngle);
      s.writeT(@struct._RecoilHorzMax);
      s.writeT(@struct._RecoilVertAngle);
      s.writeT(@struct._RecoilVertMax);
      s.writeT(@struct._Deviation);
      s.writeH(@struct._weaponId);
      s.writeC(@struct._weaponSlot);
      s.writeC(@struct._unkV);
      s.writeC(@struct._RecoilHorzCount);
    }

    public class Struct
    {
      public float _RecoilHorzAngle;
      public float _RecoilHorzMax;
      public float _RecoilVertAngle;
      public float _RecoilVertMax;
      public float _Deviation;
      public ushort _weaponId;
      public byte _weaponSlot;
      public byte _unkV;
      public byte _RecoilHorzCount;
    }
  }
}
