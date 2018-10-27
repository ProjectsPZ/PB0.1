
using Core.models.enums;
using Core.server;

namespace Game.global.serverpacket
{
  public class BATTLE_COUNTDOWN_PAK : SendPacket
  {
    private CountDownEnum type;

    public BATTLE_COUNTDOWN_PAK(CountDownEnum timer)
    {
      this.type = timer;
    }

    public override void write()
    {
      this.writeH((short) 3340);
      this.writeC((byte) this.type);
    }
  }
}
