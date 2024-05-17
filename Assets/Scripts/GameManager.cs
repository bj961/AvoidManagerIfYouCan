using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private InGameController inGameController;

    // 캐릭터, 적 프리팹.
    // player2 프리팹은 추후 다중 플레이어(2p) 기능 구현 시 사용
    public GameObject player1;
    public GameObject player2;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }

    private void Update()
    {
        
    }


    // State : 시작 화면
    public void IntroState()
    {
        // 시작화면 UI 열기


    }

    public void SinglePlayerMode()
    {
        inGameController.SetPlayerNumber(1);
        CharacterSelectState(1);
    }

    public void MultyPlayerMode()
    {
        inGameController.SetPlayerNumber(2);
        CharacterSelectState(2);
    }


    // State : 캐릭터 선택
    public void CharacterSelectState(int playerNumber)
    {
        // 캐릭터 선택 UI 열기

        // 

    }


    // State : 난이도 선택
    // 난이도 선택 기능을 넣는다면 구현할 함수
    public void DifficultySelectState()
    {
        // 난이도 선택 UI 열기


    }



    // State : 게임 시작
    // 게임 시작 or 다시 하기 버튼 누르면 호출
    public void GameStartState()
    {
        // MainScene 다시 로드
        // SceneManager.LoadScene(0);
    }


    
    // State : 게임 종료
    public void GameOver()
    {
        Time.timeScale = 0f;
        
        // 게임 오버 관련 처리
        // 최고 점수 갱신
        //inGameController.함수();

        // 게임 종료 UI 열기
    }

    /***** 선택 구현 사항 *****/

    

    

    // 다중 플레이어
    public void CreatePlayer(GameObject playerPrefab)
    {
        Instantiate(playerPrefab);
        //alivePlayer += 1;
    }


}
