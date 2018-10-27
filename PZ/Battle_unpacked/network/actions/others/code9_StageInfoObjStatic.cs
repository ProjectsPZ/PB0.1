
namespace Battle.network.actions.others
{
  public class code9_StageInfoObjStatic
  {
    public static code9_StageInfoObjStatic.Struct readSyncInfo(ReceivePacket p, bool genLog)
    {
      code9_StageInfoObjStatic.Struct @struct = new code9_StageInfoObjStatic.Struct()
      {
        _isDestroyed = p.readC()
      };
      if (genLog)
        Logger.warning("[code9_StageInfoObjStatic] u: " + (object) @struct._isDestroyed, false);
      return @struct;
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
    {
      code9_StageInfoObjStatic.Struct @struct = code9_StageInfoObjStatic.readSyncInfo(p, genLog);
      s.writeC(@struct._isDestroyed);
    }

    public class Struct
    {
      public byte _isDestroyed;
    }
  }
}
