namespace Model.Upgrades
{
    public interface IUpgrade
    {
        double GetSinglePurchaseCost();
        double GetBulkPurchaseCost(double quantity);
        double GetMaxNumberOfUpgrades(double coins);
    }
}