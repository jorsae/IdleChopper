using System;
using System.Linq;
using System.Numerics;

namespace Model.Items
{
    public abstract class BaseItem : IItem
    {
        private String _Name;
        public string Name { get => _Name; set => _Name = value; }

        private BigInteger _Basecost;
        public BigInteger Basecost { get => _Basecost; set => _Basecost = value; }

        private BigInteger _BaseDamage;
        public BigInteger BaseDamage { get => _BaseDamage; set => _BaseDamage = value; }

        private int _Quantity;
        public int Quantity { get => _Quantity; set => _Quantity = value; }

        private double _Multiplier;
        public double Multiplier { get => _Multiplier; set => _Multiplier = value; }

        private AttackType _DamageType;
        public AttackType DamageType { get => _DamageType; set => _DamageType = value; }

        protected BaseItem(string name, BigInteger basecost, BigInteger baseDamage)
        {
            Name = name;
            Basecost = basecost;
            BaseDamage = baseDamage;
            Quantity = 0;
            Multiplier = 1.2;
            DamageType = AttackType.IdleDamage;
        }

        public virtual BigInteger GetSinglePurchaseCost()
        {
            double pow = Math.Pow(Multiplier, Quantity);
            var (numerator, denominator) = Fraction(pow);
            return Basecost * numerator / denominator;
            //return initialCost * Math.pow(costBase, currentCount + 1);
        }

        public virtual BigInteger GetBulkPurchaseCost(int quantity)
        {
            double pow = (Math.Pow(Multiplier, quantity) - 1) / (Multiplier - 1);
            var (numerator, denominator) = Fraction(pow);
            return GetSinglePurchaseCost() * numerator / denominator;
        }

        public virtual BigInteger GetMaxNumberOfUpgrades(BigInteger coins)
        {
            BigInteger singleCost = GetSinglePurchaseCost();
            if (singleCost > coins)
                return 0;
            
            
            //return Math.Log(1 + ((Multiplier - 1) * coins / singleCost) / Math.Log(Multiplier));
            return 0;
        }

        private (BigInteger numerator, BigInteger denominator) Fraction(double value)
        {
            //long longValue = BitConverter.DoubleToInt64Bits(value);
            //char[] a = longValue.ToString().ToCharArray();
            //long[] bits = a.Select(item => (long)item).ToArray();
            Decimal d = (Decimal)value;
            int[] bits = decimal.GetBits(d);
            BigInteger numerator = (1 - ((bits[3] >> 30) & 2)) *
                                   unchecked(((BigInteger)(uint)bits[2] << 64) |
                                             ((BigInteger)(uint)bits[1] << 32) |
                                              (BigInteger)(uint)bits[0]);
            BigInteger denominator = BigInteger.Pow(10, (bits[3] >> 16) & 0xff);
            return (numerator, denominator);
        }
    }
}