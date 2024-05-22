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


/****** 게임 상태 관리 ******/
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public GameState CurrentGameState { get; private set; }
    public GameMode CurrentGameMode { get; set; }

    public void SetGameMode(GameMode newGameMode)
    {
        CurrentGameMode = newGameMode;
    }


    public InGameController inGameController;

    // 캐릭터 프리팹
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
            //CurrentGameMode = GameMode.MultiPlayer; //테스트용

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

        // TODO : state를 이벤트 기반으로 변경한다면 이 코드도 수정할 것
        if(CurrentGameState == GameState.Intro)
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


    // State : 시작 화면
    public void IntroState()
    {
        CurrentGameState = GameState.Intro;

        // 테스트 위해 잠시 꺼둠
        //InitSelectedCharacter();
        //StageManager.Instance.SetDifficulty(0);

        UIManager.Instance.SelectPopup("introUI");

        SoundManager.Instance.PlayBGM(SoundManager.Instance.introBGM);
    }

    void InitSelectedCharacter()
    {
        player1Prefab = null;
        player2Prefab = null;
    }


    // State : 캐릭터 선택
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


    // State : 난이도 선택
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
        Debug.Log("#### GameStart ####");

        CurrentGameState = GameState.GameStart;

        // TODO : 시작창 UI
        UIManager.Instance.SelectPopup("playUI");

        // 게임 시작
        inGameController.InGameStart();

        SoundManager.Instance.PlayBGM(SoundManager.Instance.playBGM);
    }


    // State : 게임 종료
    public void GameOverState()
    {
        Debug.Log("#### GameOver ####");

        CurrentGameState = GameState.GameOver;

        SoundManager.Instance.PlaySoundOnce(SoundManager.Instance.gameOverSound);

        inGameController.GameOver();

        // TODO : 게임 종료 UI 열기
        UIManager.Instance.SelectPopup("gameOverUI");
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
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
