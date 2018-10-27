
namespace Battle.network.actions.user
{
  public class a1_unk
  {
    public static a1_unk.Struct ReadInfo(ReceivePacket p, bool genLog)
    {
      a1_unk.Struct @struct = new a1_unk.Struct()
      {
        _unkV = p.readC(),
        _unkV2 = p.readC(),
        _unkV3 = p.readC(),
        _unkV4 = p.readC()
      };
      if (!genLog)
        ;
      return @struct;
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
    {
      a1_unk.Struct info = a1_unk.ReadInfo(p, genLog);
      a1_unk.writeInfo(s, info);
    }

    public static void writeInfo(SendPacket s, a1_unk.Struct info)
    {
      s.writeC(info._unkV);
      s.writeC(info._unkV2);
      s.writeC(info._unkV3);
      s.writeC(info._unkV4);
    }

    public class Struct
    {
      public byte _unkV;
      public byte _unkV2;
      public byte _unkV3;
      public byte _unkV4;
    }
  }
}
