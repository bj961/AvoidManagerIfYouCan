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

    private int alivePlayers;

    // TODO : Ȥ�� ��Ȱ ��� ������ �Ŷ�� ����ؾ� �� �ʵ�
    private bool isPlayer1Alive;
    private bool isPlayer2Alive;
    

    // ������ UI��
    // �ν����Ϳ��� ���� �ؾ���
    public Text currentScoreText;
    public Text highScoreText;


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
        Vector3 player1StartPosition = new Vector3 (0f, -4.2f, 0);
        Vector3 player2StartPosition = new Vector3(1.4f, -4.2f, 0);
        player1 = Instantiate(GameManager.Instance.player1Prefab, player1StartPosition, Quaternion.identity);
        alivePlayers = 1;
        if (GameManager.Instance.CurrentGameMode == GameMode.MultiPlayer)
        {
            player2 = Instantiate(GameManager.Instance.player2Prefab, player2StartPosition, Quaternion.identity);
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
        Debug.Log("#### GameOver ####");

        // �ð� ����
        Time.timeScale = 0f;

        // �ְ� ���� ���
        if (currentTime > highScore)
        {
            highScore = currentTime;
            highScoreText.text = highScore.ToString("N3");
        }
    }


    // TODO : �̺�Ʈ�� �÷��̾� ����� ȣ��ǵ��� ����
    public void PlayerDead()
    {
        // TODO : ��Ȱ ������ ���� �����Ŷ�� 1P 2P ���� ����ִ��� üũ�� �ؾ� ��
        alivePlayers--;

        if(alivePlayers == 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
