using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private Shop shopController;
    [SerializeField] private Item slotItem;
    [SerializeField] private Image slotIcon;
    [SerializeField] private TextMeshProUGUI priceTMP;
    [SerializeField] private Button buyButton;
    
    public event Action<Item> OnBuyClick; 

    public void Initialize(Shop shop, Item item, Action<Item> buyAction)
    {
        shopController = shop;
        slotItem = item;
        slotIcon.sprite = item.Icon;
        priceTMP.text = item.Price.ToString();
        OnBuyClick += buyAction;
        
        buyButton.onClick.AddListener(() => OnBuyClick?.Invoke(slotItem));
    }
}