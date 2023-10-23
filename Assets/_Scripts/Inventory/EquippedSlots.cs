using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class EquippedSlots : MonoBehaviour
    {
        [SerializeField] private InventorySlot shirtSlot;
        [SerializeField] private InventorySlot pantsSlot;
        [SerializeField] private InventorySlot shoesSlot;
        [SerializeField] private InventorySlot hairSlot;
        [SerializeField] private InventorySlot hatSlot;

        private Dictionary<ItemType, InventorySlot> slots;

        private void Start()
        {
            slots = new Dictionary<ItemType, InventorySlot>()
            {
                { ItemType.Shirt, shirtSlot },
                { ItemType.Pants, pantsSlot },
                { ItemType.Shoes, shoesSlot },
                { ItemType.Hair, hairSlot },
                { ItemType.Hat, hatSlot }
            };
        }

        public void Fill(Item item)
        {
            slots[item.Type].Fill(item);
        }

        public void SetEmpty()
        {
            throw new NotImplementedException();
        }
    }
}