using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    // TODO : state 관리를 이벤트로 해야되나??
    //public delegate void GameStart();
    //public event GameStart OnGameStart;

    public delegate void GameStateDelegate();
    public event GameStateDelegate onIntroState;

    public GameState CurrentGameState { get; private set; }
    public GameMode CurrentGameMode { get; private set; }

    public InGameController inGameController;

    // 캐릭터 프리팹
    public GameObject player1Prefab;
    public GameObject player2Prefab;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CurrentGameState = GameState.Intro;
            CurrentGameMode = GameMode.SinglePlayer;

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

        // 테스트용 임시 코드
        CurrentGameState = GameState.GameStart;


        // TODO : state 이벤트 기반으로 변경한다면 이 코드도 수정할 것
        switch (CurrentGameState)
        {
            case GameState.Intro:
                IntroState();
                break;
            case GameState.GameStart:
                GameStartState();
                break;
            default:
                break;
        }

    }


    // State : 시작 화면
    public void IntroState()
    {
        CurrentGameState = GameState.Intro;

        InitSelectedCharacter();
        StageManager.Instance.SetDifficulty(0);

        // TODO : 시작화면 UI 열기
        // UIManager.Instance.~~();

    }

    void InitSelectedCharacter()
    {
        player1Prefab = null;
        player2Prefab = null;
    }


    // State : 캐릭터 선택
    public void SelectCharacterState(int playerNumber)
    {
        CurrentGameState = GameState.SelectCharacter;

        // TODO : 캐릭터 선택 UI 열기
        // UIManager.Instance.~~();

        // TODO : 캐릭터 선택
        // player1Prefab, player2Prefab 에 프리팹 할당토록
        // 
    }




    // State : 난이도 선택
    // TODO : 난이도 선택 기능을 넣는다면 구현할 부분
    public void SelectDifficultyState()
    {
        CurrentGameState = GameState.SelectDifficulty;

        // TODO : 난이도 선택 UI 열기
        // UIManager.Instance.~~();

        // TODO : 난이도 선택 로직
    }




    // State : 게임 시작
    public void GameStartState()
    {
        CurrentGameState = GameState.GameStart;

        // TODO : 시작창 UI
        // UIManager.Instance.~~();

        // 게임 시작
        inGameController.InGameStart();
    }



    // State : 게임 종료
    public void GameOverState()
    {
        CurrentGameState = GameState.GameOver;

        inGameController.GameOver();

        // TODO : 게임 종료 UI 열기
        // UIManager.Instance.~~();
    }

}
