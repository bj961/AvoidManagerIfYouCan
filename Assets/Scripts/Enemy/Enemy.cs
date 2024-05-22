using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum MonsterType
{
    EnemyHyuk,
    EnemyUrock
}

public class Enemy : MonoBehaviour
{
    [SerializeField] private MonsterType monsterType;
    int EnemyCount;
    float Speed = 0.02f;
    Sprite sprite;

    void Start()
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = 3.0f;
        //Spawn point
        transform.position = new Vector2(x, y);

        GameManager.Instance.OnGameOver += DestroyObjectOnGameOver;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // -Y Speed Control
        if (monsterType == MonsterType.EnemyUrock)
        {
            Speed += Time.deltaTime * 0.05f; // 전부 변수로
        }
        transform.position += Vector3.down * Speed;
        if (transform.position.y < -7.0f) // 변수로
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver -= DestroyObjectOnGameOver;
    }

    void DestroyObjectOnGameOver()
    {
        Destroy(gameObject);
    }
}
