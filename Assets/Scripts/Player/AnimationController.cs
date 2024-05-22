using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected CharacterMoveController characterMoveController;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterMoveController = GetComponent<CharacterMoveController>();
    }
}
