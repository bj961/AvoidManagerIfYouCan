using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    void GameStart()
    {
        SceneManager.LoadScene("MainScene");

        Debug.Log("게임 시작됨");
    }

    void GotoTitle()
    {
        SceneManager.LoadScene("IntroScene");

        Debug.Log("메인화면으로 이동");
    }

    public void OpenPopup(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void ClosePopup(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
