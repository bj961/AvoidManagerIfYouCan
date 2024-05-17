using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameController : MonoBehaviour
{
    // ĳ����, �� ������.
    // player2 �������� ���� ���� �÷��̾�(2p) ��� ���� �� ���
    public GameObject player1;
    public GameObject player2;
    public GameObject enemy;

    // UIManager���� UI���� �� On/Off ��������� �ϰ� ������ GameManager?
    public Text currentScoreText;
    public Text highScoreText;

    // ��� �ð� = ����
    private float currentTime;
    private float highScore;
    public float GetScore() { return currentTime; }
    public float GetHighScore() { return highScore; }


    // ���̵� ����
    private int difficulty;
    public int GetDifficulty() { return difficulty; }
    private float difficultyIncreaseInterval = 60f;
    private float enemyCreateDelay;


    // ĳ���� ���� ������ ����� �ʵ�
    public GameObject CharacterSelectUI;


    // ���� �÷��̾� �����Ѵٸ� ����� �ʵ�
    private int playerNumber; // �÷��̾��. �̱� 1, ��Ƽ 2
    public void SetPlayerNumber(int number) { playerNumber = number; }
    private int alivePlayer; // ����ִ� �÷��̾� ĳ���� ��. ������ -= 1, == 0�� �Ǹ� ���� �������


    // Start is called before the first frame update
    void Start()
    {
        StageManager.Instance.SetDifficulty(0);
        currentTime = 0;
        enemyCreateDelay = 1f;
        highScoreText.text = highScore.ToString("N3"); // UI

        // ĳ���� ���� �� ���� �÷��̾� ���� ��Ʈ.
        // ���� ���� �����̹Ƿ� ���߿� ����
        /*
        alivePlayer = 0;
        CreatePlayer(Player1)
        CreatePlayer(Player2)
        */

        Time.timeScale = 1.0f;

        // �� ����
        InvokeRepeating("CreateEnemys", 0f, enemyCreateDelay);

        // ���� �ð� �������� ���̵� ����
        // �ϴ� 1�и��� ���� �ӵ� 0.3�� �����ϵ��� ������
        InvokeRepeating("SetDifficulty", difficultyIncreaseInterval, difficultyIncreaseInterval);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; // ���� �Ŵ������� ����
        currentScoreText.text = currentTime.ToString("N3"); // UI �Ŵ����ʿ��� ó��
    }


    // ��(= �� ĳ���� = �Ŵ���) ����
    public void CreateEnemys()
    {
        Instantiate(enemy);
    }

    // Player�� �� ������Ʈ�� �浹�� ���(=���� ����) �� �Լ� ȣ�������
    public void GameOver()
    {
        Time.timeScale = 0f;

        if (currentTime > highScore)
        {
            highScore = currentTime;
        }

        // ���� ���� UI ����
    }

}
