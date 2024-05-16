using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    /***** ���� ���� ���� *****/

    // ���̵� ����
    private int difficulty;
    public int GetDifficulty() { return difficulty; }
    private float difficultyIncreaseInterval = 60f;
    private float enemyCreateDelay;


    // ĳ���� ���� ������ ����� �ʵ�
    public GameObject CharacterSelectUI;


    // ���� �÷��̾� �����Ѵٸ� ����� �ʵ�
    private int alivePlayer; // ����ִ� �÷��̾� ĳ���� ��. ������ -= 1, == 0�� �Ǹ� ���� �������
    public void SetPlayerNumber(int number) { alivePlayer = number; }

    /***** ���� ���� ���� *****/



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
        difficulty = 0;
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

    private void Update()
    {
        currentTime += Time.deltaTime;
        currentScoreText.text = currentTime.ToString("N3"); // UI
    }

    // ���� ���� or �ٽ� �ϱ� ��ư ������ ȣ��
    // �ƴϸ� GameStartButton.cs ���� �и��ϱ�
    public void GameStart()
    {
        // MainScene���� �̵�
        SceneManager.LoadScene(1);
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

    /***** ���� ���� ���� *****/

    // ���̵� ����
    void SetDifficulty()
    {
        // ���̵� ����
        difficulty += 1;

        // ���̵� ����
        // �ϴ� ���� �ӵ� ���� ��Ű�°ɷ�..
        Time.timeScale += 0.3f;
    }


    // ĳ���� ����
    public void CharacterSelect(int mode)
    {
        // ĳ���� ���� UI ����

        // ���� ����...

    }

    // ���� �÷��̾�
    public void CreatePlayer(GameObject playerPrefab)
    {
        Instantiate(playerPrefab);
        alivePlayer += 1;
    }


}
