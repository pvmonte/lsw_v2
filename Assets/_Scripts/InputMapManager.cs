using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using InventorySystem;
using ShopSystem;
using UnityEngine.Serialization;

public class InputMapManager : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    [FormerlySerializedAs("shop")] [SerializeField] private ShopUI shopUI;
    [SerializeField] private InventoryUI inventoryUI;
    
    // Start is called before the first frame update
    void Start()
    {
        shopUI.OnOpen += Ui_OnOpen;
        shopUI.OnClose += Ui_OnClose;

        inventoryUI.OnOpen += Ui_OnOpen;
        inventoryUI.OnClose += Ui_OnClose;
    }

    private void Ui_OnOpen()
    {
        input.SwitchCurrentActionMap("UI");
    }

    private void Ui_OnClose()
    {
        input.SwitchCurrentActionMap("Player");
    }
}
