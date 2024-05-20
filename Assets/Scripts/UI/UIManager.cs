using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject IntroUI; //?�트로창
    [SerializeField] GameObject PlayUI; //게임 ?�레?�창
    [SerializeField] GameObject SelectCharUI; //캐릭???�택�?
    [SerializeField] GameObject GameOverUI; //게임?�버�?

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

    //?�업�??�기 & ?�기
    public void OpenPopup(GameObject gameObject) //?�업�??�기
    {
        gameObject.SetActive(true);
    }
    public void ClosePopup(GameObject gameObject) //?�업�??�기
    {
        gameObject.SetActive(false);
    }

    //?�정 �??�기 & ?�기
    public void SetIntroUI(bool isActive) //?�트로창
    {
        IntroUI.gameObject.SetActive(isActive);
    }

    public void SetPlayUI(bool isActive) //?�레?�창
    {
        PlayUI.gameObject.SetActive(isActive);
    }

    public void SetSelectCharUI(bool isActive) //캐릭?�선?�창
    {
        SelectCharUI.gameObject.SetActive(isActive);
    }

    public void SetGameOverUI(bool isActive) //게임?�버�?
    {
        GameOverUI.gameObject.SetActive(isActive);
    }

    //버튼 ?�릭 ?�벤??
    public void OnClickDecideButton() //캐릭?�선??결정 버튼
    {
        //캐릭?�별�??�택 버튼???�로 ?�는지, ?�니�?캐릭?��? ?�택?�고 결정 버튼 ?�나�??�릭?��????�직 미정
    }

    public void OnClickStartButton() //게임?�작 버튼
    {
        //?�트로창???�고 ?�레?�창???�기
        SetIntroUI(false);
        SetPlayUI(false);

        //게임?�작 로직

    }

    public void OnClickRestartButton() //?�시?�기 버튼
    {
        //게임?�작 로직
    }

    public void OnClickGotoTitleButton() //메인?�면(?�?��? ?�아가�? 버튼
    {
        SetIntroUI(true);
        SetPlayUI(false);
        SoundManager.Instance.ChangeBGM(SoundManager.Instance.introBGM);
    }

}