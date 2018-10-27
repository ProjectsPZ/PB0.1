
using Battle.data.enums;
using SharpDX;

namespace Battle.data.models
{
  public class ObjectHitInfo
  {
    public CHARA_DEATH deathType = CHARA_DEATH.DEFAULT;
    public int syncType;
    public int objSyncId;
    public int objId;
    public int objLife;
    public int weaponId;
    public int killerId;
    public int _animId1;
    public int _animId2;
    public int _destroyState;
    public int hitPart;
    public Half3 Position;
    public float _specialUse;

    public ObjectHitInfo(int type)
    {
      this.syncType = type;
    }
  }
}
