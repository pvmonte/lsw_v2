using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMapManager : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    [SerializeField] private Shop shop;
    [SerializeField] private InventoryUI inventoryUI;
    
    // Start is called before the first frame update
    void Start()
    {
        shop.OnOpen += Ui_OnOpen;
        shop.OnClose += Ui_OnClose;

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
