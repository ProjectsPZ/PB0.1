
using Core;
using Core.server;
using System;
using System.Collections.Generic;

namespace Game.global.clientpacket
{
    public class BOX_MESSAGE_VIEW_REC : ReceiveGamePacket
    {
        private List<int> messages = new List<int>();
        private int msgsCount;

        public BOX_MESSAGE_VIEW_REC(GameClient client, byte[] data)
        {
            this.makeme(client, data);
        }

        public override void read()
        {
            this.msgsCount = (int)this.readC();
            for (int index = 0; index < this.msgsCount; ++index)
                this.messages.Add(this.readD());
        }

        public override void run()
        {
            try
            {
                if (this._client == null || this._client._player == null || this.msgsCount == 0)
                    return;
                string TABELA = "player_messages";
                string req1 = "object_id";
                int[] array = this.messages.ToArray();
                string req2 = "owner_id";
                // ISSUE: variable of a boxed type
                object playerId = (ValueType)this._client.player_id;
                string[] COLUNAS = new string[2]
        {
          "expire",
          "state"
        };
                object[] objArray = new object[2];
                int index = 0;
                DateTime dateTime = DateTime.Now;
                dateTime = dateTime.AddDays(7.0);

                object local = (ValueType)long.Parse(dateTime.ToString("yyMMddHHmm"));
                objArray[index] = local;
                objArray[1] = (object)0;
                ComDiv.updateDB(TABELA, req1, array, req2, playerId, COLUNAS, objArray);
            }
            catch (Exception ex)
            {
                Logger.info("[BOX_MESSAGE_VIEW_REC] " + ex.ToString());
            }
        }
    }
}
