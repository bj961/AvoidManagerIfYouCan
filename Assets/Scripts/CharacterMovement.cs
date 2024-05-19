using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// 이 스크립트는 실무자 입니다.
// 실제로 이동이 일어날 수 있도록 해줄것입니다!
public class CharacterMovement : MonoBehaviour
{
    private CharacterMoveController moveController;
    private Rigidbody2D moveRigidbody;

    private CharacterStatHandler characterStatHandler;

    private CharacterStaminaSystem characterStaminaSystem;

    // 물리에 의해 변하는 무브값을 넣어주기 위한 변수
    private Vector2 moveDirection = Vector2.zero;// 초기값

    private void Awake()
    {
        // 같은 게임오브젝트 안에 들어있는 컴포넌트를 가져오는 것이기 때문에 Awake에 사용하였습니다.
        moveController = GetComponent<CharacterMoveController>();
        moveRigidbody = GetComponent<Rigidbody2D>();

        characterStatHandler = GetComponent<CharacterStatHandler>();
        characterStaminaSystem = GetComponent<CharacterStaminaSystem>();
    }

    private void Start()
    {
        // 컨트롤러에 무브값이 있다는 걸 알려주기
        moveController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);
    }

    private void Update()
    {
        characterStaminaSystem.RecoveryStamina();
    }

    // 이동에 대한 Vector2 값이 들어오면 값을 저장
    private void Move(Vector2 direction)
    {
        moveDirection = direction;
    }

    // 이동 값 넣어주기, 리지드 바디에 이동 적용하기
    private void ApplyMovement(Vector2 direction)
    {
        direction.x = direction.x * characterStatHandler.currentStats.speed; // 캐릭터의 설정된 스피드를 받아오도록 수정
        moveRigidbody.velocity = new Vector2(direction.x, moveRigidbody.velocity.y); // velocity = 속도, 위에서 5.0f로 설정

        float nolmalSpeed = direction.x;
        float sprintSpeed = direction.x * 2.5f;
        
        // 유저가 아래 버튼을 눌렀고 x값에 변화가 있을 때
        if(direction.y < 0 && direction.x != 0)
        {
            if (characterStaminaSystem.ChangeStamina() && characterStaminaSystem.currentStamina > 0.0f)
            {
                moveRigidbody.velocity = new Vector2(sprintSpeed, moveRigidbody.velocity.y);
                Debug.Log("스프린트 상태");
            }
            
            if(characterStaminaSystem.currentStamina < 0.1f)
            {
                //characterStaminaSystem.RecoveryStamina();
                moveRigidbody.velocity = new Vector2(nolmalSpeed, moveRigidbody.velocity.y);
                Debug.Log("스프린트 종료");
            }
                
        }
    }
}
