using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/****** ��������(���̵�) ���� �Ŵ���  ******/
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    private int difficulty;
    [SerializeField] private GameObject[] EnemySpawn;
    float SpawnTime = 0;
    float EnemySpawnTime = 1f;


    private void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameState.GameStart)
        {
            MakeEnemy();
        }
    }

    // Update is called once per frame

    void MakeEnemy()
    {
        int p = Random.Range(0, 10);

        if (SpawnTime < EnemySpawnTime)
        {
            SpawnTime += Time.deltaTime;
            //Debug.Log(SpawnTime);
        }
        else if (SpawnTime >= EnemySpawnTime)
        {
            Instantiate(EnemySpawn[0]);
            if (p < 1) Instantiate(EnemySpawn[1]);
            SpawnTime = 0;
        }
    }
}
