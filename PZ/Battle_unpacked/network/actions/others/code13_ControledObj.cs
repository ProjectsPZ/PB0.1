
using System;

namespace Battle.network.actions.others
{
  public class code13_ControledObj
  {
    public static code13_ControledObj.Struct readSyncInfo(ReceivePacket p, bool genLog)
    {
      code13_ControledObj.Struct @struct = new code13_ControledObj.Struct()
      {
        _unk = p.readB(9)
      };
      if (genLog)
        Logger.warning("[code13_ControledObj] " + BitConverter.ToString(@struct._unk), false);
      return @struct;
    }

    public static void writeInfo(SendPacket s, ReceivePacket p, bool genLog)
    {
      code13_ControledObj.Struct @struct = code13_ControledObj.readSyncInfo(p, genLog);
      s.writeB(@struct._unk);
    }

    public class Struct
    {
      public byte[] _unk;
    }
  }
}
