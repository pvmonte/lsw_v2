using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance { get; private set; }
        public bool isAlive { get; private set; }

        [SerializeField] private PlayerController player;

        [field: SerializeField] public int TotalSlot { get; private set; }
        private int slotsFilled;
        public bool isInventoryFull => slotsFilled >= TotalSlot;
        [field: SerializeField] public int Coins { get; private set; }

        [SerializeField] private Item[] items;
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
        }

        public void SubtractCoins(int amount)
        {
            Coins -= amount;
        }

        private void OnDestroy()
        {
            isAlive = false;
        }
    }
}