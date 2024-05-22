using System;
using UnityEngine;

public class CharacterStaminaSystem : MonoBehaviour
{
    private CharacterStatHandler characterStatHandler;
    [SerializeField] private StaminaSlider staminaSlider;

    // get만 구현된 것처럼 프로퍼티를 사용하는 것
    // 이렇게 하면 데이터의 복제본이 여기저기 돌아다니다가 싱크가 깨지는 문제를 막을 수 있어요!
    public float MaxStamina => characterStatHandler.currentStats.maxStamina;
    public float currentStamina {  get; private set; }

    public float staminaConsumeRate = 1f;
    public float staminaRecoveryRate = 1f;

    //private bool isConsumeStamina = false;

    //public event Action OnSprint;
    //public event Action OnSprintEnd; // TODO : 애니메이션 연결해줄 때 사용해줘야 한다.


    private void Awake()
    {
        characterStatHandler = GetComponent<CharacterStatHandler>();
        staminaSlider.SetMaxStamina(MaxStamina);
    }

    private void Start()
    {
        currentStamina = MaxStamina;
    }

    public bool ChangeStamina()
    {
        // 범위에 제한을 주기위한 구문
        currentStamina = Mathf.Clamp(currentStamina, 0, MaxStamina);

        if (currentStamina > 0.0f)
        {
            currentStamina = currentStamina - staminaConsumeRate * Time.deltaTime;
            staminaSlider.SetStamina(currentStamina);
            //isConsumeStamina = true;
            //Debug.Log(currentStamina);
        }
        return true;
    }

    public bool RecoveryStamina()
    {
        currentStamina = Mathf.Clamp(currentStamina, 0, MaxStamina);

        if (currentStamina < MaxStamina)
        {
            currentStamina += staminaRecoveryRate * Time.deltaTime;
            staminaSlider.SetStamina(currentStamina);
            //isConsumeStamina = false;
            //Debug.Log(currentStamina);
        }
        return true;
    }
}