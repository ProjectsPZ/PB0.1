
using Core.server;
using Game.data.model;

namespace Game.global.serverpacket
{
  public class A_3415_PAK : SendPacket
  {
    private uint erro;
    private Account p;

    public A_3415_PAK(uint erro, Account p)
    {
      this.erro = erro;
      this.p = p;
    }

    public override void write()
    {
      this.writeH((short) 3415);
      this.writeD(this.erro);
      this.writeH((short) this.p._slotId);
      this.writeD(this.p._equip._red);
      this.writeD(this.p._equip._blue);
      this.writeD(this.p._equip._helmet);
      this.writeD(this.p._equip._beret);
      this.writeD(this.p._equip._dino);
      this.writeD(this.p._equip._primary);
      this.writeD(this.p._equip._secondary);
      this.writeD(this.p._equip._melee);
      this.writeD(this.p._equip._grenade);
      this.writeD(this.p._equip._special);
      this.writeB(new byte[6]);
      this.writeD(this.p._titles.Equiped1);
      this.writeD(this.p._titles.Equiped2);
      this.writeD(this.p._titles.Equiped3);
      this.writeB(new byte[4]);
    }
  }
}
