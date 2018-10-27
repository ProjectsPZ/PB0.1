
using Battle.data.models;
using Battle.data.sync;

namespace Battle.network.actions.user
{
  public class a100000_PassPortal
  {
    public static a100000_PassPortal.Struct ReadInfo(ActionModel ac, ReceivePacket p, bool genLog)
    {
      a100000_PassPortal.Struct @struct = new a100000_PassPortal.Struct()
      {
        _portal = p.readUH()
      };
      if (genLog)
        Logger.warning("Slot " + (object) ac._slot + " passed on the portal [" + (object) @struct._portal + "]", false);
      return @struct;
    }

    public static void ReadInfo(ReceivePacket p)
    {
      p.Advance(2);
    }

    public static void SendPassSync(Room room, Player p, a100000_PassPortal.Struct info)
    {
      Battle_SyncNet.SendPortalPass(room, p, (int) info._portal);
    }

    public static void writeInfo(SendPacket s, ActionModel ac, ReceivePacket p, bool genLog)
    {
      a100000_PassPortal.Struct info = a100000_PassPortal.ReadInfo(ac, p, genLog);
      a100000_PassPortal.writeInfo(s, info);
    }

    public static void writeInfo(SendPacket s, a100000_PassPortal.Struct info)
    {
      s.writeH(info._portal);
    }

    public class Struct
    {
      public ushort _portal;
    }
  }
}
