using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    private static readonly int IsSprint = Animator.StringToHash("IsSprint");

    private readonly float magnituteThreshold = 0.5f; // 너무 조금 움직였을 때는 멈춘 상태로 처리하기 위한 변수

    private CharacterHealtSystem characterHealtSystem;

    protected override void Awake()
    {
        base.Awake();
        characterHealtSystem = GetComponent<CharacterHealtSystem>();
    }

    private void Start()
    {
        characterMoveController.OnMoveEvent += Move;
        characterMoveController.OnSprintEvent += Sprint;

        if(characterHealtSystem != null)
        {
            characterHealtSystem.OnDamage += Hit;
            characterHealtSystem.OnInvinsibilityEnd += InvinsibilityEnd;
        }
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > magnituteThreshold);
    }

    private void Sprint(bool isSprint)
    {
        animator.SetBool(IsSprint, isSprint);
    }

    //TODO : 플레이어 캐릭터 애니메이션 연결해주기 아직 미연결
    private void Hit()
    {
        //animator.SetBool(IsHit, true);
    }

    private void InvinsibilityEnd()
    {
        //animator.SetBool(IsHit, false);
    }

}
