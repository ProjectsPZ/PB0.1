
using System;

namespace Battle.network.actions.others
{
  public class code1_GrenadeSync
  {
    public static code1_GrenadeSync.Struct ReadInfo(ReceivePacket p, bool genLog, bool OnlyBytes = false)
    {
      return code1_GrenadeSync.BaseReadInfo(p, OnlyBytes, genLog);
    }

    private static code1_GrenadeSync.Struct BaseReadInfo(ReceivePacket p, bool OnlyBytes, bool genLog)
    {
      code1_GrenadeSync.Struct @struct = new code1_GrenadeSync.Struct()
      {
        _weaponInfo = p.readUH(),
        _weaponSlot = p.readC(),
        _unk = p.readUH(),
        _objPos_x = p.readUH(),
        _objPos_y = p.readUH(),
        _objPos_z = p.readUH(),
        _unk5 = p.readUH(),
        _unk6 = p.readUH(),
        _unk7 = p.readUH(),
        _grenadesCount = p.readUH()
      };
      @struct._unk8 = p.readB(6);
      if (!OnlyBytes)
      {
        @struct.WeaponNumber = (int) @struct._weaponInfo >> 6;
        @struct.WeaponClass = (int) @struct._weaponInfo & 47;
      }
      if (genLog)
      {
        Logger.warning("[code1_GrenadeSync] " + BitConverter.ToString(p.getBuffer()), false);
        Logger.warning("[code1_GrenadeSync] wInfo: " + (object) @struct._weaponInfo + "; wSlot: " + (object) @struct._weaponSlot + "; u: " + (object) @struct._unk + "; obpX: " + (object) @struct._objPos_x + "; obpY: " + (object) @struct._objPos_y + "; obpZ: " + (object) @struct._objPos_z + "; u5: " + (object) @struct._unk5 + "; u6: " + (object) @struct._unk6 + "; u7: " + (object) @struct._unk7 + "; u8: " + (object) @struct._unk8, false);
      }
      return @struct;
    }

    public static byte[] ReadInfo(ReceivePacket p)
    {
      return p.readB(25);
    }

    public static void writeInfo(SendPacket s, ReceivePacket p)
    {
      s.writeB(code1_GrenadeSync.ReadInfo(p));
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
    {
      code1_GrenadeSync.Struct @struct = code1_GrenadeSync.ReadInfo(p, genLog, true);
      s.writeH(@struct._weaponInfo);
      s.writeC(@struct._weaponSlot);
      s.writeH(@struct._unk);
      s.writeH(@struct._objPos_x);
      s.writeH(@struct._objPos_y);
      s.writeH(@struct._objPos_z);
      s.writeH(@struct._unk5);
      s.writeH(@struct._unk6);
      s.writeH(@struct._unk7);
      s.writeH(@struct._grenadesCount);
      s.writeB(@struct._unk8);
    }

    public class Struct
    {
      public int WeaponNumber;
      public int WeaponClass;
      public ushort _weaponInfo;
      public ushort _objPos_x;
      public ushort _objPos_y;
      public ushort _objPos_z;
      public ushort _unk;
      public ushort _unk5;
      public ushort _unk6;
      public ushort _unk7;
      public ushort _grenadesCount;
      public byte _weaponSlot;
      public byte[] _unk8;
    }
  }
}
