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
        var input = context.ReadValue<Vector2>();

        //This makes the player move in one axis each time and gives priority to the X axis
        if (input.x != 0) input.y = 0;
        
        var currentSpeed = input * moveSpeed;
        rb.velocity = currentSpeed * moveSpeed;
    }

    public Vector2 GetVelocity()
    {
        return rb.velocity;
    }
}
