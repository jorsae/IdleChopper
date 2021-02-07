using System.Numerics;

namespace Model.Items
{
    public abstract class BaseClickItem : BaseItem, IBaseClickItem
    {
        public override string GetDamageForUI => $"Click Damage: {GetClickDamage()}";

        protected BaseClickItem(string name, BigInteger basecost, BigInteger baseDamage)
                                : base(name, basecost, baseDamage)
        {
        }

        public BigInteger GetClickDamage()
        {
            return Quantity * BaseDamage;
        }
    }
}