using System;
using UnityEngine;

namespace InventorySystem
{
    public class ItemSlot : MonoBehaviour
    {
        [field: SerializeField] public ItemType Type { get; private set; }
        [SerializeField] private GameObject equipped;
        private Transform slotTransform;

        private void Awake()
        {
            slotTransform = transform;
        }

        public void Equip(Item item)
        {
            if (equipped != null)
            {
                Destroy(equipped.gameObject);
            }
        
            equipped = Instantiate(item.Prefab, slotTransform);
        }
    }    
}
