using System;

namespace Model.Upgrades
{
    public abstract class BaseUpgrade : IUpgrade
    {
        private String _Name;
        public string Name { get => _Name; set => _Name = value; }

        private double _Basecost;
        public double Basecost { get => _Basecost; set => _Basecost = value; }

        private double _BaseDamage;
        public double BaseDamage { get => _BaseDamage; set => _BaseDamage = value; }

        private int _Quantity;
        public int Quantity { get => _Quantity; set => _Quantity = value; }

        private double _Multiplier;
        public double Multiplier { get => _Multiplier; set => _Multiplier = value; }

        private AttackType _DamageType;
        public AttackType DamageType { get => _DamageType; set => _DamageType = value; }

        protected BaseUpgrade(string name, double basecost, double baseDamage)
        {
            Name = name;
            Basecost = basecost;
            BaseDamage = baseDamage;
            Quantity = 0;
            Multiplier = 1.2;
            DamageType = AttackType.IdleDamage;
        }

        public virtual double GetSinglePurchaseCost()
        {
            return Basecost * (Math.Pow(Multiplier, Quantity));
        }

        public virtual double GetBulkPurchaseCost(double quantity)
        {
            //basecost * ((multiplier**51) - 1) / (multiplier - 1)
            return GetSinglePurchaseCost() * Math.Pow(Multiplier, quantity) / (Multiplier - 1);
        }

        public virtual double GetMaxNumberOfUpgrades(double coins)
        {
            double singleCost = GetSinglePurchaseCost();
            if (singleCost > coins)
                return 0;

            //Math.log(1 + ((costBase - 1) * money / singlePurchaseCost)) / Math.log(costBase);
            return Math.Log(1 + ((Multiplier - 1) * coins / singleCost) / Math.Log(Multiplier));
        }
    }
}