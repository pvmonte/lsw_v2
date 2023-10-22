using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemSlot shirtSlot;
    [SerializeField] private ItemSlot pantsSlot;
    [SerializeField] private ItemSlot shoesSlot;
    [SerializeField] private ItemSlot hairSlot;
    [SerializeField] private ItemSlot hatSlot;
    
    [SerializeField] private List<Item> items;

    public event Action<List<Item>> OnEndInitialization;

    private void Start()
    {
        OnEndInitialization?.Invoke(items);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }
    
    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void EquipItem(Item item)
    {
        switch (item.Type)
        {
            case ItemType.Shirt:
                shirtSlot.Equip(item);
                break;
            case ItemType.Pants:
                pantsSlot.Equip(item);
                break;
            case ItemType.Shoes:
                shoesSlot.Equip(item);
                break;
            case ItemType.Hair:
                hairSlot.Equip(item);
                break;
            case ItemType.Hat:
                hatSlot.Equip(item);
                break;
        }
    }
}

[System.Serializable]
public class ItemSlot
{
    [SerializeField] private GameObject equipped;
    [SerializeField] private Transform slotTransform;

    public void Equip(Item item)
    {
        if (equipped != null)
        {
            GameObject.Destroy(equipped.gameObject);
        }
        
        GameObject.Instantiate(item, slotTransform);
    }
}