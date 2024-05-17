using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ĳ������ �̺�Ʈ �޼ҵ带 �����ϱ� ���� ��ũ��Ʈ
// ������ ����� �����Ͽ� ��Ȱ���� �� �ֵ��� ���ݴϴ�.
public class CharacterMoveController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; // Action�� ������ void�� ��ȯ�ؾ� �ƴϸ� Func

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. ������ ���� ������ ����
    }
}
