using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

// 이 스크립트는 관리자 입니다.
// 플레이어의 인풋을 관리해줄 것입니다!
public class PlayerInputController : CharacterMoveController
{
    [SerializeField] private SpriteRenderer characterSpriteRenderer; // 캐릭터 스프라이트 조작

    public void OnMove(InputValue value) // InputValue value는 유저가 입력한 값을 저장
    {
        Vector2 moveInput = value.Get<Vector2>().normalized; // .normalized 무조건 길이가 범위 안으로
        CallMoveEvent(moveInput); // CharacterMoveController를 참조해 사용

        if (moveInput.x > 0)
        {
            characterSpriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            characterSpriteRenderer.flipX = true;
        }
    }

    public void OnSprint(InputValue value)
    {
        IsSprint = value.isPressed;
    }
}
