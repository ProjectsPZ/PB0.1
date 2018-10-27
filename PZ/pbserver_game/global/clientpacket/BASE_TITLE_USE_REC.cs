﻿
using Core;
using Core.managers;
using Core.models.account.title;
using Core.server;
using Core.xml;
using Game.data.model;
using Game.global.serverpacket;
using System;

namespace Game.global.clientpacket
{
  public class BASE_TITLE_USE_REC : ReceiveGamePacket
  {
    private byte slotIdx;
    private byte titleId;
    private uint erro;

    public BASE_TITLE_USE_REC(GameClient client, byte[] data)
    {
      this.makeme(client, data);
    }

    public override void read()
    {
      this.slotIdx = this.readC();
      this.titleId = this.readC();
    }

    public override void run()
    {
      try
      {
        Account player = this._client._player;
        if (player == null)
          return;
        PlayerTitles titles = player._titles;
        TitleQ title = TitlesXML.getTitle((int) this.titleId, true);
        TitleQ title1;
        TitleQ title2;
        TitleQ title3;
        TitlesXML.get3Titles(titles.Equiped1, titles.Equiped2, titles.Equiped3, out title1, out title2, out title3, false);
        if (this.slotIdx >= (byte) 3 || this.titleId >= (byte) 45 || (titles == null || title == null) || (title._classId == title1._classId && this.slotIdx != (byte) 0 || title._classId == title2._classId && this.slotIdx != (byte) 1) || (title._classId == title3._classId && this.slotIdx != (byte) 2 || (!titles.Contains(title._flag) || titles.Equiped1 == (int) this.titleId) || (titles.Equiped2 == (int) this.titleId || titles.Equiped3 == (int) this.titleId)))
          this.erro = 2147483648U;
        else if (TitleManager.getInstance().updateEquipedTitle(titles.ownerId, (int) this.slotIdx, (int) this.titleId))
          titles.SetEquip((int) this.slotIdx, (int) this.titleId);
        else
          this.erro = 2147483648U;
        this._client.SendPacket((SendPacket) new BASE_TITLE_USE_PAK(this.erro));
      }
      catch (Exception ex)
      {
        Logger.info("BASE_TITLE_USE_REC: " + ex.ToString());
      }
    }
  }
}
