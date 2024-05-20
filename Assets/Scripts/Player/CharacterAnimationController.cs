using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsSprint = Animator.StringToHash("IsSprint");

    private readonly float magnituteThreshold = 0.5f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        characterMoveController.OnMoveEvent += Move;
        characterMoveController.OnSprintEvent += Sprint;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > magnituteThreshold);
    }

    private void Sprint(bool isSprint)
    {
        animator.SetBool(IsSprint, isSprint);
    }
}
