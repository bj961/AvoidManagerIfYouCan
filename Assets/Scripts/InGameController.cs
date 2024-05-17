using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameController : MonoBehaviour
{
    // 캐릭터, 적 프리팹.
    // player2 프리팹은 추후 다중 플레이어(2p) 기능 구현 시 사용
    public GameObject player1;
    public GameObject player2;
    public GameObject enemy;

    // UIManager에서 UI연결 및 On/Off 수행까지만 하고 로직은 GameManager?
    public Text currentScoreText;
    public Text highScoreText;

    // 경과 시간 = 점수
    private float currentTime;
    private float highScore;
    public float GetScore() { return currentTime; }
    public float GetHighScore() { return highScore; }


    // 난이도 관련
    private int difficulty;
    public int GetDifficulty() { return difficulty; }
    private float difficultyIncreaseInterval = 60f;
    private float enemyCreateDelay;


    // 캐릭터 선택 구현시 사용할 필드
    public GameObject CharacterSelectUI;


    // 다중 플레이어 구현한다면 사용할 필드
    private int playerNumber; // 플레이어수. 싱글 1, 멀티 2
    public void SetPlayerNumber(int number) { playerNumber = number; }
    private int alivePlayer; // 살아있는 플레이어 캐릭터 수. 죽으면 -= 1, == 0이 되면 게임 종료토록


    // Start is called before the first frame update
    void Start()
    {
        StageManager.Instance.SetDifficulty(0);
        currentTime = 0;
        enemyCreateDelay = 1f;
        highScoreText.text = highScore.ToString("N3"); // UI

        // 캐릭터 선택 및 다중 플레이어 구현 파트.
        // 선택 구현 사항이므로 나중에 진행
        /*
        alivePlayer = 0;
        CreatePlayer(Player1)
        CreatePlayer(Player2)
        */

        Time.timeScale = 1.0f;

        // 적 생성
        InvokeRepeating("CreateEnemys", 0f, enemyCreateDelay);

        // 일정 시간 간격으로 난이도 증가
        // 일단 1분마다 게임 속도 0.3씩 증가하도록 설정함
        InvokeRepeating("SetDifficulty", difficultyIncreaseInterval, difficultyIncreaseInterval);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; // 게임 매니저에서 수행
        currentScoreText.text = currentTime.ToString("N3"); // UI 매니저쪽에서 처리
    }


    // 똥(= 적 캐릭터 = 매니저) 생성
    public void CreateEnemys()
    {
        Instantiate(enemy);
    }

    // Player가 똥 오브젝트와 충돌할 경우(=게임 오버) 이 함수 호출토록함
    public void GameOver()
    {
        Time.timeScale = 0f;

        if (currentTime > highScore)
        {
            highScore = currentTime;
        }

        // 게임 종료 UI 열기
    }

}
