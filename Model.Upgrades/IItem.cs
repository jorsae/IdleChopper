namespace Model.Items
{
    public interface IItem
    {
        double GetSinglePurchaseCost();
        double GetBulkPurchaseCost(double quantity);
        double GetMaxNumberOfUpgrades(double coins);
    }
}