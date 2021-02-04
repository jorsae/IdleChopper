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
            BigInteger numerator, denominator, totalCost;
            double dPow = Math.Pow(Multiplier, Quantity);
            if (dPow > (double)decimal.MaxValue)
            {
                BigInteger maxDecimal = new BigInteger(decimal.MaxValue);
                BigInteger pow = new BigInteger(Math.Ceiling(Math.Pow(Multiplier, Quantity)));

                if (pow >= maxDecimal)
                    (numerator, denominator) = Fraction(decimal.MaxValue);

                BigInteger counts = pow / maxDecimal;
                BigInteger remainder = pow % maxDecimal;
                totalCost = Basecost * numerator / denominator;
                totalCost *= counts;

                dPow = (double)remainder;
            }
            var (num, den) = Fraction((decimal)dPow);

            return totalCost + (Basecost * num / den);
        }

        public virtual BigInteger GetBulkPurchaseCost(int quantity)
        {
            BigInteger singleCost = GetSinglePurchaseCost();
            double exponent = (Math.Pow(Multiplier, quantity) - 1) / (Multiplier - 1);
            if (double.IsInfinity(exponent))
            {
                BigInteger exp = (BigInteger) ((Math.Pow(Multiplier, quantity) - 1) / (Multiplier - 1));
                return singleCost * exp;
            }
            double result = (double)singleCost * exponent;
            if (double.IsInfinity(result))
                return singleCost * (BigInteger)exponent;
            return (BigInteger)result;
        }

        public virtual BigInteger GetMaxNumberOfUpgrades(BigInteger coins)
        {
            BigInteger singleCost = GetSinglePurchaseCost();
            if (singleCost > coins)
                return 0;
            
            //return Math.Log(1 + ((Multiplier - 1) * coins / singleCost) / Math.Log(Multiplier));
            return 0;
        }

        private (BigInteger numerator, BigInteger denominator) Fraction(decimal value)
        {
            int[] bits = decimal.GetBits(value);
            BigInteger numerator = (1 - ((bits[3] >> 30) & 2)) *
                                   unchecked(((BigInteger)(uint)bits[2] << 64) |
                                             ((BigInteger)(uint)bits[1] << 32) |
                                              (BigInteger)(uint)bits[0]);
            BigInteger denominator = BigInteger.Pow(10, (bits[3] >> 16) & 0xff);
            return (numerator, denominator);
        }
    }
}