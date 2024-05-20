using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject IntroUI; //인트로창
    public GameObject PlayUI; //게임 플레이창
    public GameObject SelectCharUI; //캐릭터 선택창
    public GameObject GameOverUI; //게임오버창

    public static UIManager Instance { get; private set; }

    public enum UIPopUp
    {
        Main = 0,
        SelectCharacter,
        Play,
        GameOver
    }

    private GameObject[] UIList = new GameObject


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

        UIList


    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void OpenPopup(int num)
    {   



        gameObject.SetActive(true);
    }
    public void ClosePopup(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void SetIntroUI(bool isActive)
    {
        IntroUI.gameObject.SetActive(isActive);
    }

    public void SetPlayUI(bool isActive)
    {
        PlayUI.gameObject.SetActive(isActive);
    }

    public void SetSelectCharUI(bool isActive)
    {
        SelectCharUI.gameObject.SetActive(isActive);
    }

    public void SetGameOverUI(bool isActive)
    {
        GameOverUI.gameObject.SetActive(isActive);
    }

    public void OnClickDecideButton()
    {

    }

    public void OnClickStartButton()
    {
        SetIntroUI(false);
        SetPlayUI(false);

    }

    public void OnClickRestartButton()
    {
    }

    public void OnClickGotoTitleButton()
    {
        SetIntroUI(true);
        SetPlayUI(false);
        SoundManager.Instance.ChangeBGM(SoundManager.Instance.introBGM);
    }

}