using System;
using UnityEngine;

namespace ShopSystem
{
    public class ShopPanel : MonoBehaviour
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
}