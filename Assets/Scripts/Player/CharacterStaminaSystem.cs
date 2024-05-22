using System;
using UnityEngine;

public class CharacterStaminaSystem : MonoBehaviour
{
    private CharacterStatHandler characterStatHandler;
    [SerializeField] private SPBar staminaBar;

    // get�� ������ ��ó�� ������Ƽ�� ����ϴ� ��
    // �̷��� �ϸ� �������� �������� �������� ���ƴٴϴٰ� ��ũ�� ������ ������ ���� �� �־��!
    public float MaxStamina => characterStatHandler.currentStats.maxStamina;
    public float currentStamina {  get; private set; }

    public float staminaConsumeRate = 1f;
    public float staminaRecoveryRate = 1f;

    //private bool isConsumeStamina = false;

    //public event Action OnSprint;
    //public event Action OnSprintEnd; // TODO : �ִϸ��̼� �������� �� �������� �Ѵ�.

    bool isPlayer1 = false; // hp�� ui�� 1���ۿ� ���� �ȵǾ� �����Ƿ�


    private void Awake()
    {
        characterStatHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        currentStamina = MaxStamina;

        if (gameObject == GameManager.Instance.inGameController.GetPlayers()[0])
        {
            isPlayer1 = true;
        }

        if (isPlayer1)
        {
            staminaBar = GameObject.Find("StaminaBar").GetComponent<SPBar>();
            staminaBar.SetMaxStamina(currentStamina);
        }

        
    }

    public bool ChangeStamina()
    {
        // ������ ������ �ֱ����� ����
        currentStamina = Mathf.Clamp(currentStamina, 0, MaxStamina);

        if (currentStamina > 0.0f)
        {
            currentStamina = currentStamina - staminaConsumeRate * Time.deltaTime;
            //isConsumeStamina = true;
            //Debug.Log(currentStamina);
            if (isPlayer1)
            {
                staminaBar.SetStamina(currentStamina);
            }
        }
        return true;
    }

    public bool RecoveryStamina()
    {
        currentStamina = Mathf.Clamp(currentStamina, 0, MaxStamina);

        if (currentStamina < MaxStamina)
        {
            currentStamina += staminaRecoveryRate * Time.deltaTime;
            //isConsumeStamina = false;
            //Debug.Log(currentStamina);
            if (isPlayer1)
            {
                staminaBar.SetStamina(currentStamina);
            }
        }
        return true;
    }
}