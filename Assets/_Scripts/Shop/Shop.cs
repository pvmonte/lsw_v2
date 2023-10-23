using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;

namespace ShopSystem
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private Transform contentArea;
        [SerializeField] private ShopSlot shopSlotPrefab;
        [SerializeField] private List<Item> items;
        
        [SerializeField] private BagUI bag;
    
        public event Action OnOpen;
        public event Action OnClose;
    
        private void OnEnable()
        {
            OnOpen?.Invoke();
        }
    
        private void Start()
        {
            for (int i = 0; i < items.Count; i++)
            {
                var shopSlot = Instantiate(shopSlotPrefab, contentArea);
                shopSlot.Initialize(this, items[i], Buy);
            }
    
            var inventoryItems = InventorySystem.Inventory.Instance.GetInventoryItems();
            
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                bag.FillSlot(i, inventoryItems[i]);
            }
            
            InventorySystem.Inventory.Instance.OnAddItem += Inventory_OnAddItem;
            InventorySystem.Inventory.Instance.OnRemoveItem += Inventory_OnRemoveItem;
        }
    
        private void Inventory_OnAddItem(int index, Item item)
        {
            bag.FillSlot(index, item);
        }
        
        private void Inventory_OnRemoveItem(int index, Item item)
        {
            bag.SetSlotEmpty(index);
        }
    
        private void Buy(Item item)
        {
            if (item.Price > InventorySystem.Inventory.Instance.Coins) return;
            if (InventorySystem.Inventory.Instance.isInventoryFull) return;
            
            InventorySystem.Inventory.Instance.SubtractCoins(item.Price);
            InventorySystem.Inventory.Instance.AddItem(item);
        }
    
        private void OnDisable()
        {
            OnClose?.Invoke();
        }
    }
}
