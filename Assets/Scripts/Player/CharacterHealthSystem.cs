using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CharacterHealtSystem : MonoBehaviour
{
    private CharacterStatHandler characterStatHandler;
    [SerializeField] private HPBar healthBar;

    [SerializeField] private float healthChangeDelay = 0.5f;
    private float timeSinceLastChange = float.MaxValue;

    private bool isBump = false;

    public event Action OnDamage;
    public event Action OnHeal; // ���� ȸ���������� ����
    public event Action OnDeath;
    public event Action OnInvinsibilityEnd;

    public float CurrentHealth { get; private set; }

    public float MaxHealth => characterStatHandler.currentStats.maxHealth;

    private void Awake()
    {
        characterStatHandler = GetComponent<CharacterStatHandler>();
    }
    private void Start()
    {
        CurrentHealth = characterStatHandler.currentStats.maxHealth;
        if (gameObject == GameManager.Instance.inGameController.GetPlayers()[0])
        {
            healthBar = GameObject.Find("HPBar1").GetComponent<HPBar>();
        }
        else if (gameObject == GameManager.Instance.inGameController.GetPlayers()[1])
        {
            healthBar = GameObject.Find("HPBar2").GetComponent<HPBar>();
        }
        healthBar.SetMaxHealth(CurrentHealth);
    }

    private void Update()
    {
        if (isBump && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                OnInvinsibilityEnd?.Invoke(); // ������ ����
                isBump = false;
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        // ���� �ð����� ü�� ���� �ʰ�
        if (timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0;
        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        Debug.Log("�浹 " + CurrentHealth);
        healthBar.SetHealth(CurrentHealth);

        if (CurrentHealth <= 0.0f)
        {
            CallDeath();
            return true;
        }

        if (change >= 0)
        {
            OnHeal?.Invoke(); // ���� ȸ���������� ���� ���� ����
        }
        else
        {
            OnDamage?.Invoke();
            isBump = true;
        }

        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
