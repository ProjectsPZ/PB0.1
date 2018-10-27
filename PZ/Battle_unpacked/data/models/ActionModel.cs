
using Battle.data.enums;

namespace Battle.data.models
{
  public class ActionModel
  {
    public ushort _slot;
    public ushort _lengthData;
    public Events _flags;
    public P2P_SUB_HEAD _type;
    public byte[] _data;
  }
}
