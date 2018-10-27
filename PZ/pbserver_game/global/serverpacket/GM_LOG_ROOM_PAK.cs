
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class GM_LOG_ROOM_PAK : SendPacket
  {
    private Account player;

    public GM_LOG_ROOM_PAK(Account p)
    {
      this.player = p;
    }

    public override void write()
    {
      this.writeH((short) 2687);
      this.writeD(0);
      this.writeQ(this.player.player_id);
    }
  }
}
