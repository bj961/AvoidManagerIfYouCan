using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/****** �ΰ����� ��� ���� ���� ******/
public class InGameController : MonoBehaviour
{
    public static InGameController Instance;

    private GameObject player1;
    private GameObject player2;
    private int alivePlayer;

    // �� ������
    public List<GameObject> enemyPrefabList; // �� ���� ���� ��
    public GameObject enemy; // �׽�Ʈ��.. ���� �� ����Ʈ ����� �ڵ�� ����

    // ������ UI��
    public Text currentScoreText;
    public Text highScoreText;


    // ��� �ð� = ����
    private float currentTime;
    private float highScore;
    public float GetScore() { return currentTime; }
    public float GetHighScore() { return highScore; }


    // ���̵� ����
    private float enemyCreateDelay; // �ӽ�.. ���߿� StageManager�� �ű� ����
    //private float difficultyIncreaseInterval = 60f;



    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
            
        }
    }

    


    // ���� �ʱ�ȭ
    void Start()
    {
        //���� �ʱ�ȭ
        currentTime = 0;
        enemyCreateDelay = 1f;
        currentScoreText.text = currentTime.ToString("N3");
        highScoreText.text = highScore.ToString("N3");

        if(GameManager.Instance.CurrentGameState == GameState.GameStart)
        {
            InGameStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameState.GameStart)
        {
            currentTime += Time.deltaTime;
            currentScoreText.text = currentTime.ToString("N3");
        }
    }


    /** IntroState : ������ ��� ���¸� �ʱ�ȭ�Ͽ� �� ���� ���� ������� **/


    void CreatePlayer()
    {
        player1 = Instantiate(GameManager.Instance.player1Prefab);
        alivePlayer = 1;
        if (GameManager.Instance.CurrentGameMode == GameMode.MultiPlayer)
        {
            player2 = Instantiate(GameManager.Instance.player2Prefab);
            alivePlayer++;
        }
    }


    /** SelectCharacterState : ĳ���� ���� **/
    /** SelectDifficultyState : ���̵� ���� **/
    // �� �� state�� GameManger���� ����


    /** GameStartState : ���� ���� �� ���� **/

    internal void InGameStart()
    {
        // �÷��̾� ĳ���� ����
        CreatePlayer();

        Time.timeScale = 1;

        // �� ����
        InvokeRepeating("CreateEnemys", 0f, enemyCreateDelay);
    }


    // �� ������Ʈ ����
    public void CreateEnemys()
    {
        Instantiate(enemy);
    }

    // Player�� �� ������Ʈ�� �浹�� ���(=���� ����) �� �Լ� ȣ�������
    public void GameOver()
    {
        // �ð� ����
        Time.timeScale = 0f;

        // �ְ� ���� ���
        if (currentTime > highScore)
        {
            highScore = currentTime;
        }
    }

    
}
