
namespace Game.data.chat
{
  public static class SearchSessionClient
  {
    public static string genCode1(string str)
    {
      GameManager.GetActiveClient(uint.Parse(str.Substring(13)));
      return "";
    }
  }
}
