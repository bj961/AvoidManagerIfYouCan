using UnityEngine;

public enum StatsChangeType
{
    Add, // 0 예)공격력  +50
    Multiple, // 1 예) 공격력 50% 증가
    Override // 2 예) 공격력을 999로 만들기
}

// 데이터 폴더처럼 사용할 수 있게 만들어주는 Attribute, 데이터 컨테이너
[System.Serializable]
public class CharacterStat
{
    public StatsChangeType statsChangeType;
    [Range(0, 10)] public int maxHealth;
    [Range(0, 10)] public float maxStamina;
    [Range(0, 15)] public float speed;
}
