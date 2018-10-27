
using Battle.data.enums.bomb;
using Battle.data.models;
using Battle.data.sync;
using System;

namespace Battle.network.actions.user
{
  public class a400_Mission
  {
    public static a400_Mission.Struct ReadInfo(ActionModel ac, ReceivePacket p, bool genLog, float time, bool OnlyBytes = false)
    {
      a400_Mission.Struct @struct = new a400_Mission.Struct()
      {
        _bombAll = (int) p.readC(),
        _plantTime = p.readT()
      };
      if (!OnlyBytes)
      {
        @struct.BombEnum = (BombFlag) (@struct._bombAll & 15);
        @struct.BombId = @struct._bombAll >> 4;
      }
      if (genLog)
        Logger.warning("Slot " + (object) ac._slot + " bomb: (" + (object) @struct.BombEnum + "; Id: " + (object) @struct.BombId + "; sTime: " + (object) @struct._plantTime + "; aTime: " + (object) time + ")", false);
      return @struct;
    }

    public static void ReadInfo(ReceivePacket p)
    {
      p.Advance(5);
    }

    public static void SendC4UseSync(Room room, Player pl, a400_Mission.Struct info)
    {
      if (pl == null)
        return;
      int type = info.BombEnum.HasFlag((Enum) BombFlag.Defuse) ? 1 : 0;
      Battle_SyncNet.SendBombSync(room, pl, type, info.BombId);
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog, float pacDate, float plantDuration)
    {
      a400_Mission.Struct info = a400_Mission.ReadInfo(ac, p, genLog, pacDate, false);
      if ((double) info._plantTime > 0.0 && (double) pacDate >= (double) info._plantTime + (double) plantDuration && !info.BombEnum.HasFlag((Enum) BombFlag.Stop))
        info._bombAll += 2;
      a400_Mission.writeInfo(s, info);
    }

    public static void writeInfo(SendPacket s, a400_Mission.Struct info)
    {
      s.writeC((byte) info._bombAll);
      s.writeT(info._plantTime);
    }

    public class Struct
    {
      public int _bombAll;
      public int BombId;
      public BombFlag BombEnum;
      public float _plantTime;
    }
  }
}
