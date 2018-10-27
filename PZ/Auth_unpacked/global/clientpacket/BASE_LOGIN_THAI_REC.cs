
using Auth.global.serverpacket;
using Core;
using Core.models.enums.errors;
using Core.models.enums.global;
using Core.models.servers;
using Core.server;
using Core.xml;
using System;
using System.Net.NetworkInformation;

namespace Auth.global.clientpacket
{
  public class BASE_LOGIN_THAI_REC : ReceiveLoginPacket
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

    public BASE_LOGIN_THAI_REC(LoginClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      Logger.warning("Start");
      this.GameVersion = ((int) this.readC()).ToString() + "." + (object) this.readH() + "." + (object) this.readH();
      this.loginSize = (int) this.readH();
      this.login = this.readS(this.loginSize);
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
      Logger.warning("LoginSize: " + (object) this.loginSize + " / " + this.login + " [READ]");
    }

    public override void run()
    {
      try
      {
        this._client.SendPacket((SendPacket) new BASE_LOGIN_PAK(0, "admin", 1L));
        this._client.SendPacket((SendPacket) new AUTH_WEB_CASH_PAK(0, 0, 0));
      }
      catch (Exception ex)
      {
        Logger.warning("[BASE_LOGIN_REC] " + ex.ToString());
      }
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
