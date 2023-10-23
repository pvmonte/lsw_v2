using System;
using UnityEngine;
using InventorySystem;

namespace ShopSystem
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private Shop shop;
        [SerializeField] private Transform contentArea;
        [SerializeField] private ShopSlot shopSlotPrefab;
        
        [SerializeField] private BagUI bag;
        
        public event Action OnOpen;
        public event Action OnClose;
        
        private void OnEnable()
        {
            OnOpen?.Invoke();
        }
        
        private void Start()
        {
            for (int i = 0; i < shop.Items.Count; i++)
            {
                var shopSlot = Instantiate(shopSlotPrefab, contentArea);
                shopSlot.Initialize(shop, shop.Items[i], Buy);
            }
    
            var inventoryItems = InventorySystem.Inventory.Instance.GetInventoryItems();
            
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                bag.FillSlot(i, inventoryItems[i]);
            }
            
            Inventory.Instance.OnAddItem += Inventory_OnAddItem;
            Inventory.Instance.OnRemoveItem += Inventory_OnRemoveItem;
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
            
            Inventory.Instance.Buy(item);
        }
        
        private void OnDisable()
        {
            OnClose?.Invoke();
        }
    }
}