
using Core.models.account;
using Core.models.account.players;
using Core.server;
using System.Collections.Generic;

namespace Auth.global.serverpacket
{
  public class BASE_USER_FRIENDS_PAK : SendPacket
  {
    private List<Friend> friends;

    public BASE_USER_FRIENDS_PAK(List<Friend> friends)
    {
      this.friends = friends;
    }

    public override void write()
    {
      this.writeH((short) 274);
      this.writeC((byte) this.friends.Count);
      for (int index = 0; index < this.friends.Count; ++index)
      {
        Friend friend = this.friends[index];
        PlayerInfo player = friend.player;
        if (player == null)
        {
          this.writeB(new byte[17]);
        }
        else
        {
          this.writeC((byte) (player.player_name.Length + 1));
          this.writeS(player.player_name, player.player_name.Length + 1);
          this.writeQ(friend.player_id);
          this.writeD(ComDiv.GetFriendStatus(friend));
          this.writeC((byte) player._rank);
          this.writeH((short) 0);
          this.writeC((byte) 0);
        }
      }
    }
  }
}
