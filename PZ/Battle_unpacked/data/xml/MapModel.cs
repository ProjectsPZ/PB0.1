
using System.Collections.Generic;

namespace Battle.data.xml
{
  public class MapModel
  {
    public List<ObjModel> _objects = new List<ObjModel>();
    public List<BombPosition> _bombs = new List<BombPosition>();
    public int _id;

    public BombPosition GetBomb(int bombId)
    {
      try
      {
        return this._bombs[bombId];
      }
      catch
      {
        return (BombPosition) null;
      }
    }
  }
}
