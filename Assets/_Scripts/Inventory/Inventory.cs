using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public bool isAlive { get; private set; }

    [SerializeField] private ItemSlot shirtSlot;
    [SerializeField] private ItemSlot pantsSlot;
    [SerializeField] private ItemSlot shoesSlot;
    [SerializeField] private ItemSlot hairSlot;
    [SerializeField] private ItemSlot hatSlot;

    [SerializeField] private List<Item> items;

    public event Action<List<Item>> OnEndInitialization;
    public event Action<int, Item> OnAddItem;
    public event Action<int, Item> OnRemoveItem;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            isAlive = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddItem(Item item)
    {
        items.Add(item);
        var itemIndex = items.Count - 1;
        OnAddItem?.Invoke(itemIndex, item);
    }

    public void RemoveItem(Item item)
    {
        var itemIndex = items.IndexOf(item);
        items.Remove(item);
        OnRemoveItem?.Invoke(itemIndex, item);
    }

    public List<Item> GetInventoryItems()
    {
        return new List<Item>(items);
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

    private void OnDestroy()
    {
        isAlive = false;
    }
}