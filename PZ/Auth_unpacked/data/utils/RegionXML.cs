
using Core;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Auth.data.utils
{
  public class RegionXML
  {
    public static List<string> regions = new List<string>();

    public static void Load()
    {
      string path = "data/regions.xml";
      if (File.Exists(path))
        RegionXML.parse(path);
      else
        Logger.warning("[RegionXML] Não existe o arquivo: " + path);
    }

    private static void parse(string path)
    {
      XmlDocument xmlDocument = new XmlDocument();
      try
      {
        using (FileStream fileStream = new FileStream(path, FileMode.Open))
        {
          if (fileStream.Length == 0L)
          {
            Logger.warning("[RegionXML] O arquivo está vazio: " + path);
          }
          else
          {
            xmlDocument.Load((Stream) fileStream);
            for (XmlNode xmlNode1 = xmlDocument.FirstChild; xmlNode1 != null; xmlNode1 = xmlNode1.NextSibling)
            {
              if ("list".Equals(xmlNode1.Name))
              {
                for (XmlNode xmlNode2 = xmlNode1.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
                {
                  if ("region".Equals(xmlNode2.Name))
                  {
                    XmlNamedNodeMap attributes = (XmlNamedNodeMap) xmlNode2.Attributes;
                    RegionXML.regions.Add(attributes.GetNamedItem("name").Value);
                  }
                }
              }
            }
          }
          fileStream.Dispose();
          fileStream.Close();
        }
      }
      catch (XmlException ex)
      {
        Logger.error(ex.ToString());
      }
    }
  }
}
