
namespace Battle.network.actions.others
{
  public class code6_ObjectAnim
  {
    public static byte[] ReadInfo(ReceivePacket p)
    {
      return p.readB(8);
    }

    public static code6_ObjectAnim.Struct ReadInfo(ReceivePacket p, bool genLog)
    {
      code6_ObjectAnim.Struct @struct = new code6_ObjectAnim.Struct()
      {
        _life = p.readUH(),
        _anim1 = p.readC(),
        _anim2 = p.readC(),
        _syncDate = p.readT()
      };
      if (genLog)
        Logger.warning("[code6_ObjectAnim] u: " + (object) @struct._life + "; u2: " + (object) @struct._anim1 + "; u3: " + (object) @struct._anim2 + "; u4: " + (object) @struct._syncDate, false);
      return @struct;
    }

    public static void writeInfo(SendPacket s, ReceivePacket p)
    {
      s.writeB(code6_ObjectAnim.ReadInfo(p));
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
    {
      code6_ObjectAnim.Struct @struct = code6_ObjectAnim.ReadInfo(p, genLog);
      s.writeH(@struct._life);
      s.writeC(@struct._anim1);
      s.writeC(@struct._anim2);
      s.writeT(@struct._syncDate);
    }

    public class Struct
    {
      public float _syncDate;
      public byte _anim1;
      public byte _anim2;
      public ushort _life;
    }
  }
}
