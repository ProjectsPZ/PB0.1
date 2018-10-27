
namespace Battle.network.packets
{
  public class Packet66Creator
  {
    public static byte[] getCode66()
    {
      using (SendPacket sendPacket = new SendPacket())
      {
        sendPacket.writeC((byte) 66);
        sendPacket.writeC((byte) 0);
        sendPacket.writeT(0.0f);
        sendPacket.writeC((byte) 0);
        sendPacket.writeH((short) 13);
        sendPacket.writeD(0);
        return sendPacket.mstream.ToArray();
      }
    }
  }
}
