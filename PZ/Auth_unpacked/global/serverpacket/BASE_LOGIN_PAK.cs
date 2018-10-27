
using Core.models.enums.errors;
using Core.server;

namespace Auth.global.serverpacket
{
  public class BASE_LOGIN_PAK : SendPacket
  {
    private uint _result;
    private string _login;
    private long _pId;

    public BASE_LOGIN_PAK(uint result, string login, long pId)
    {
      this._result = result;
      this._login = login;
      this._pId = pId;
    }

    public BASE_LOGIN_PAK(int result, string login, long pId)
      : this((uint) result, login, pId)
    {
    }

    public BASE_LOGIN_PAK(EventErrorEnum result, string login, long pId)
      : this((uint) result, login, pId)
    {
    }

    public override void write()
    {
      this.writeH((short) 2564);
      this.writeD(this._result);
      this.writeC((byte) 0);
      this.writeQ(this._pId);
      this.writeC((byte) this._login.Length);
      this.writeS(this._login, this._login.Length);
      this.writeC((byte) 0);
      this.writeC((byte) 0);
    }
  }
}
