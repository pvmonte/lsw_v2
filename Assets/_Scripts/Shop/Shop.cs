using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

namespace ShopSystem
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private List<Item> items;
        public List<Item> Items => items;
        
        public event Action OnBuy;
    
        public void Buy(Item item)
        {
            if (inventory.CanFinishBuyTransaction(item.Price))
            {
                items.Remove(item);
            }
            
            inventory.Buy(item);
            
            OnBuy?.Invoke();
        }
    }
}
