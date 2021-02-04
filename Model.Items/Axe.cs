namespace Model.Items
{
    public class Axe : BaseItem
    {
        public Axe() : base("Axe", 10, 1)
        {
            DamageType = AttackType.ClickDamage;
        }
    }
}