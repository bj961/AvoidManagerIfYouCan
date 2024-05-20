using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    // 기본 스탯과 버프 스탯들의 능력치를 종합해서 스탯을 계산하는 컴포넌트
    [SerializeField] private CharacterStat baseStats;
    public CharacterStat currentStats { get; private set; }
    public List<CharacterStat> statModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        currentStats = new CharacterStat();
        // TODO : 지금은 기본 능력치만 적용, 나중에 능력치 강화 추가 할 수 있음
        currentStats.statsChangeType = baseStats.statsChangeType;
        currentStats.maxHealth = baseStats.maxHealth;
        currentStats.speed = baseStats.speed;
        currentStats.maxStamina = baseStats.maxStamina;
    }
}