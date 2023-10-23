using System;
using UnityEditor;
using UnityEngine;

namespace InventorySystem
{
    public class BagUI : MonoBehaviour
    {
        //TODO: Remove crossed Reference
        [SerializeField] private InventorySlot[] bagSlots;

        //TODO: Remove serialization
        [field: SerializeField] public InventorySlot SelectedSlot { get; private set; }

        private void Start()
        {
            Inventory.Instance.OnAddItem += Instance_OnAddItem;
            Inventory.Instance.OnRemoveItem += Inventory_OnRemoveItem;
        }

        private void Instance_OnAddItem(int index, Item item)
        {
            bagSlots[index].Fill(item);
        }

        private void Inventory_OnRemoveItem(int index, Item item)
        {
            SetSlotEmpty(index);
        }

        public void FillSlot(int index, Item item)
        {
            bagSlots[index].Fill(item);
        }

        public void SetSlotEmpty(int index)
        {
            bagSlots[index].SetEmpty();
        }

        public void SetSelected(InventorySlot slot)
        {
            SelectedSlot = slot;
        }

        public void Sell()
        {
            if (!SelectedSlot.fillingItem) return;

            var slotIndex = Array.IndexOf(bagSlots, SelectedSlot);

            Inventory.Instance.AddCoins(SelectedSlot.fillingItem.Price);
            Inventory.Instance.RemoveItem(slotIndex, SelectedSlot.fillingItem);
        }

        private void OnDestroy()
        {
            if (Inventory.Instance.isAlive)
            {
                Inventory.Instance.OnAddItem -= Instance_OnAddItem;
                Inventory.Instance.OnRemoveItem -= Inventory_OnRemoveItem;
            }
        }
    }
}