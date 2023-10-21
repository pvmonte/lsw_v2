using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    private IInteractable interactable;
    
    public void Interact(InputAction.CallbackContext context)
    {
        if(!context.performed || interactable == null)
        {
            return;
        }
        
        interactable.Interact();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.TryGetComponent<IInteractable>(out interactable);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactable = null;
    }
}