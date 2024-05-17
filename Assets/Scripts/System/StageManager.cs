using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****** 스테이지(난이도) 관리 매니저  ******/
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    private int difficulty;
    public int GetDifficulty() { return difficulty; }

    private float enemyCreateDelay;
    public float GetEnemyCreateDelay() {  return enemyCreateDelay; }


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
        difficulty = 0;
    }

    // Update is called once per frame
    void Update()
    {

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
