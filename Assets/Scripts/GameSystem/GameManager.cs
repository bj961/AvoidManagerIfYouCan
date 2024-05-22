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


/****** 게임 상태 관리 ******/
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
            DontDestroyOnLoad(gameObject);

            Application.targetFrameRate = 60;
            inGameController = FindObjectOfType<InGameController>();
        }
        else
        {
            Destroy(gameObject);
        }
    }



    void Start()
    {
        inGameController = FindObjectOfType<InGameController>();
        playerPrefab = new GameObject[2];
        playerInputAsset = new InputActionAsset[2];
        OnGameOver += GameOverState;

        CurrentGameState = GameState.Intro;
        IntroState(); 
    }


    // State : 시작 화면
    public void IntroState()
    {
        CurrentGameState = GameState.Intro;
        InitSelectedCharacter();
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


    // State : 캐릭터 선택
    public void SelectCharacterState()
    {
        //Debug.Log("#### CharacterSelect ####");

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


    // State : 난이도 선택(미구현)
    public void SelectDifficultyState()
    {
        Debug.Log("#### Difficulty Select ####");

        CurrentGameState = GameState.SelectDifficulty;

        // TODO : 난이도 선택 UI 열기
        //UIManager.Instance.SelectPopup("selectDifficultyUI");
    }


    // State : 게임 시작
    public void GameStartState()
    {
        //Debug.Log("#### GameStart ####");

        CurrentGameState = GameState.GameStart;
        UIManager.Instance.SelectPopup("playUI");
        SoundManager.Instance.PlayBGM(SoundManager.Instance.playBGM);
        inGameController.InGameStart();
    }


    // State : 게임 종료
    public void GameOverState()
    {
        //Debug.Log("#### GameOver ####");

        CurrentGameState = GameState.GameOver;
        UIManager.Instance.SelectPopup("gameOverUI");
        SoundManager.Instance.PlaySoundOnce(SoundManager.Instance.gameOverSound);
        inGameController.GameOver();
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void ResetGame()
    {
        inGameController.InitializeInGameController();
        IntroState();

        //string currentSceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentSceneName);
    }

    public void RestartGame()
    {
        inGameController.InitializeInGameController();
        GameStartState();

        //CurrentGameState = GameState.GameStart;
        //ResetGame();
    }
}
