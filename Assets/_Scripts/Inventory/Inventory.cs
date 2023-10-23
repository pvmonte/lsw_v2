using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private PlayerController player;

        [field: SerializeField] public int TotalSlot { get; private set; }
        private int slotsFilled;
        public bool isInventoryFull => slotsFilled >= TotalSlot;
        [field: SerializeField] public int Coins { get; private set; }

        [SerializeField] private Item[] items;
        public event Action<int, Item> OnAddItem;
        public event Action<int, Item> OnRemoveItem;
        public event Action<int> OnUpdateCoins;

        private void Start()
        {
            OnUpdateCoins?.Invoke(Coins);
        }

        public void AddItem(Item item)
        {
            var firstNullSlot = Array.IndexOf(items, null);
            items[firstNullSlot] = item;
            slotsFilled++;
            OnAddItem?.Invoke(firstNullSlot, item);
        }

        public void RemoveItem(int index, Item item)
        {
            items[index] = null;
            slotsFilled--;
            OnRemoveItem?.Invoke(index, item);
        }

        public List<Item> GetInventoryItems()
        {
            return new List<Item>(items);
        }

        public void EquipItem(Item item)
        {
            player.SpawnBodyPart(item);
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
            OnUpdateCoins?.Invoke(Coins);
        }

        public void SubtractCoins(int amount)
        {
            Coins -= amount;
            OnUpdateCoins?.Invoke(Coins);
        }

        public void Buy(Item item)
        {
            SubtractCoins(item.Price);
            AddItem(item);
        }

        public bool CanFinishBuyTransaction(int price)
        {
            if (price > Coins || isInventoryFull)
            {
                return false;
            }

            return true;
        }
    }
}