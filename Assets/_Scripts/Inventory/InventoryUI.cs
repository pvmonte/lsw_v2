using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Inventory))]
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [SerializeField] private EquippedSlots equippedSlots;

    [SerializeField] private BagUI bag;

    private void Awake()
    {
        if (!inventory)
            inventory = GetComponent<Inventory>();
        
        inventory.OnEndInitialization += Inventory_OnEndInitialization;
        inventory.OnAddItem += Inventory_OnAddItem;
        inventory.OnRemoveItem += Inventory_OnRemoveItem;
    }

    private void Inventory_OnRemoveItem(int index, Item item)
    {
        bag.SetSlotEmpty(index);
    }

    private void Inventory_OnAddItem(int index, Item item)
    {
        bag.FillSlot(index, item);
    }

    private void Inventory_OnEndInitialization(List<Item> inventoryItems)
    {
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
        inventory.EquipItem(item);
    }

    public void Unequip(Item item)
    {
        equippedSlots.SetEmpty();
    }
}