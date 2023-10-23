using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

namespace ShopSystem
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Item> items;
        public List<Item> Items => items;
        
        public event Action OnBuy;
    
        public void Buy(Item item)
        {
            if (Inventory.Instance.CanFinishBuyTransaction(item.Price))
            {
                items.Remove(item);
            }
            
            Inventory.Instance.Buy(item);
            
            OnBuy?.Invoke();
        }
    }
}
