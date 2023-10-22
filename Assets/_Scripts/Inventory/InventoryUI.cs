using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Inventory))]
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [SerializeField] private InventorySlot shirtSlot;
    [SerializeField] private InventorySlot pantsSlot;
    [SerializeField] private InventorySlot shoesSlot;
    [SerializeField] private InventorySlot hairSlot;
    [SerializeField] private InventorySlot hatSlot;

    [SerializeField] private InventorySlot[] bagSlot;

    [SerializeField] private InventorySlot selectedSlot;

    private void Awake()
    {
        if (!inventory)
            inventory = GetComponent<Inventory>();
        
        inventory.OnEndInitialization += InventoryOnOnEndInitialization;
    }

    private void InventoryOnOnEndInitialization(List<Item> inventoryItems)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            bagSlot[i].Fill(inventoryItems[i]);
        }
    }

    public void SetSelected(InventorySlot slot)
    {
        selectedSlot = slot;
    }

    public void Equip()
    {
        var item = selectedSlot.fillingItem;

        switch (item.Type)
        {
            case ItemType.Shirt:
                shirtSlot.Fill(item);
                break;
            case ItemType.Pants:
                pantsSlot.Fill(item);
                break;
            case ItemType.Shoes:
                shoesSlot.Fill(item);
                break;
            case ItemType.Hair:
                hairSlot.Fill(item);
                break;
            case ItemType.Hat:
                hatSlot.Fill(item);
                break;
        }

        selectedSlot.Equip();
        inventory.EquipItem(item);
    }

    public void Unequip(Item item)
    {
        selectedSlot.SetEmpty(item);
    }
}