using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/****** ��������(���̵�) ���� �Ŵ���  ******/
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


    void Start()
    {
        difficulty = 0;
    }

    // Update is called once per frame

    public void SetDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;


        // ���̵� ����
        // �ӽ�) ���� ���������� �Ͽ� ���̵� ���
        Time.timeScale = 1f + 0.3f * difficulty;

        //enemyCreateDelay -= 0.1f;
    }


    // �� ����
}
