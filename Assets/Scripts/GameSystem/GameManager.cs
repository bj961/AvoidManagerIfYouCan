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


/****** ���� ���� ���� ******/
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // TODO : state ������ �̺�Ʈ�� �ؾߵǳ�??
    //public delegate void GameStart();
    //public event GameStart OnGameStart;

    public GameState CurrentGameState { get; private set; }
    public GameMode CurrentGameMode { get; private set; }

    public InGameController inGameController;

    // ĳ���� ������
    public GameObject player1Prefab;
    public GameObject player2Prefab;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CurrentGameState = GameState.Intro;
            CurrentGameMode = GameMode.SinglePlayer;
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

        // �׽�Ʈ�� �ӽ� �ڵ�
        CurrentGameState = GameState.GameStart;


        // TODO : state �̺�Ʈ ������� �����Ѵٸ� �� �ڵ嵵 ������ ��
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


    // State : ���� ȭ��
    public void IntroState()
    {
        CurrentGameState = GameState.Intro;

        InitSelectedCharacter();
        StageManager.Instance.SetDifficulty(0);

        // TODO : ����ȭ�� UI ����
        // UIManager.Instance.~~();

    }

    void InitSelectedCharacter()
    {
        player1Prefab = null;
        player2Prefab = null;
    }


    // State : ĳ���� ����
    public void SelectCharacterState(int playerNumber)
    {
        CurrentGameState = GameState.SelectCharacter;

        // TODO : ĳ���� ���� UI ����
        // UIManager.Instance.~~();

        // TODO : ĳ���� ����
        // player1Prefab, player2Prefab �� ������ �Ҵ����
        // 
    }




    // State : ���̵� ����
    // TODO : ���̵� ���� ����� �ִ´ٸ� ������ �κ�
    public void SelectDifficultyState()
    {
        CurrentGameState = GameState.SelectDifficulty;

        // TODO : ���̵� ���� UI ����
        // UIManager.Instance.~~();

        // TODO : ���̵� ���� ����
    }




    // State : ���� ����
    public void GameStartState()
    {
        CurrentGameState = GameState.GameStart;

        // TODO : ����â UI
        // UIManager.Instance.~~();

        // ���� ����
        inGameController.InGameStart();
    }



    // State : ���� ����
    public void GameOverState()
    {
        CurrentGameState = GameState.GameOver;

        inGameController.GameOver();

        // TODO : ���� ���� UI ����
        // UIManager.Instance.~~();
    }

}
