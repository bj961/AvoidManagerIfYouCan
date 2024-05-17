using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private InGameController inGameController;

    // ĳ����, �� ������.
    // player2 �������� ���� ���� �÷��̾�(2p) ��� ���� �� ���
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


    // State : ���� ȭ��
    public void IntroState()
    {
        // ����ȭ�� UI ����


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


    // State : ĳ���� ����
    public void CharacterSelectState(int playerNumber)
    {
        // ĳ���� ���� UI ����

        // 

    }


    // State : ���̵� ����
    // ���̵� ���� ����� �ִ´ٸ� ������ �Լ�
    public void DifficultySelectState()
    {
        // ���̵� ���� UI ����


    }



    // State : ���� ����
    // ���� ���� or �ٽ� �ϱ� ��ư ������ ȣ��
    public void GameStartState()
    {
        // MainScene �ٽ� �ε�
        // SceneManager.LoadScene(0);
    }


    
    // State : ���� ����
    public void GameOver()
    {
        Time.timeScale = 0f;
        
        // ���� ���� ���� ó��
        // �ְ� ���� ����
        //inGameController.�Լ�();

        // ���� ���� UI ����
    }

    /***** ���� ���� ���� *****/

    

    

    // ���� �÷��̾�
    public void CreatePlayer(GameObject playerPrefab)
    {
        Instantiate(playerPrefab);
        //alivePlayer += 1;
    }


}
