namespace Model.Upgrades
{
    public class Axe : BaseUpgrade
    {
        public Axe() : base("Axe", 10, 1)
        {
            DamageType = AttackType.ClickDamage;
        }
    }
}