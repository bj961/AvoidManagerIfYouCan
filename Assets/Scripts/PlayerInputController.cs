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

    private Vector2 inputValue; // OnMove와 함께 LateUpdate에서도 사용하기 위해 CallMoveEvent로 들어가게 되는 백터 값을 전역변수로 설정

    public void OnMove(InputValue value) // InputValue value는 유저가 입력한 값을 저장
    {
        inputValue = value.Get<Vector2>().normalized; // .normalized 무조건 길이가 범위 안으로
        CallMoveEvent(inputValue); // CharacterMoveController를 참조해 사용
    }

    private void LateUpdate()
    {
        if (inputValue.x > 0)
        {
            characterSpriteRenderer.flipX = false;
        }
        else if (inputValue.x < 0)
        {
            characterSpriteRenderer.flipX = true;
        }
    }
}
