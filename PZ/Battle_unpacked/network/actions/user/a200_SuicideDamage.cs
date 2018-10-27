
using Battle.data.enums.weapon;
using SharpDX;
using System.Collections.Generic;

namespace Battle.network.actions.user
{
  public class a200_SuicideDamage
  {
    public static List<a200_SuicideDamage.HitData> ReadInfo(ReceivePacket p, bool genLog, bool OnlyBytes = false)
    {
      return a200_SuicideDamage.BaseReadInfo(p, OnlyBytes, genLog);
    }

    private static List<a200_SuicideDamage.HitData> BaseReadInfo(ReceivePacket p, bool OnlyBytes, bool genLog)
    {
      List<a200_SuicideDamage.HitData> hitDataList = new List<a200_SuicideDamage.HitData>();
      int num = (int) p.readC();
      for (int index = 0; index < num; ++index)
      {
        a200_SuicideDamage.HitData hitData = new a200_SuicideDamage.HitData()
        {
          _hitInfo = p.readUD(),
          _weaponInfo = p.readUH(),
          _weaponSlot = p.readC(),
          PlayerPos = p.readUHVector()
        };
        if (!OnlyBytes)
        {
          hitData.WeaponClass = (ClassType) ((int) hitData._weaponInfo & 63);
          hitData.WeaponId = (int) hitData._weaponInfo >> 6;
        }
        if (genLog)
          Logger.warning("[" + (object) index + "] Committed suicide: hitinfo,weaponinfo,weaponslot,camX,camY,camZ (" + (object) hitData._hitInfo + ";" + (object) hitData._weaponInfo + ";" + (object) hitData._weaponSlot + ";" + (object) hitData.PlayerPos.X + ";" + (object) hitData.PlayerPos.Y + ";" + (object) hitData.PlayerPos.Z + ")", false);
        hitDataList.Add(hitData);
      }
      return hitDataList;
    }

    public static void ReadInfo(ReceivePacket p)
    {
      int num = (int) p.readC();
      p.Advance(13 * num);
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
    {
      List<a200_SuicideDamage.HitData> hits = a200_SuicideDamage.ReadInfo(p, genLog, true);
      a200_SuicideDamage.writeInfo(s, hits);
    }

    public static void writeInfo(SendPacket s, List<a200_SuicideDamage.HitData> hits)
    {
      s.writeC((byte) hits.Count);
      for (int index = 0; index < hits.Count; ++index)
      {
        a200_SuicideDamage.HitData hit = hits[index];
        s.writeD(hit._hitInfo);
        s.writeH(hit._weaponInfo);
        s.writeC(hit._weaponSlot);
        s.writeHVector(hit.PlayerPos);
      }
    }

    public class HitData
    {
      public uint _hitInfo;
      public ushort _weaponInfo;
      public Half3 PlayerPos;
      public byte _weaponSlot;
      public ClassType WeaponClass;
      public int WeaponId;
    }
  }
}
