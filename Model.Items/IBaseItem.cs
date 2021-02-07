using System.Numerics;

namespace Model.Items
{
    public interface IBaseItem
    {
        string GetDamageForUI { get; set; }
        BigInteger GetSinglePurchaseCost();
        BigInteger GetBulkPurchaseCost(int quantity);
        int GetMaxNumberOfItems(BigInteger coins);
    }
}