
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Battle.data.xml
{
  public class MeleeExceptionsXML
  {
    public static List<MeleeExcep> _items = new List<MeleeExcep>();

    public static bool Contains(int number)
    {
      for (int index = 0; index < MeleeExceptionsXML._items.Count; ++index)
      {
        if (MeleeExceptionsXML._items[index].Number == number)
          return true;
      }
      return false;
    }

    public static void Load()
    {
      string path = "data/battle/exceptions.xml";
      if (File.Exists(path))
        MeleeExceptionsXML.parse(path);
      else
        Logger.warning("[MeleeExceptionsXML] Não existe o arquivo: " + path, false);
    }

    private static void parse(string path)
    {
      XmlDocument xmlDocument = new XmlDocument();
      using (FileStream fileStream = new FileStream(path, FileMode.Open))
      {
        if (fileStream.Length > 0L)
        {
          try
          {
            xmlDocument.Load((Stream) fileStream);
            for (XmlNode xmlNode1 = xmlDocument.FirstChild; xmlNode1 != null; xmlNode1 = xmlNode1.NextSibling)
            {
              if ("list".Equals(xmlNode1.Name))
              {
                for (XmlNode xmlNode2 = xmlNode1.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
                {
                  if ("weapon".Equals(xmlNode2.Name))
                  {
                    XmlNamedNodeMap attributes = (XmlNamedNodeMap) xmlNode2.Attributes;
                    MeleeExcep meleeExcep = new MeleeExcep()
                    {
                      Number = int.Parse(attributes.GetNamedItem("number").Value)
                    };
                    MeleeExceptionsXML._items.Add(meleeExcep);
                  }
                }
              }
            }
          }
          catch (XmlException ex)
          {
            Logger.warning(ex.ToString(), false);
          }
        }
        fileStream.Dispose();
        fileStream.Close();
      }
      Logger.warning("[Aviso] Loaded " + (object) MeleeExceptionsXML._items.Count + " melee exceptions", false);
    }
  }
}
