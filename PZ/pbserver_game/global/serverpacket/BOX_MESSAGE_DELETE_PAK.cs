
using Core.server;
using System.Collections.Generic;

namespace Game.global.serverpacket
{
  public class BOX_MESSAGE_DELETE_PAK : SendPacket
  {
    private uint _erro;
    private List<object> _objs;

    public BOX_MESSAGE_DELETE_PAK(uint erro, List<object> objs)
    {
      this._erro = erro;
      this._objs = objs;
    }

    public override void write()
    {
      this.writeH((short) 425);
      this.writeD(this._erro);
      this.writeC((byte) this._objs.Count);
      foreach (int num in this._objs)
        this.writeD(num);
    }
  }
}
