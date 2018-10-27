
using Core.managers;
using Core.models.account;
using Core.models.account.players;
using Core.models.account.title;
using Core.models.enums;
using Core.models.enums.flags;
using Core.server;
using Game.data.managers;
using Game.data.sync;
using Game.data.xml;
using System;
using System.Collections.Generic;
using System.Net;

namespace Game.data.model
{
  public class Account
  {
    public byte[] LocalIP = new byte[4];
    public string player_name = "";
    public int channelId = -1;
    public int _slotId = -1;
    public int matchSlot = -1;
    public PlayerEquipedItems _equip = new PlayerEquipedItems();
    public PlayerInventory _inventory = new PlayerInventory();
    public PlayerMissions _mission = new PlayerMissions();
    public PlayerStats _statistic = new PlayerStats();
    public FriendSystem FriendSystem = new FriendSystem();
    public PlayerTitles _titles = new PlayerTitles();
    public AccountStatus _status = new AccountStatus();
    public bool _isOnline;
    public bool HideGMcolor;
    public bool AntiKickGM;
    public bool LoadedShop;
    public bool DebugPing;
    public string password;
    public string login;
    public long player_id;
    public long ban_obj_id;
    public uint LastRankUpDate;
    public uint LastLoginDate;
    public IPAddress PublicIP;
    public CupomEffects effects;
    public PlayerSession Session;
    public int LastRoomPage;
    public int LastPlayerPage;
    public int tourneyLevel;
    public int clanAccess;
    public int clanDate;
    public int _exp;
    public int _gp;
    public int clanId;
    public int _money;
    public int brooch;
    public int insignia;
    public int medal;
    public int blue_order;
    public int name_color;
    public int _rank;
    public int pc_cafe;
    public PlayerConfig _config;
    public GameClient _connection;
    public Room _room;
    public PlayerBonus _bonus;
    public Match _match;
    public AccessLevel access;
    public PlayerEvent _event;
    public DateTime LastSlotChange;
    public DateTime LastLobbyEnter;
    public DateTime LastPingDebug;

    public Account()
    {
      this.LastSlotChange = DateTime.Now;
      this.LastLobbyEnter = DateTime.Now;
    }

    public void SimpleClear()
    {
      this._titles = new PlayerTitles();
      this._mission = new PlayerMissions();
      this._inventory = new PlayerInventory();
      this._status = new AccountStatus();
      this.FriendSystem.CleanList();
      this.Session = (PlayerSession) null;
      this._event = (PlayerEvent) null;
      this._match = (Match) null;
      this._room = (Room) null;
      this._config = (PlayerConfig) null;
      this._connection = (GameClient) null;
    }

    public void SetPublicIP(IPAddress address)
    {
      if (address == null)
        this.PublicIP = new IPAddress(new byte[4]);
      this.PublicIP = address;
    }

    public void SetPublicIP(string address)
    {
      this.PublicIP = IPAddress.Parse(address);
    }

    public Channel getChannel()
    {
      return ChannelsXML.getChannel(this.channelId);
    }

    public void ResetPages()
    {
      this.LastRoomPage = 0;
      this.LastPlayerPage = 0;
    }

    public bool getChannel(out Channel channel)
    {
      channel = ChannelsXML.getChannel(this.channelId);
      return channel != null;
    }

    public void setOnlineStatus(bool online)
    {
          if (_isOnline != online && ComDiv.updateDB("accounts", "online", online, "player_id", player_id))
        return;
      this._isOnline = online;
    }

    public void updateCacheInfo()
    {
      if (this.player_id == 0L)
        return;
      lock (AccountManager._contas)
        AccountManager._contas[this.player_id] = this;
    }

    public int getRank()
    {
      if (this._bonus != null && this._bonus.fakeRank != 55)
        return this._bonus.fakeRank;
      return this._rank;
    }

    public void Close(int time, bool kicked = false)
    {
      if (this._connection == null)
        return;
      this._connection.Close(time, kicked);
    }

    public void SendPacket(SendPacket sp)
    {
      if (this._connection == null)
        return;
      this._connection.SendPacket(sp);
    }

