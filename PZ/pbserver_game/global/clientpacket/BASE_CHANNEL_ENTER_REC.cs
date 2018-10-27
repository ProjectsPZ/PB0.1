
using Core.server;
using Game.data.model;
using Game.data.xml;
using Game.global.serverpacket;

namespace Game.global.clientpacket
{
  public class BASE_CHANNEL_ENTER_REC : ReceiveGamePacket
  {
    private int channelId;

    public BASE_CHANNEL_ENTER_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.channelId = this.readD();
    }

    public override void run()
    {
      Account player = this._client._player;
      if (player == null || player.channelId >= 0)
        return;
      Channel channel = ChannelsXML.getChannel(this.channelId);
      if (channel != null)
      {
        if (this.ChannelRequirementCheck(player, channel))
          this._client.SendPacket((SendPacket) new BASE_CHANNEL_ENTER_PAK(2147484162U));
        else if (channel._players.Count >= ConfigGS.maxChannelPlayers)
        {
          this._client.SendPacket((SendPacket) new BASE_CHANNEL_ENTER_PAK(2147484161U));
        }
        else
        {
          player.channelId = this.channelId;
          this._client.SendPacket((SendPacket) new BASE_CHANNEL_ENTER_PAK(player.channelId, channel._announce));
          player._status.updateChannel((byte) player.channelId);
          player.updateCacheInfo();
        }
      }
      else
        this._client.SendPacket((SendPacket) new BASE_CHANNEL_ENTER_PAK(2147483648U));
    }

    private bool ChannelRequirementCheck(Account p, Channel ch)
    {
      return !p.IsGM() && (ch._type == 4 && p.clanId == 0 || ch._type == 3 && p._statistic.GetKDRatio() > 40 || (ch._type == 2 && p._rank >= 4 || ch._type == 5 && p._rank <= 25));
    }
  }
}
