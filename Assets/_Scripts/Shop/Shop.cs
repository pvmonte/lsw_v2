using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Transform contentArea;
    [SerializeField] private ShopSlot shopSlotPrefab;
    [SerializeField] private List<Item> items;
    
    [SerializeField] private Inventory inventory;
    [SerializeField] private BagUI bag;
    [SerializeField] private Transform inventoryArea;

    private void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            var shopSlot = Instantiate(shopSlotPrefab, contentArea);
            shopSlot.Initialize(this, items[i], Buy);
        }

        var inventoryItems = inventory.GetInventoryItems();
        
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            bag.FillSlot(i, inventoryItems[i]);
        }
        
        inventory.OnAddItem += Inventory_OnAddItem;
        inventory.OnRemoveItem += Inventory_OnRemoveItem;
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
        inventory.AddItem(item);
    }
}