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

        public bool AddItem(string itemName, int quantity)
        {
            bool gotItem = Items.TryGetValue(itemName, out BaseItem baseItem);
            if (!gotItem)
                return false;
            
            baseItem.Quantity = quantity;

            if(baseItem.GetType().BaseType == typeof(BaseClickItem))
            {
                BaseClickItem baseClickItem = (BaseClickItem)baseItem;
                BigInteger oldDamage = baseClickItem.GetClickDamage();
                baseClickItem.Quantity += quantity;
                this.ClickDamage += baseClickItem.GetClickDamage() - oldDamage;
            }
            else
            {
                BaseIdleItem baseIdleItem = (BaseIdleItem)baseItem;
                BigInteger oldDamage = baseIdleItem.GetIdleDamage();
                baseIdleItem.Quantity += quantity;
                this.IdleDamage += baseIdleItem.GetIdleDamage() - oldDamage;
            }
            return true;
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
                    BaseItem baseItem = (BaseItem)Activator.CreateInstance(t);
                    Items.Add(baseItem.Name, baseItem);
                }
            }
        }

        public void CalculateClickDamage()
        {
            List<BaseItem> baseClickItems = Items
                                                .Select(item => item.Value)
                                                .Where(i => i.GetType().BaseType == typeof(BaseClickItem))
                                                .ToList();
            
            BigInteger newClickDamage = 0;
            foreach (var item in baseClickItems)
            {
                BaseClickItem bci = (BaseClickItem)item;
                newClickDamage += bci.GetClickDamage();
            }
            ClickDamage = newClickDamage;
        }

        public void CalculateIdleDamage()
        {
            List<BaseItem> baseClickItems = Items
                                                .Select(item => item.Value)
                                                .Where(i => i.GetType().BaseType == typeof(BaseIdleItem))
                                                .ToList();

            BigInteger newIdleDamage = 0;
            foreach (var item in baseClickItems)
            {
                BaseIdleItem bci = (BaseIdleItem)item;
                newIdleDamage += bci.GetIdleDamage();
            }
            IdleDamage = newIdleDamage;
        }
    }
}