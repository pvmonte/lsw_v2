using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace InventorySystem
{
    [RequireComponent(typeof(Button))]
    public class InventorySlot : MonoBehaviour, ISelectHandler
    {
        //TODO: Remove crossed Reference
        [SerializeField] private BagUI bagUI;
        [field: SerializeField] public Item fillingItem { get; private set; }
        [SerializeField] private Image icon;
        [SerializeField] private GameObject equippedIcon;

        public void Fill(Item item)
        {
            if (!item) return;

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
            bagUI.SetSelected(this);
        }

        public void OnSelect(BaseEventData eventData)
        {
            OnSelect();
        }
    }
}

