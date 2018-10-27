
using Core.server;
using Game.data.model;
using Game.data.xml;

namespace Game.global.serverpacket
{
  public class BASE_CHANNEL_LIST_PAK : SendPacket
  {
    public override void write()
    {
      this.writeH((short) 2572);
      this.writeD(ChannelsXML._channels.Count);
      this.writeD(ConfigGS.maxChannelPlayers);
      foreach (Channel channel in ChannelsXML._channels)
        this.writeD(channel._players.Count);
    }
  }
}
