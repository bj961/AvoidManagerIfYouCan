using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/****** 스테이지(난이도) 관리 매니저  ******/
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

    public void SetDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;


        //난이도 세팅
        // 임시) 게임 빨라지도록 하여 난이도 상승
        Time.timeScale = 1f + 0.3f * difficulty;

    }
}
