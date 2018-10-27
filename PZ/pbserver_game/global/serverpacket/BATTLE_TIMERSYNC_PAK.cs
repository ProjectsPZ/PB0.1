
using Core.server;
using Game.data.model;
using Game.data.utils;

namespace Game.global.serverpacket
{
  public class BATTLE_TIMERSYNC_PAK : SendPacket
  {
    private Room _r;

    public BATTLE_TIMERSYNC_PAK(Room r)
    {
      this._r = r;
    }

    public override void write()
    {
      this.writeH((short) 3371);
      this.writeC((byte) this._r.rodada);
      this.writeD(this._r.getInBattleTimeLeft());
      this.writeH(AllUtils.getSlotsFlag(this._r, true, false));
    }
  }
}
