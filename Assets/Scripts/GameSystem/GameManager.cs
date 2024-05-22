using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Xml.Linq;
using UnityEngine.InputSystem;


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

    public InGameController inGameController;

    public GameState CurrentGameState { get; private set; }
    public GameMode CurrentGameMode { get; set; }

    
    public void SetGameMode(GameMode newGameMode)
    {
        CurrentGameMode = newGameMode;
    }

    public GameObject[] playerPrefab;
    public InputActionAsset[] playerInputAsset;

    public delegate void GameOverHandler();
    public event GameOverHandler OnGameOver;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CurrentGameState = GameState.Intro;

            OnGameOver += GameOverState;

            Application.targetFrameRate = 60;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeGameManager();
    }


    void InitializeGameManager()
    {
        Debug.Log("## GameManager Start() ##\n" + CurrentGameState.ToString());

        inGameController = FindObjectOfType<InGameController>();

        InitSelectedCharacter();
        
        // TODO : state�� �̺�Ʈ ������� �����Ѵٸ� �� �ڵ嵵 ������ ��
        if (CurrentGameState == GameState.Intro)
        {
            IntroState();
        }
        if (CurrentGameState == GameState.GameStart)
        {
            GameStartState();
        }
        else
        {
            CurrentGameState = GameState.Intro;
            IntroState();
        }
    }

    void Start()
    {
        playerPrefab = new GameObject[2];
        playerInputAsset = new InputActionAsset[2];
    }


    // State : ���� ȭ��
    public void IntroState()
    {
        CurrentGameState = GameState.Intro;

        
        //StageManager.Instance.SetDifficulty(0);

        UIManager.Instance.SelectPopup("introUI");

        SoundManager.Instance.PlayBGM(SoundManager.Instance.introBGM);
    }

    void InitSelectedCharacter()
    {
        for(int i=0;i<playerPrefab.Length;i++)
        {
            playerPrefab[i] = null;
        }
    }


    // State : ĳ���� ����
    public void SelectCharacterState()
    {
        Debug.Log("#### CharacterSelect ####");

        CurrentGameState = GameState.SelectCharacter;

        switch (CurrentGameMode)
        {
            case GameMode.SinglePlayer:
                UIManager.Instance.SelectPopup("singleCharSelectUI");
                break;
            case GameMode.MultiPlayer:
                UIManager.Instance.SelectPopup("multiCharSelectUI");
                break;
        } 
    }


    // State : ���̵� ����
    public void SelectDifficultyState()
    {
        Debug.Log("#### Difficulty Select ####");

        CurrentGameState = GameState.SelectDifficulty;

        // TODO : ���̵� ���� UI ����
        //UIManager.Instance.SelectPopup("selectDifficultyUI");
    }


    // State : ���� ����
    public void GameStartState()
    {
        Debug.Log("#### GameStart ####");

        CurrentGameState = GameState.GameStart;

        // TODO : ����â UI
        UIManager.Instance.SelectPopup("playUI");

        // ���� ����
        inGameController.InGameStart();

        SoundManager.Instance.PlayBGM(SoundManager.Instance.playBGM);
    }


    // State : ���� ����
    public void GameOverState()
    {
        Debug.Log("#### GameOver ####");

        CurrentGameState = GameState.GameOver;

        SoundManager.Instance.PlaySoundOnce(SoundManager.Instance.gameOverSound);

        inGameController.GameOver();

        // TODO : ���� ���� UI ����
        UIManager.Instance.SelectPopup("gameOverUI");
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void ResetGame()
    {
        Debug.Log("�� �ٽ� �ε�");
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void RestartGame()
    {
        Debug.Log("���� �ٽ� ����");
        CurrentGameState = GameState.GameStart;
        ResetGame();
    }
}
