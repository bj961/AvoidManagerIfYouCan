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

    public delegate void GameStart();
    public event GameStart OnGameStart;

    public GameState CurrentGameState { get; private set; }
    public GameMode CurrentGameMode { get; private set; }

    public InGameController inGameController;

    // ĳ���� ������
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


    // State : ���� ȭ��
    public void IntroState()
    {
        CurrentGameState = GameState.Intro;

        // �ʱ�ȭ
        InitSelectedCharacter();
        StageManager.Instance.SetDifficulty(0);

        // ����ȭ�� UI ����


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
        // ĳ���� ���� UI ����


        // ĳ���� ����
        for (int i = 0; i< playerNumber; i++) 
        {

        }

    }


    // State : ���̵� ����
    // ���̵� ���� ����� �ִ´ٸ� ������ �Լ�
    public void SelectDifficultyState()
    {
        CurrentGameState = GameState.SelectDifficulty;
        // ���̵� ���� UI ����
        // ��ư���� ���̵� ����
        // �ش� ��ư���� StageManager.Instacne.SetDifficulty()ȣ��
        // ���� ���� ������ �ش� ��ư���� GameStartState() ȣ��
    }



    // State : ���� ����
    // ���� ���� or �ٽ� �ϱ� ��ư ������ ȣ��
    public void GameStartState()
    {
        CurrentGameState = GameState.GameStart;
        // ���� ����
        inGameController.InGameStart();
    }


    
    // State : ���� ����
    public void GameOverState()
    {
        CurrentGameState = GameState.GameOver;
        Time.timeScale = 0f;
        
        // ���� ���� ���� ó��
        // �ְ� ���� ����
        //inGameController.�Լ�();

        // ���� ���� UI ����
    }

}
