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
    [SerializeField] private Transform inventoryArea;
    [SerializeField] private InventorySlot[] inventorySlots;

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
            inventorySlots[i].Fill(inventoryItems[i]);
        }
        
        inventory.OnAddItem += Inventory_OnAddItem;
        inventory.OnRemoveItem += Inventory_OnRemoveItem;
    }

    private void Inventory_OnAddItem(int index, Item item)
    {
        inventorySlots[index].Fill(item);
    }
    
    private void Inventory_OnRemoveItem(int index, Item item)
    {
        inventorySlots[index].SetEmpty();
    }

    private void Buy(Item item)
    {
        inventory.AddItem(item);
    }
}