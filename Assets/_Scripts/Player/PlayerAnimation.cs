using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator body;

    [SerializeField] private List<Animator> parts;
    private static readonly int Horizontal = Animator.StringToHash("horizontal");
    private static readonly int Vertical = Animator.StringToHash("vertical");

    public void SetAnimation(string state)
    {
        body.Play(state);

        foreach (var part in parts)
        {
            part.Play(state);
        }
    }

    public void SetParameters(Vector2 movement)
    {
        body.SetFloat(Horizontal, movement.x);
        body.SetFloat(Vertical, movement.y);
            
        foreach (var part in parts)
        {
            part.SetFloat(Horizontal, movement.x);
            part.SetFloat(Vertical, movement.y);
        }
    }

    public void AddPart(Animator itemAnimator)
    {
        parts.Add(itemAnimator);
    }
}