using System.Numerics;

namespace Model.Items
{
    public interface IItem
    {
        BigInteger GetSinglePurchaseCost();
        BigInteger GetBulkPurchaseCost(int quantity);
        BigInteger GetMaxNumberOfUpgrades(BigInteger coins);
    }
}