using System.Numerics;

namespace Model.Items
{
    public class BaseIdleItem : BaseItem, IBaseIdleItem
    {
        public override string GetDamageForUI => $"Idle damage: {GetIdleDamage()*10}/sec";

        public BaseIdleItem(string name, BigInteger basecost, BigInteger baseDamage)
                            : base(name, basecost, baseDamage)
        {
        }

        public BigInteger GetIdleDamage()
        {
            return Quantity * BaseDamage;
        }
    }
}