
using System;

namespace Battle.data.models
{
  public class PacketModel
  {
    public int _opcode;
    public int _slot;
    public int _round;
    public int _length;
    public int _accountId;
    public int _unkInfo2;
    public int _respawnNumber;
    public int _roundNumber;
    public float _time;
    public byte[] _data;
    public byte[] _withEndData;
    public byte[] _noEndData;
    public DateTime _receiveDate;
  }
}