    public void SendPacket(SendPacket sp, bool OnlyInServer)
    {
      if (this._connection != null)
      {
        this._connection.SendPacket(sp);
      }
      else
      {
        if (OnlyInServer || this._status.serverId == byte.MaxValue || (int) this._status.serverId == ConfigGS.serverId)
          return;
        Game_SyncNet.SendBytes(this.player_id, sp, (int) this._status.serverId);
      }
    }

    public void SendPacket(byte[] data)
    {
      if (this._connection == null)
        return;
      this._connection.SendPacket(data);
    }

    public void SendPacket(byte[] data, bool OnlyInServer)
    {
      if (this._connection != null)
      {
        this._connection.SendPacket(data);
      }
      else
      {
        if (OnlyInServer || this._status.serverId == byte.MaxValue || (int) this._status.serverId == ConfigGS.serverId)
          return;
        Game_SyncNet.SendBytes(this.player_id, data, (int) this._status.serverId);
      }
    }

    public void SendCompletePacket(byte[] data)
    {
      if (this._connection == null)
        return;
      this._connection.SendCompletePacket(data);
    }

    public void SendCompletePacket(byte[] data, bool OnlyInServer)
    {
      if (this._connection != null)
      {
        this._connection.SendCompletePacket(data);
      }
      else
      {
        if (OnlyInServer || this._status.serverId == byte.MaxValue || (int) this._status.serverId == ConfigGS.serverId)
          return;
        Game_SyncNet.SendCompleteBytes(this.player_id, data, (int) this._status.serverId);
      }
    }

    public void LoadInventory()
    {
      lock (this._inventory._items)
        this._inventory._items.AddRange((IEnumerable<ItemsModel>) PlayerManager.getInventoryItems(this.player_id));
    }

    public void LoadMissionList()
    {
      PlayerMissions mission = MissionManager.getInstance().getMission(this.player_id, this._mission.mission1, this._mission.mission2, this._mission.mission3, this._mission.mission4);
      if (mission == null)
        MissionManager.getInstance().addMissionDB(this.player_id);
      else
        this._mission = mission;
    }

    public void LoadPlayerBonus()
    {
      PlayerBonus playerBonusDb = PlayerManager.getPlayerBonusDB(this.player_id);
      if (playerBonusDb.ownerId == 0L)
      {
        PlayerManager.CreatePlayerBonusDB(this.player_id);
        playerBonusDb.ownerId = this.player_id;
      }
      this._bonus = playerBonusDb;
    }

    public uint getSessionId()
    {
      if (this.Session == null)
        return 0;
      return this.Session._sessionId;
    }

    public void SetPlayerId(long id)
    {
      this.player_id = id;
      this.GetAccountInfos(35);
    }

    public void SetPlayerId(long id, int LoadType)
    {
      this.player_id = id;
      this.GetAccountInfos(LoadType);
    }

    public void GetAccountInfos(int LoadType)
    {
      if (LoadType <= 0 || this.player_id <= 0L)
        return;
      if ((LoadType & 1) == 1)
        this._titles = TitleManager.getInstance().getTitleDB(this.player_id);
      if ((LoadType & 2) == 2)
        this._bonus = PlayerManager.getPlayerBonusDB(this.player_id);
      if ((LoadType & 4) == 4)
      {
        List<Friend> friendList = PlayerManager.getFriendList(this.player_id);
        if (friendList.Count > 0)
        {
          this.FriendSystem._friends = friendList;
          AccountManager.getFriendlyAccounts(this.FriendSystem);
        }
      }
      if ((LoadType & 8) == 8)
        this._event = PlayerManager.getPlayerEventDB(this.player_id);
      if ((LoadType & 16) == 16)
        this._config = PlayerManager.getConfigDB(this.player_id);
      if ((LoadType & 32) != 32)
        return;
      List<Friend> friendList1 = PlayerManager.getFriendList(this.player_id);
      if (friendList1.Count <= 0)
        return;
      this.FriendSystem._friends = friendList1;
    }

    public bool UseChatGM()
    {
      if (this.HideGMcolor)
        return false;
      if (this._rank != 53)
        return this._rank == 54;
      return true;
    }

    public bool IsGM()
    {
      if (this._rank != 53 && this._rank != 54)
        return this.HaveGMLevel();
      return true;
    }

    public bool HaveGMLevel()
    {
      return this.access > AccessLevel.Streamer;
    }
  }
}
