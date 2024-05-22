using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InGameController : MonoBehaviour
{
    public static InGameController Instance;

    private GameObject[] players;

    public GameObject[] GetPlayers()
    {
        return players; ;
    }

    private int alivePlayers;

    public Text currentScoreText;
    public Text highScoreText;
    public Text endCurrentScoreText;
    public Text endHighScoreText;

    private float currentTime;
    private float highScore;

    public float GetScore() { return currentTime; }
    public float GetHighScore() { return highScore; }




    void Start()
    {
        players = new GameObject[2];

        InitializeInGameController();

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

    public void InitializeInGameController()
    {
        currentTime = 0;
        LoadHighScore();
    }

    public void InGameStart()
    {
        CreatePlayer();
    }


    void CreatePlayer()
    {
        Vector3[] playerStartPosition = new Vector3[2] { new Vector3(0f, -4.2f, 0), new Vector3(1.4f, -4.2f, 0)};

        for(int i = 0; i <= (int)GameManager.Instance.CurrentGameMode; i++)
        {
            if (GameManager.Instance.playerPrefab[i] != null)
            {
                players[i] = Instantiate(GameManager.Instance.playerPrefab[i], playerStartPosition[i], Quaternion.identity);
                alivePlayers = i + 1;
                PlayerInput playerInput = players[i].GetComponent<PlayerInput>();
                playerInput.actions = GameManager.Instance.playerInputAsset[i];
            }
        }
    }


    public void GameOver()
    {
        if (currentTime > highScore)
        {
            highScore = currentTime;
            highScoreText.text = highScore.ToString("N3");
        }

        endCurrentScoreText.text = currentTime.ToString("N3");
        endHighScoreText.text = highScore.ToString("N3");

        SaveHighScore();
    }


    // 이벤트로 플레이어 사망시 호출
    public void PlayerDead()
    {
        alivePlayers--;

        Debug.Log("PlayerDead() 호출! alivePlayers : " + alivePlayers);

        if (alivePlayers <= 0)
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
