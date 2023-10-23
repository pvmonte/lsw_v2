using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private EquippedSlots equippedSlots;
    
        [SerializeField] private BagUI bag;
        
        public event Action OnOpen;
        public event Action OnClose;
    
        private void OnEnable()
        {
            OnOpen?.Invoke();
        }
    
        private void Start()
        {
            Inventory.Instance.OnAddItem += Inventory_OnAddItem;
            Inventory.Instance.OnRemoveItem += Inventory_OnRemoveItem;
            Inventory.Instance.OnUpdateCoins += Inventory_OnUpdateCoins;
            Initialize();
        }

        private void Inventory_OnUpdateCoins(int coins)
        {
            coinText.text = coins + "G";
        }

        private void Inventory_OnRemoveItem(int index, Item item)
        {
            bag.SetSlotEmpty(index);
        }
    
        private void Inventory_OnAddItem(int index, Item item)
        {
            bag.FillSlot(index, item);
        }
    
        private void Initialize()
        {
            var inventoryItems = Inventory.Instance.GetInventoryItems();
            
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                bag.FillSlot(i, inventoryItems[i]);
            }
        }
    
        public void Equip()
        {
            var item = bag.SelectedSlot.fillingItem;
    
            equippedSlots.Fill(item);
            bag.SelectedSlot.Equip();
            Inventory.Instance.EquipItem(item);
        }
    
        public void Unequip(Item item)
        {
            equippedSlots.SetEmpty();
        }
    
        private void OnDisable()
        {
            OnClose?.Invoke();
        }
    }
}

