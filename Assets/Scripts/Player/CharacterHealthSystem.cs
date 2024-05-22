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
    public event Action OnHeal; // 아직 회복될지말지 미정
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
                OnInvinsibilityEnd?.Invoke(); // 있으면 실행
                isBump = false;
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        // 무적 시간에는 체력 닳지 않게
        if (timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0;
        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        Debug.Log("충돌 " + CurrentHealth);
        healthBar.SetHealth(CurrentHealth);

        if (CurrentHealth <= 0.0f)
        {
            CallDeath();
            return true;
        }

        if (change >= 0)
        {
            OnHeal?.Invoke(); // 아직 회복될지말지 미정 존재 없음
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
