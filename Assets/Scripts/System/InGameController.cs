using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/****** 인게임의 모든 동작 관리 ******/
public class InGameController : MonoBehaviour
{
    public static InGameController Instance;

    private GameObject player1;
    private GameObject player2;
    private int alivePlayer;

    // 적 프리팹
    public List<GameObject> enemyPrefabList; // 적 종류 여러 개
    public GameObject enemy; // 테스트용.. 추후 위 리스트 사용한 코드로 수정

    // 갱신할 UI들
    public Text currentScoreText;
    public Text highScoreText;


    // 경과 시간 = 점수
    private float currentTime;
    private float highScore;
    public float GetScore() { return currentTime; }
    public float GetHighScore() { return highScore; }


    // 난이도 관련
    private float enemyCreateDelay; // 임시.. 나중에 StageManager로 옮길 예정
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

    


    // 게임 초기화
    void Start()
    {
        //게임 초기화
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


    /** IntroState : 게임의 모든 상태를 초기화하여 새 게임 시작 가능토록 **/


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


    /** SelectCharacterState : 캐릭터 선택 **/
    /** SelectDifficultyState : 난이도 선택 **/
    // 위 두 state는 GameManger에서 관리


    /** GameStartState : 게임 시작 후 로직 **/

    internal void InGameStart()
    {
        // 플레이어 캐릭터 생성
        CreatePlayer();

        Time.timeScale = 1;

        // 적 생성
        InvokeRepeating("CreateEnemys", 0f, enemyCreateDelay);
    }


    // 적 오브젝트 생성
    public void CreateEnemys()
    {
        Instantiate(enemy);
    }

    // Player가 적 오브젝트와 충돌할 경우(=게임 오버) 이 함수 호출토록함
    public void GameOver()
    {
        // 시간 정지
        Time.timeScale = 0f;

        // 최고 점수 계산
        if (currentTime > highScore)
        {
            highScore = currentTime;
        }
    }

    
}
