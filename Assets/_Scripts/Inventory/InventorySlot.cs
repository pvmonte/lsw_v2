using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventorySlot : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    [field: SerializeField] public Item fillingItem { get; private set; } 
    [SerializeField] private Image icon;
    [SerializeField] private GameObject equippedIcon;

    public void Fill(Item item)
    {
        fillingItem = item;
        icon.sprite = item.Icon;
        icon.color = Color.white;
    }

    public void SetEmpty()
    {
        fillingItem = null;
        icon.sprite = null;
        icon.color = Color.clear;
    }

    public void Equip()
    {
        equippedIcon.SetActive(true);
    }

    public void Unequip()
    {
        equippedIcon.SetActive(false);
    }

    public void OnSelect()
    {
        inventoryUI.SetSelected(this);
    }
}

