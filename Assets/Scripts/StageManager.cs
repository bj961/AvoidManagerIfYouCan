using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****** 스테이지(난이도) 관리 매니저  ******/
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    private int difficulty;
    [SerializeField] private GameObject Enemy;
    
    int level = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeEnemy", 0f, 1f);
        difficulty = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MakeEnemy()
    {
        Instantiate(Enemy);

        if (level == 0)
        {
            int p = Random.Range(0, 10);
            if (p < 2) Instantiate(Enemy);
        }
        else if(level == 1)
        {
            int p = Random.Range(0, 10);
            if (p < 2) Instantiate(Enemy);
        }
    }

    public void SetDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;


        // 난이도 세팅
        // 임시) 게임 빨라지도록 하여 난이도 상승
        Time.timeScale = 1f + 0.3f * difficulty;

        //enemyCreateDelay -= 0.1f;
    }
}
