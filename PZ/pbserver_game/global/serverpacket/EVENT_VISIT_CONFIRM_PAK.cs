
using Core.managers.events;
using Core.models.account.players;
using Core.models.enums.errors;
using Core.server;

namespace Game.global.serverpacket
{
  public class EVENT_VISIT_CONFIRM_PAK : SendPacket
  {
    private EventVisitModel _event;
    private PlayerEvent _pev;
    private uint _erro;

    public EVENT_VISIT_CONFIRM_PAK(EventErrorEnum erro, EventVisitModel ev, PlayerEvent pev)
    {
      this._erro = (uint) erro;
      this._event = ev;
      this._pev = pev;
    }

    public override void write()
    {
      this.writeH((short) 2662);
      this.writeD(this._erro);
      if (this._erro != 2147489028U)
        return;
      this.writeD(this._event.id);
      this.writeC((byte) this._pev.LastVisitSequence1);
      this.writeC((byte) this._pev.LastVisitSequence2);
      this.writeH(ushort.MaxValue);
      this.writeD(this._event.startDate);
    }
  }
}
