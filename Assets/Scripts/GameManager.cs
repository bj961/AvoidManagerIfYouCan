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

    public delegate void GameStart();
    public event GameStart OnGameStart;

    public GameState CurrentGameState { get; private set; }
    public GameMode CurrentGameMode { get; private set; }

    public InGameController inGameController;

    // 캐릭터 프리팹
    public GameObject player1Prefab;
    public GameObject player2Prefab;

    // UI
    public GameObject CharacterSelectUI;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CurrentGameState = GameState.Intro;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        CurrentGameState = GameState.Intro;
        inGameController = FindObjectOfType<InGameController>();
    }


    // State : 시작 화면
    public void IntroState()
    {
        CurrentGameState = GameState.Intro;

        // 초기화
        InitSelectedCharacter();
        StageManager.Instance.SetDifficulty(0);

        // 시작화면 UI 열기


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
        // 캐릭터 선택 UI 열기


        // 캐릭터 선택
        for (int i = 0; i< playerNumber; i++) 
        {

        }

    }


    // State : 난이도 선택
    // 난이도 선택 기능을 넣는다면 구현할 함수
    public void SelectDifficultyState()
    {
        CurrentGameState = GameState.SelectDifficulty;
        // 난이도 선택 UI 열기
        // 버튼으로 난이도 선택
        // 해당 버튼에서 StageManager.Instacne.SetDifficulty()호출
        // 게임 시작 누르면 해당 버튼에서 GameStartState() 호출
    }



    // State : 게임 시작
    // 게임 시작 or 다시 하기 버튼 누르면 호출
    public void GameStartState()
    {
        CurrentGameState = GameState.GameStart;
        // 게임 시작
        inGameController.InGameStart();
    }


    
    // State : 게임 종료
    public void GameOverState()
    {
        CurrentGameState = GameState.GameOver;
        Time.timeScale = 0f;
        
        // 게임 오버 관련 처리
        // 최고 점수 갱신
        //inGameController.함수();

        // 게임 종료 UI 열기
    }

}
