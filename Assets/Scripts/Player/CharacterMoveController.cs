using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터의 이벤트 메소드를 관리하기 위한 스크립트
// 공통적 기능을 포함하여 재활용할 수 있도록 해줍니다.
public class CharacterMoveController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; // Action은 무조건 void만 반환해야 아니면 Func

    public event Action<bool> OnSprintEvent;

    protected bool IsSprint { get; set; }

    private void Update()
    {
            CallSprintEnvet();
    }

    public void CallSprintEnvet()
    {
        OnSprintEvent?.Invoke(IsSprint);
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. 없으면 말고 있으면 실행
    }
}
