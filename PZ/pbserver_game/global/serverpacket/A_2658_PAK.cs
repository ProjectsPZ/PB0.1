
using Core.server;

namespace Game.global.serverpacket
{
  public class A_2658_PAK : SendPacket
  {
    private int rewardId;
    private int roomId;
    private string player_name;

    public A_2658_PAK(string player_name, int roomId, int rewardId)
    {
      this.player_name = player_name;
      this.roomId = roomId;
      this.rewardId = rewardId;
    }

    public override void write()
    {
      this.writeH((short) 2658);
      this.writeC((byte) 0);
      this.writeD(0);
      this.writeD(0);
      this.writeD(this.roomId);
      this.writeD(this.rewardId);
      this.writeC((byte) (this.player_name.Length + 1));
      this.writeS(this.player_name, this.player_name.Length + 1);
    }
  }
}
