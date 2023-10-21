using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour , IInteractable
{
    [SerializeField] private GameObject shop;
    
    public void Interact()
    {
        shop.SetActive(true);
    }
}
