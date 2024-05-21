using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Xml.Linq;


public enum GameState
{
    Intro,
    SelectCharacter,
    SelectDifficulty,
    GameStart,
    GameOver
}

public enum GameMode
{
    SinglePlayer,
    MultiPlayer
}


/****** ���� ���� ���� ******/
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public GameState CurrentGameState { get; private set; }
    public GameMode CurrentGameMode { get; private set; }

    public void SetGameMode(GameMode newGameMode)
    {
        CurrentGameMode = newGameMode;
    }


    public InGameController inGameController;

    // ĳ���� ������
    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public delegate void GameOverHandler();
    public event GameOverHandler OnGameOver;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CurrentGameState = GameState.Intro;
            CurrentGameMode = GameMode.SinglePlayer;
            //CurrentGameMode = GameMode.MultiPlayer; //�׽�Ʈ��

            OnGameOver += GameOverState;

            Application.targetFrameRate = 60;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        inGameController = FindObjectOfType<InGameController>();

        CurrentGameState = GameState.GameStart; // �׽�Ʈ�� �ӽ� �ڵ�

        // TODO : state�� �̺�Ʈ ������� �����Ѵٸ� �� �ڵ嵵 ������ ��
        if (CurrentGameState == GameState.GameStart)
        {
            GameStartState();
        }
        else if(CurrentGameState == GameState.GameOver)
        {
            GameOverState();
        }
        else
        {
            CurrentGameState = GameState.Intro;
            IntroState();
        }
    }


    // State : ���� ȭ��
    public void IntroState()
    {
        CurrentGameState = GameState.Intro;

        InitSelectedCharacter();
        StageManager.Instance.SetDifficulty(0);

        // TODO : ����ȭ�� UI ����
        //UIManager.Instance.SelectPopup("introUI");

        SoundManager.Instance.PlayBGM(SoundManager.Instance.introBGM);
    }

    void InitSelectedCharacter()
    {
        player1Prefab = null;
        player2Prefab = null;
    }


    // State : ĳ���� ����
    public void SelectCharacterState()
    {
        CurrentGameState = GameState.SelectCharacter;

        // TODO : ĳ���� ���� UI ����
        //UIManager.Instance.SelectPopup("selectUI");

        // TODO : ĳ���� ����
        // player1Prefab, player2Prefab �� ������ �Ҵ����
        // ĳ���� ���� �Ϸ�Ǹ� ���� state��
    }


    // State : ���̵� ����
    // TODO : ���̵� ���� ����� �ִ´ٸ� ������ �κ�
    public void SelectDifficultyState()
    {
        CurrentGameState = GameState.SelectDifficulty;

        // TODO : ���̵� ���� UI ����
        //UIManager.Instance.SelectPopup("selectDifficultyUI");

        // TODO : ���̵� ����
    }


    // State : ���� ����
    public void GameStartState()
    {
        CurrentGameState = GameState.GameStart;

        // TODO : ����â UI
        //UIManager.Instance.SelectPopup("playUI");

        // ���� ����
        inGameController.InGameStart();

        SoundManager.Instance.PlayBGM(SoundManager.Instance.playBGM);
    }


    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    // State : ���� ����
    public void GameOverState()
    {
        CurrentGameState = GameState.GameOver;

        SoundManager.Instance.PlaySoundOnce(SoundManager.Instance.gameOverSound);

        inGameController.GameOver();

        // TODO : ���� ���� UI ����
        //UIManager.Instance.SelectPopup("gameOverUI");
    }

    public void ResetGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void RestartGame()
    {
        CurrentGameState = GameState.GameStart;
        ResetGame();
    }
}
