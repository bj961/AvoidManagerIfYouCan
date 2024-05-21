using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


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

    // TODO : delegate와 event 선언 위치 고민
    // 1) OOP에 따라 플레이어 스크립트로 이동? 그러면 InGameController의 함수를 이벤트에 어떻게 등록할건가?
    // -> 2) delegate와 event 선언은 전역 위치에 있는게 좋을 것 같은데 여기 두는게 낫지 않나?
    // -> 3) 깔끔하게 EventManager를 만들어 관리? 이벤트 관리할 갯수 적은데 그냥 GameManager에 둬도 되지 않을까?
    public delegate void PlayerDeathHandler();
    public event PlayerDeathHandler OnPlayerDead;

    public void PlayerDeadEvent()
    {
        OnPlayerDead?.Invoke();
    }

    // 플레이어에 두고, 플레이어를 구독하고, 게임 매니저에서 이걸 처리
    // 옵저버 패턴 - 게임 매니저가 플레이어가 죽었는지 쳐다보다가 처리


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CurrentGameState = GameState.Intro;
            CurrentGameMode = GameMode.SinglePlayer;
            //CurrentGameMode = GameMode.MultiPlayer; //테스트용

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
        // UIManager.Instance.~~();

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
        // UIManager.Instance.~~();

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
        // UIManager.Instance.~~();

        // TODO : 난이도 선택
    }


    // State : 게임 시작
    public void GameStartState()
    {
        CurrentGameState = GameState.GameStart;

        // TODO : 시작창 UI
        // UIManager.Instance.~~();

        // 게임 시작
        inGameController.InGameStart();

        SoundManager.Instance.PlayBGM(SoundManager.Instance.playBGM);
    }



    // State : 게임 종료
    public void GameOverState()
    {
        CurrentGameState = GameState.GameOver;

        SoundManager.Instance.PlaySoundOnce(SoundManager.Instance.gameOverSound);

        inGameController.GameOver();

        // TODO : 게임 종료 UI 열기
        // UIManager.Instance.~~();
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
