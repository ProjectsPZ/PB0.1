
using Battle.data.xml;
using System;

namespace Battle.data.models
{
  public class ObjectInfo
  {
    public int _life = 100;
    public int _id;
    public int DestroyState;
    public AnimModel _anim;
    public DateTime lastInteractionTime;
    public DateTime animStartTime;
    public ObjModel _model;

    public ObjectInfo()
    {
    }

    public ObjectInfo(int id)
    {
      this._id = id;
    }

    public float GetCurrentAnimProgress()
    {
      if (this._anim != null)
        return AllUtils.GetDifferenceBetweenDate(this.lastInteractionTime);
      return 0.0f;
    }
  }
}
