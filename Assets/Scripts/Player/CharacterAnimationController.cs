using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private readonly float magnituteThreshold = 0.5f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        characterMoveController.OnMoveEvent += Move;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > magnituteThreshold);
    }
}
