﻿
using Core.models.account;
using Core.server;

namespace Game.global.serverpacket
{
  public class BOX_MESSAGE_GIFT_RECEIVE_PAK : SendPacket
  {
    private Message gift;

    public BOX_MESSAGE_GIFT_RECEIVE_PAK(Message gift)
    {
      this.gift = gift;
    }

    public override void write()
    {
      this.writeH((short) 553);
      this.writeD(this.gift.object_id);
      this.writeD((uint) this.gift.sender_id);
      this.writeD(this.gift.state);
      this.writeD((uint) this.gift.expireDate);
      this.writeC((byte) (this.gift.sender_name.Length + 1));
      this.writeS(this.gift.sender_name, this.gift.sender_name.Length + 1);
      this.writeC((byte) 6);
      this.writeS("EVENT", 6);
    }
  }
}
