
using Core;

namespace Game.data.chat
{
  public static class ChangeServerMode
  {
    public static string EnableTestMode()
    {
      if (ConfigGS.isTestMode)
        return Translation.GetLabel("AlreadyTestModeOn");
      ConfigGS.isTestMode = true;
      return Translation.GetLabel("TestModeOn");
    }

    public static string EnablePublicMode()
    {
      if (!ConfigGS.isTestMode)
        return Translation.GetLabel("AlreadyTestModeOff");
      ConfigGS.isTestMode = false;
      return Translation.GetLabel("TestModeOff");
    }
  }
}
