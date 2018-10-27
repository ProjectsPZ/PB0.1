
using Core.models.enums.errors;
using Core.server;

namespace Game.global.serverpacket
{
  public class EVENT_VISIT_REWARD_PAK : SendPacket
  {
    private uint _erro;

    public EVENT_VISIT_REWARD_PAK(EventErrorEnum erro)
    {
      this._erro = (uint) erro;
    }

    public override void write()
    {
      this.writeH((short) 2664);
      this.writeD(this._erro);
    }
  }
}
