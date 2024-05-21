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
    public GameMode CurrentGameMode { get; private set; }

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

        CurrentGameState = GameState.GameStart; // 테스트용 임시 코드

        // TODO : state를 이벤트 기반으로 변경한다면 이 코드도 수정할 것
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


    // State : 시작 화면
    public void IntroState()
    {
        CurrentGameState = GameState.Intro;

        InitSelectedCharacter();
        StageManager.Instance.SetDifficulty(0);

        // TODO : 시작화면 UI 열기
        //UIManager.Instance.SelectPopup("introUI");

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
        CurrentGameState = GameState.SelectCharacter;

        // TODO : 캐릭터 선택 UI 열기
        //UIManager.Instance.SelectPopup("selectUI");

        // TODO : 캐릭터 선택
        // player1Prefab, player2Prefab 에 프리팹 할당토록
        // 캐릭터 선택 완료되면 다음 state로
    }


    // State : 난이도 선택
    // TODO : 난이도 선택 기능을 넣는다면 구현할 부분
    public void SelectDifficultyState()
    {
        CurrentGameState = GameState.SelectDifficulty;

        // TODO : 난이도 선택 UI 열기
        //UIManager.Instance.SelectPopup("selectDifficultyUI");

        // TODO : 난이도 선택
    }


    // State : 게임 시작
    public void GameStartState()
    {
        CurrentGameState = GameState.GameStart;

        // TODO : 시작창 UI
        //UIManager.Instance.SelectPopup("playUI");

        // 게임 시작
        inGameController.InGameStart();

        SoundManager.Instance.PlayBGM(SoundManager.Instance.playBGM);
    }


    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    // State : 게임 종료
    public void GameOverState()
    {
        CurrentGameState = GameState.GameOver;

        SoundManager.Instance.PlaySoundOnce(SoundManager.Instance.gameOverSound);

        inGameController.GameOver();

        // TODO : 게임 종료 UI 열기
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
