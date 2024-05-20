using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/****** �ΰ����� ��� ���� ���� ******/
public class InGameController : MonoBehaviour
{
    public static InGameController Instance;

    private GameObject player1;
    private GameObject player2;

    // TODO : 
    private int alivePlayers;
    private bool isPlayer1Alive;
    private bool isPlayer2Alive;
    

    // ������ UI��
    public Text currentScoreText;
    public Text highScoreText;

    // TODO : ĳ���� ���� ��� �����Ѵٸ� �ش� UI �����Ͽ� ����Ұ�
    // public GameObject CharacterSelectUI;


    // ��� �ð� = ����
    private float currentTime;
    private float highScore;
    public float GetScore() { return currentTime; }
    public float GetHighScore() { return highScore; }


   


    // ���� �ʱ�ȭ
    void Start()
    {
        //���� �ʱ�ȭ
        currentTime = 0;

        // UI ����

        currentScoreText.text = currentTime.ToString("N3");
        highScoreText.text = highScore.ToString("N3");

        if(GameManager.Instance.CurrentGameState == GameState.GameStart)
        {
            InGameStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameState.GameStart)
        {
            currentTime += Time.deltaTime;
            currentScoreText.text = currentTime.ToString("N3");
        }
    }


    /** IntroState : ������ ��� ���¸� �ʱ�ȭ�Ͽ� �� ���� ���� ������� **/
    void CreatePlayer()
    {
        player1 = Instantiate(GameManager.Instance.player1Prefab);
        alivePlayers = 1;
        if (GameManager.Instance.CurrentGameMode == GameMode.MultiPlayer)
        {
            player2 = Instantiate(GameManager.Instance.player2Prefab);
            alivePlayers++;
        }
    }


    /** SelectCharacterState : ĳ���� ���� **/
    /** SelectDifficultyState : ���̵� ���� **/
    // �� �� state�� GameManger���� ����


    /** GameStartState : ���� ���� �� ���� **/

    internal void InGameStart()
    {
        // �÷��̾� ĳ���� ����
        CreatePlayer();

        Time.timeScale = 1;

        // TODO : �� ������ StageManager���� ����!
        // StageManager.Instance.~(); <- �ʿ� ����
        // �ٸ� ���߿� ���� ����� GameState.GameStart �� ��쿡�� �����ǵ��� �ϸ� �ɵ�

    }



    public void GameOver()
    {
        // �ð� ����
        Time.timeScale = 0f;

        // �ְ� ���� ���
        if (currentTime > highScore)
        {
            highScore = currentTime;
            highScoreText.text = highScore.ToString("N3");
        }
    }

    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    

    // TODO : �̺�Ʈ�� �÷��̾� ����� ȣ��ǵ��� ����
    public void PlayerDead()
    {
        // TODO : ��Ȱ ������ ���� �����Ŷ�� 1P 2P ���� ����ִ��� üũ�� �ؾ� ��
        alivePlayers--;

        if(alivePlayers == 0)
        {
            // ���� ����
            // TODO : ���� ������ �̺�Ʈ�� �޵��� ����?
            GameManager.Instance.GameOverState();
        }
    }
}
