using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ItemSlot[] slots;
    
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerAnimation animation;

    [SerializeField] private Transform[] bodyParts;

    private void Update()
    {
        var direction = movement.GetVelocity().normalized;
        animation.SetParameters(direction);
    }

    public void SpawnBodyPart(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(item.Type != slots[i].Type) continue;
            
            var go = slots[i].Equip(item);
            animation.AddPart(go.GetComponent<Animator>());
            break;
        }
    }
}
