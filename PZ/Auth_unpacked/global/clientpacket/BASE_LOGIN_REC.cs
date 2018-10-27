
using Auth.data.managers;
using Auth.data.model;
using Auth.data.sync;
using Auth.data.sync.server_side;
using Auth.global.serverpacket;
using Core;
using Core.managers;
using Core.managers.server;
using Core.models.enums.errors;
using Core.models.enums.global;
using Core.models.servers;
using Core.server;
using Core.xml;
using System;
using System.Net.NetworkInformation;

namespace Auth.global.clientpacket
{
  public class BASE_LOGIN_REC : ReceiveLoginPacket
  {
    private string login;
    private string passN;
    private string passEnc;
    private string UserFileListMD5;
    private string d3d9MD5;
    private string GameVersion;
    private string PublicIP;
    private string LocalIP;
    private int loginSize;
    private int passSize;
    private int IsRealIP;
    private ulong key;
    private ClientLocale GameLocale;
    private PhysicalAddress MacAddress;

    public BASE_LOGIN_REC(LoginClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.GameVersion = ((int) this.readC()).ToString() + "." + (object) this.readH() + "." + (object) this.readH();
      this.GameLocale = (ClientLocale) this.readC();
      this.loginSize = (int) this.readC();
      this.passSize = (int) this.readC();
      this.login = this.readS(this.loginSize);
      this.passN = this.readS(this.passSize);
      this.passEnc = ComDiv.gen5(this.passN);
      this.MacAddress = new PhysicalAddress(this.readB(6));
      this.readB(2);
      this.IsRealIP = (int) this.readC();
      this.LocalIP = ((int) this.readC()).ToString() + "." + (object) this.readC() + "." + (object) this.readC() + "." + (object) this.readC();
      this.key = this.readUQ();
      this.UserFileListMD5 = this.readS(32);
      this.readD();
      this.d3d9MD5 = this.readS(32);
      int num = (int) this.readC();
      this.PublicIP = this._client.GetIPAddress();
    }

