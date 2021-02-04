using System.Collections.Generic;
using System.Numerics;

namespace Model.Items
{
    public class ItemController
    {
        private BigInteger _ClickDamage;
        public BigInteger ClickDamage { get => _ClickDamage; set => _ClickDamage = value; }

        private BigInteger _IdleDamage;
        public BigInteger IdleDamage { get => _IdleDamage; set => _IdleDamage = value; }


        List<BaseItem> Items = new List<BaseItem>();

        public ItemController()
        {

        }

    }
}