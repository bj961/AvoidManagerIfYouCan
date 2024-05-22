using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/****** 인게임의 모든 동작 관리 ******/
public class InGameController : MonoBehaviour
{
    public static InGameController Instance;

    private GameObject[] player;

    //private GameObject player1;
    //private GameObject player2;

    private int alivePlayers;

    // TODO : 혹시 부활 기능 구현할 거라면 사용할 필드
    // player에서 가지고 있는게 나을듯
    private bool isPlayer1Alive;
    private bool isPlayer2Alive;


    // 갱신할 UI들
    // 인스펙터에서 연결 해야함
    public Text currentScoreText;
    public Text highScoreText;
    public Text endCurrentScoreText;
    public Text endHighScoreText;

    // 경과 시간 = 점수
    private float currentTime;
    private float highScore;
    public float GetScore() { return currentTime; }
    public float GetHighScore() { return highScore; }




    // 게임 초기화
    void Start()
    {
        player = new GameObject[2];

        //게임 초기화
        currentTime = 0;
        LoadHighScore();

        // UI 연결
        currentScoreText.text = currentTime.ToString("N3");
        highScoreText.text = highScore.ToString("N3");

        if (GameManager.Instance.CurrentGameState == GameState.GameStart)
        {
            InGameStart();
        }
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameState.GameStart)
        {
            currentTime += Time.deltaTime;
            currentScoreText.text = currentTime.ToString("N3");
        }
    }

    internal void InGameStart()
    {
        // 플레이어 캐릭터 생성
        CreatePlayer();

        Debug.Log("## InGameStart() ##\nalivePlayers : " + alivePlayers);

        Time.timeScale = 1;
    }


    void CreatePlayer()
    {
        Vector3[] playerStartPosition = new Vector3[2] { new Vector3(0f, -4.2f, 0), new Vector3(1.4f, -4.2f, 0)};

        for(int i = 0; i <= (int)GameManager.Instance.CurrentGameMode; i++)
        {
            if (GameManager.Instance.playerPrefab[i] != null)
            {
                player[i] = Instantiate(GameManager.Instance.playerPrefab[i], playerStartPosition[i], Quaternion.identity);
                alivePlayers = i + 1;
                PlayerInput playerInput = player[i].GetComponent<PlayerInput>();
                playerInput.actions = GameManager.Instance.playerInputAsset[i];
            }
        }

        ////
        //Vector3 player1StartPosition = new Vector3(0f, -4.2f, 0);
        //Vector3 player2StartPosition = new Vector3(1.4f, -4.2f, 0);
        ////
        //
        //if (GameManager.Instance.player1Prefab != null)
        //{
        //    player1 = Instantiate(GameManager.Instance.player1Prefab, player1StartPosition, Quaternion.identity);
        //    alivePlayers = 1;

        //    PlayerInput player1Input = player1.GetComponent<PlayerInput>();
        //    player1Input.actions = GameManager.Instance.player1InputAsset;
        //}

        //if (GameManager.Instance.CurrentGameMode == GameMode.MultiPlayer)
        //{
        //    if (GameManager.Instance.player2Prefab != null)
        //    {
        //        player2 = Instantiate(GameManager.Instance.player2Prefab, player2StartPosition, Quaternion.identity);
        //        alivePlayers++;

        //        PlayerInput player2Input = player2.GetComponent<PlayerInput>();
        //        player2Input.actions = GameManager.Instance.player2InputAsset;
        //    }
        //}
        //
    }


    public void GameOver()
    {

        // 최고 점수 계산
        if (currentTime > highScore)
        {
            highScore = currentTime;
            highScoreText.text = highScore.ToString("N3");
        }

        endCurrentScoreText.text = currentTime.ToString("N3");
        endHighScoreText.text = highScore.ToString("N3");

        SaveHighScore();
    }


    // TODO : 이벤트로 플레이어 사망시 호출되도록 구현
    public void PlayerDead()
    {
        // TODO : 부활 아이템 등을 넣을거라면 1P 2P 누가 살아있는지 체크도 해야 함
        alivePlayers--;

        Debug.Log("PlayerDead() 호출! alivePlayers : " + alivePlayers);

        if (alivePlayers == 0)
        {
            GameManager.Instance.GameOver();
        }
    }


    public void LoadHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            float savedHighScore = PlayerPrefs.GetFloat("highScore");
            if (savedHighScore > highScore)
            {
                highScore = savedHighScore;
            }
        }
    }

    public void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            float savedHighScore = PlayerPrefs.GetFloat("highScore");
            if (savedHighScore > highScore)
            {
                return;
            }
        }

        PlayerPrefs.SetFloat("highScore", highScore);
    }
}
