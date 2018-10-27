
using Core;
using Core.models.enums;

namespace Game.data.chat
{
  public static class ChangeUdpType
  {
    public static string SetUdpType(string str)
    {
      int num = int.Parse(str.Substring(4));
      if ((SERVER_UDP_STATE) num == ConfigGS.udpType)
        return Translation.GetLabel("ChangeUDPAlready");
      if (num < 1 || num > 4)
        return Translation.GetLabel("ChangeUDPWrongValue");
      ConfigGS.udpType = (SERVER_UDP_STATE) num;
      return Translation.GetLabel("ChangeUDPSuccess", (object) ConfigGS.udpType);
    }
  }
}