    public override void run()
    {
      try
      {
        bool isD3D9Valid = DirectXML.IsValid(this.d3d9MD5);
        if (!isD3D9Valid)
          Logger.warning("No listed: " + this.d3d9MD5);
        ServerConfig config = LoginManager.Config;
        string reason;
        if (!this.IsPacketDataValid(config, isD3D9Valid, out reason))
        {
          Logger.LogLogin(reason);
          this._client.SendPacket((SendPacket) new SERVER_MESSAGE_DISCONNECT_PAK(2147483904U, false));
          this._client.Close(1000, true);
        }
        else
        {
          this._client._player = AccountManager.getInstance().getAccountDB((object) this.login, (object) null, 0, 0);
          if (this._client._player == null && ConfigGA.AUTO_ACCOUNTS && !AccountManager.getInstance().CreateAccount(out this._client._player, this.login, this.passEnc, this._client.GetAddress()))
          {
            Logger.LogLogin("Falha ao criar conta automaticamente [" + this.login + "]");
            this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(EventErrorEnum.Login_USER_PASS_FAIL, this.login, 0L));
            this._client.Close(1000, false);
          }
          else
          {
            Account player = this._client._player;
            if (player == null || !player.ComparePassword(this.passEnc))
            {
              string str = "";
              if (player == null)
                str = "Conta retornada da DB é nula";
              else if (!player.ComparePassword(this.passEnc))
                str = "Senha inválida";
              Logger.LogLogin(str + " [" + this.login + "]");
              this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(EventErrorEnum.Login_USER_PASS_FAIL, this.login, 0L));
              this._client.Close(1000, false);
            }
            else if (player.access >= 0)
            {
              if (player.MacAddress != this.MacAddress)
                ComDiv.updateDB("accounts", "last_mac", (object) this.MacAddress, "player_id", (object) player.player_id);
              bool validMac;
              bool validIp;
              BanManager.GetBanStatus(this.MacAddress.ToString(), this.PublicIP, out validMac, out validIp);
              if (validMac | validIp)
              {
                if (validMac)
                  Logger.LogLogin("MAC banido [" + this.login + "]");
                else
                  Logger.LogLogin("IP banido [" + this.login + "]");
                this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(validIp ? EventErrorEnum.Login_BLOCK_IP : EventErrorEnum.Login_BLOCK_ACCOUNT, this.login, 0L));
                this._client.Close(1000, false);
              }
              else if (player.IsGM() && config.onlyGM || player.access >= 0 && !config.onlyGM)
              {
                Account account = AccountManager.getInstance().getAccount(player.player_id, true);
                if (!player._isOnline)
                {
                  if (BanManager.GetAccountBan(player.ban_obj_id).endDate > DateTime.Now)
                  {
                    Logger.LogLogin("Conta com banimento ativo [" + this.login + "]");
                    this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(EventErrorEnum.Login_BLOCK_ACCOUNT, this.login, 0L));
                    this._client.Close(1000, false);
                  }
                  else
                  {
                    player.SetPlayerId(player.player_id, 31);
                    player._clanPlayers = ClanManager.getClanPlayers(player.clan_id, player.player_id);
                    this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(0, this.login, player.player_id));
                    this._client.SendPacket((SendPacket) new AUTH_WEB_CASH_PAK(0, 0, 0));
                    if (player.clan_id > 0)
                      this._client.SendPacket((SendPacket) new BASE_USER_CLAN_MEMBERS_PAK(player._clanPlayers));
                    player._status.SetData(uint.MaxValue, player.player_id);
                    player._status.updateServer((byte) 0);
                    player.setOnlineStatus(true);
                    if (account != null)
                      account._connection = this._client;
                    SEND_REFRESH_ACC.RefreshAccount(player, true);
                  }
                }
                else
                {
                  Logger.LogLogin("Conta online [" + this.login + "]");
                  this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(EventErrorEnum.Login_ALREADY_LOGIN_WEB, this.login, 0L));
                  if (account != null && account._connection != null)
                  {
                    account.SendPacket((SendPacket) new AUTH_ACCOUNT_KICK_PAK(1));
                    account.SendPacket((SendPacket) new SERVER_MESSAGE_ERROR_PAK(2147487744U));
                    account.Close(1000);
                  }
                  else
                    Auth_SyncNet.SendLoginKickInfo(player);
                  this._client.Close(1000, false);
                }
              }
              else
              {
                Logger.LogLogin("Nível de acesso inválido [" + this.login + "]");
                this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(EventErrorEnum.Login_TIME_OUT_2, this.login, 0L));
                this._client.Close(1000, false);
              }
            }
            else
            {
              Logger.LogLogin("Banido permanente [" + this.login + "]");
              this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(EventErrorEnum.Login_BLOCK_ACCOUNT, this.login, 0L));
              this._client.Close(1000, false);
            }
          }
        }
      }
      catch (Exception ex)
      {
        Logger.warning("[BASE_LOGIN_REC] " + ex.ToString());
      }
    }

    private bool IsPacketDataValid(ServerConfig cfg, bool isD3D9Valid, out string reason)
    {
      string str = "success";
      if (cfg == null)
        str = "Config do servidor inválida [" + this.login + "]";
      else if (!ConfigGA.isTestMode && !ConfigGA.GameLocales.Contains(this.GameLocale))
        str = "País: " + (object) this.GameLocale + " do cliente bloqueado [" + this.login + "]";
      else if (this.login.Length < ConfigGA.minLoginSize)
        str = "Login muito pequeno [" + this.login + "]";
      else if (!ConfigGA.isTestMode && this.passN.Length < ConfigGA.minPassSize)
        str = "Senha muito pequena [" + this.login + "]";
      else if (this.login.Length > ConfigGA.maxLoginSize)
        str = "Login muito longo [" + this.login + "]";
      else if (this.passN.Length > ConfigGA.maxPassSize)
        str = "Senha muito longa [" + this.login + "]";
      else if (this.LocalIP == "0.0.0.0")
        str = "IP inválido. [" + this.login + "]";
      else if (this.MacAddress.GetAddressBytes() == new byte[6])
        str = "MAC inválido. [" + this.login + "]";
      else if (this.GameVersion != cfg.ClientVersion)
        str = "Versão: " + this.GameVersion + " não compatível [" + this.login + "]";
      else if (ConfigGA.LauncherKey > 0UL && (long) this.key != (long) ConfigGA.LauncherKey)
        str = "Chave: " + (object) this.key + " não compatível [" + this.login + "]";
      else if (this._client._player != null)
        str = "Conta já definida [" + this.login + "]";
      reason = str;
      return str == "success";
    }

    private void LoginQueue()
    {
      GameServerModel server = ServersXML.getServer(0);
      if (server._LastCount < server._maxPlayers)
        return;
      if (LoginManager._loginQueue.Count >= 100)
      {
        this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(EventErrorEnum.Login_SERVER_USER_FULL, this.login, 0L));
        Logger.LogLogin("Servidor cheio [" + this.login + "]");
        this._client.Close(1000, false);
      }
      else
      {
        int num = LoginManager.EnterQueue(this._client);
        this._client.SendPacket((SendPacket) new A_LOGIN_QUEUE_PAK(num + 1, (num + 1) * 120));
      }
    }
  }
}
