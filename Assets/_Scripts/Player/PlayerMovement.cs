using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [FormerlySerializedAs("speed")] [SerializeField] private float moveSpeed = 1f;
    
    public void Move(InputAction.CallbackContext context)
    {
        var currentSpeed = context.ReadValue<Vector2>() * moveSpeed;
        
        rb.velocity = currentSpeed * moveSpeed;
    }
}
