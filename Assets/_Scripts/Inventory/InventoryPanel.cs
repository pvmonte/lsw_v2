using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public event Action OnOpen;
    public event Action OnClose;
    
    private void OnEnable()
    {
        OnOpen?.Invoke();
    }
    
    private void OnDisable()
    {
        OnClose?.Invoke();
    }
}
