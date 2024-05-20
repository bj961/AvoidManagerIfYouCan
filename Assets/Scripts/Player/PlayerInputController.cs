using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

// �� ��ũ��Ʈ�� ������ �Դϴ�.
// �÷��̾��� ��ǲ�� �������� ���Դϴ�!
public class PlayerInputController : CharacterMoveController
{
    [SerializeField] private SpriteRenderer characterSpriteRenderer; // ĳ���� ��������Ʈ ����

    private Vector2 inputValue; // OnMove�� �Բ� LateUpdate������ ����ϱ� ���� CallMoveEvent�� ���� �Ǵ� ���� ���� ���������� ����

    public void OnMove(InputValue value) // InputValue value�� ������ �Է��� ���� ����
    {
        inputValue = value.Get<Vector2>().normalized; // .normalized ������ ���̰� ���� ������
        CallMoveEvent(inputValue); // CharacterMoveController�� ������ ���
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
