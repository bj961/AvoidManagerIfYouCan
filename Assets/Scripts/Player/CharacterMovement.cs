using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// �� ��ũ��Ʈ�� �ǹ��� �Դϴ�.
// ������ �̵��� �Ͼ �� �ֵ��� ���ٰ��Դϴ�!
public class CharacterMovement : MonoBehaviour
{
    private CharacterMoveController moveController;
    private Rigidbody2D moveRigidbody;

    // ������ ���� ���ϴ� ���갪�� �־��ֱ� ���� ����
    private Vector2 moveDirection = Vector2.zero;// �ʱⰪ

    private void Awake()
    {
        // ���� ���ӿ�����Ʈ �ȿ� ����ִ� ������Ʈ�� �������� ���̱� ������ Awake�� ����Ͽ����ϴ�.
        moveController = GetComponent<CharacterMoveController>();
        moveRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // ��Ʈ�ѷ��� ���갪�� �ִٴ� �� �˷��ֱ�
        moveController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);
    }

    // �̵��� ���� Vector2 ���� ������ ���� ����
    private void Move(Vector2 direction)
    {
        moveDirection = direction;
    }

    // �̵� �� �־��ֱ�, ������ �ٵ� �̵� �����ϱ�
    private void ApplyMovement(Vector2 direction)
    {
        direction.x = direction.x * 5.0f; // ���� ĳ������ ������ �����Ǿ� ���� �����Ƿ� �ʱⰪ 5.0f ����

        moveRigidbody.velocity = new Vector2(direction.x, moveRigidbody.velocity.y); // velocity = �ӵ�, ������ 5.0f�� ����
    }
}
