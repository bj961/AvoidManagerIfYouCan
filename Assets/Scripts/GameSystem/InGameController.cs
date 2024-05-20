using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/****** 인게임의 모든 동작 관리 ******/
public class InGameController : MonoBehaviour
{
    public static InGameController Instance;

    private GameObject player1;
    private GameObject player2;

    // TODO : 
    private int alivePlayers;
    private bool isPlayer1Alive;
    private bool isPlayer2Alive;
    

    // 갱신할 UI들
    public Text currentScoreText;
    public Text highScoreText;

    // TODO : 캐릭터 선택 기능 구현한다면 해당 UI 연결하여 사용할것
    // public GameObject CharacterSelectUI;


    // 경과 시간 = 점수
    private float currentTime;
    private float highScore;
    public float GetScore() { return currentTime; }
    public float GetHighScore() { return highScore; }


   


    // 게임 초기화
    void Start()
    {
        //게임 초기화
        currentTime = 0;

        // UI 연결

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
        alivePlayers = 1;
        if (GameManager.Instance.CurrentGameMode == GameMode.MultiPlayer)
        {
            player2 = Instantiate(GameManager.Instance.player2Prefab);
            alivePlayers++;
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

        // TODO : 적 생성은 StageManager에서 수행!
        // StageManager.Instance.~(); <- 필요 없음
        // 다만 나중에 문제 생기면 GameState.GameStart 인 경우에만 생성되도록 하면 될듯

    }



    public void GameOver()
    {
        // 시간 정지
        Time.timeScale = 0f;

        // 최고 점수 계산
        if (currentTime > highScore)
        {
            highScore = currentTime;
            highScoreText.text = highScore.ToString("N3");
        }
    }

    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    

    // TODO : 이벤트로 플레이어 사망시 호출되도록 구현
    public void PlayerDead()
    {
        // TODO : 부활 아이템 등을 넣을거라면 1P 2P 누가 살아있는지 체크도 해야 함
        alivePlayers--;

        if(alivePlayers == 0)
        {
            // 게임 오버
            // TODO : 게임 오버도 이벤트로 받도록 구현?
            GameManager.Instance.GameOverState();
        }
    }
}
