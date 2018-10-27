
using Battle.config;
using Battle.data.enums;
using Battle.data.enums.weapon;
using SharpDX;
using System;
using System.Net;

namespace Battle.data.models
{
  public class Player
  {
    public int _slot = -1;
    public int _life = 100;
    public int _maxLife = 100;
    public int _playerIdByUser = -2;
    public int _playerIdByServer = -1;
    public int _respawnByUser = -2;
    public int _respawnByServer = -1;
    public bool isDead = true;
    public bool _neverRespawn = true;
    public bool Integrity = true;
    public int _team;
    public int WeaponSlot;
    public int _respawnByLogic;
    public float _plantDuration;
    public float _defuseDuration;
    public float _C4FTime;
    public Half3 Position;
    public IPEndPoint _client;
    public DateTime _date;
    public DateTime LastPing;
    public DateTime LastDie;
    public DateTime _C4First;
    public ClassType WeaponClass;
    public CHARACTER_RES_ID _character;
    public bool Immortal;

    public Player(int slot)
    {
      this._slot = slot;
      this._team = slot % 2;
    }

    public void LogPlayerPos(Half3 EndBullet)
    {
      Logger.warning("[Player position] X: " + (object) this.Position.X + "; Y: " + (object) this.Position.Y + "; Z: " + (object) this.Position.Z, false);
      Logger.warning("[End Bullet position] X: " + (object) EndBullet.X + "; Y: " + (object) EndBullet.Y + "; Z: " + (object) EndBullet.Z, false);
    }

    public bool CompareIP(IPEndPoint ip)
    {
      return this._client != null && ip != null && this._client.Address.Equals((object) ip.Address) && this._client.Port == ip.Port;
    }

    public bool RespawnIsValid()
    {
      return this._respawnByServer == this._respawnByUser;
    }

    public bool RespawnLogicIsValid()
    {
      return this._respawnByServer == this._respawnByLogic;
    }

    public bool AccountIdIsValid()
    {
      return this._playerIdByServer == this._playerIdByUser;
    }

    public bool AccountIdIsValid(int number)
    {
      return this._playerIdByServer == number;
    }

    public void CheckLifeValue()
    {
      if (this._life <= this._maxLife)
        return;
      this._life = this._maxLife;
    }

    public void ResetAllInfos()
    {
      this._client = (IPEndPoint) null;
      this._date = new DateTime();
      this._playerIdByUser = -2;
      this._playerIdByServer = -1;
      this.Integrity = true;
      this.ResetBattleInfos();
    }

    public void ResetBattleInfos()
    {
      this._respawnByServer = -1;
      this._respawnByUser = -2;
      this._respawnByLogic = 0;
      this.Immortal = false;
      this.isDead = true;
      this._neverRespawn = true;
      this.WeaponClass = ClassType.Unknown;
      this.WeaponSlot = 0;
      this.LastPing = new DateTime();
      this.LastDie = new DateTime();
      this._C4First = new DateTime();
      this._C4FTime = 0.0f;
      this.Position = new Half3();
      this._life = 100;
      this._maxLife = 100;
      this._plantDuration = Config.plantDuration;
      this._defuseDuration = Config.defuseDuration;
    }

    public void ResetLife()
    {
      this._life = this._maxLife;
    }
  }
}
