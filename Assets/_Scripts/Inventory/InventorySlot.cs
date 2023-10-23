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
        [field: SerializeField] public Item fillingItem { get; private set; }
        [SerializeField] private Image icon;
        [SerializeField] private GameObject equippedIcon;

        public event Action<InventorySlot> OnSelectEvent;

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
            OnSelectEvent?.Invoke(this);
        }

        public void OnSelect(BaseEventData eventData)
        {
            OnSelect();
        }
    }
}

