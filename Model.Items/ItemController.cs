using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace Model.Items
{
    public class ItemController
    {
        private BigInteger _ClickDamage;
        public BigInteger ClickDamage { get => _ClickDamage; set => _ClickDamage = value; }

        private BigInteger _IdleDamage;
        public BigInteger IdleDamage { get => _IdleDamage; set => _IdleDamage = value; }


        public Dictionary<string, BaseItem> Items = new Dictionary<string, BaseItem>();

        public ItemController()
        {
            this.FillItems();
        }

        private void FillItems()
        {
            Type tClick = typeof(BaseClickItem);
            Type tIdle = typeof(BaseIdleItem);

            List<Type> types = Assembly.GetExecutingAssembly().GetTypes()
                                    .Where(t => t.Namespace == "Model.Items")
                                    .ToList();
            foreach(Type t in types)
            {
                if (t.BaseType == tClick ||
                    t.BaseType == tIdle)
                {
                    BaseItem o = (BaseItem)Activator.CreateInstance(t);
                    Items.Add(o.Name, o);
                }
            }
        }
    }
}