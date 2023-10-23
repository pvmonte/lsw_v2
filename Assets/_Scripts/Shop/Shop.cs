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
            if (!inventory.CanFinishBuyTransaction(item.Price))
            {
                return;
            }

            //The shop should remove the item after buy, but we have few items, so I decided to keep it
            //items.Remove(item);
            inventory.Buy(item);

            OnBuy?.Invoke();
        }
    }
}