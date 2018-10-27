
using System;
using System.Collections.Generic;

namespace Battle.network.actions.user
{
  public class a4000_BotHitData
  {
    public static void ReadInfo(ReceivePacket p)
    {
      int num = (int) p.readC();
      p.Advance(15 * num);
    }

    public static List<a4000_BotHitData.HitData> ReadInfo(ReceivePacket p, bool genLog)
    {
      List<a4000_BotHitData.HitData> hitDataList = new List<a4000_BotHitData.HitData>();
      int num = (int) p.readC();
      for (int index = 0; index < num; ++index)
      {
        a4000_BotHitData.HitData hitData = new a4000_BotHitData.HitData()
        {
          _hitInfo = p.readUD(),
          _weaponInfo = p.readUH(),
          _weaponSlot = p.readC(),
          _unk = p.readUH(),
          _eixoX = p.readUH(),
          _eixoY = p.readUH(),
          _eixoZ = p.readUH()
        };
        if (genLog)
        {
          Logger.warning("P: " + (object) hitData._eixoX + ";" + (object) hitData._eixoY + ";" + (object) hitData._eixoZ, false);
          Logger.warning("[" + (object) index + "] 16384: " + BitConverter.ToString(p.getBuffer()), false);
        }
        hitDataList.Add(hitData);
      }
      return hitDataList;
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
    {
      List<a4000_BotHitData.HitData> hitDataList = a4000_BotHitData.ReadInfo(p, genLog);
      s.writeC((byte) hitDataList.Count);
      for (int index = 0; index < hitDataList.Count; ++index)
      {
        a4000_BotHitData.HitData hitData = hitDataList[index];
        s.writeD(hitData._hitInfo);
        s.writeH(hitData._weaponInfo);
        s.writeC(hitData._weaponSlot);
        s.writeH(hitData._unk);
        s.writeH(hitData._eixoX);
        s.writeH(hitData._eixoY);
        s.writeH(hitData._eixoZ);
      }
    }

    public class HitData
    {
      public byte _weaponSlot;
      public ushort _weaponInfo;
      public ushort _eixoX;
      public ushort _eixoY;
      public ushort _eixoZ;
      public ushort _unk;
      public uint _hitInfo;
    }
  }
}
