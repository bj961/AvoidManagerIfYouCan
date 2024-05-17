using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject IntroUI; //인트로창
    [SerializeField] GameObject PlayUI; //게임 플레이창
    [SerializeField] GameObject SelectCharUI; //캐릭터 선택창
    [SerializeField] GameObject GameOver; //게임오버창

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

    public void OpenPopup(GameObject gameObject) //팝업창 열기
    {
        gameObject.SetActive(true);
    }
    public void ClosePopup(GameObject gameObject) //팝업창 닫기
    {
        gameObject.SetActive(false);
    }

    public void SetIntroUI(bool isActive) //인트로창
    {
        IntroUI.gameObject.SetActive(isActive);
    }

    public void SetPlayUI(bool isActive) //플레이창
    {
        PlayUI.gameObject.SetActive(isActive);
    }

    public void SetSelectCharUI(bool isActive) //캐릭터선택창
    {
        SelectCharUI.gameObject.SetActive(isActive);
    }

    public void SetGameOveroUI(bool isActive) //게임오버창
    {
        GameOver.gameObject.SetActive(isActive);
    }
}