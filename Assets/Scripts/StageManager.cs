using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // 난이도 관리
    public static StageManager Instance;

    private int difficulty;
    public int GetDifficulty() { return difficulty; }


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
    }
}
