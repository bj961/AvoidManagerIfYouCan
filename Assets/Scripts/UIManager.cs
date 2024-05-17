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

    //팝업창 열기 & 닫기
    public void OpenPopup(GameObject gameObject) //팝업창 열기
    {
        gameObject.SetActive(true);
    }
    public void ClosePopup(GameObject gameObject) //팝업창 닫기
    {
        gameObject.SetActive(false);
    }

    //특정 창 열기 & 닫기
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

    //버튼 클릭 이벤트
    public void OnClickDecideButton() //캐릭터선택 결정 버튼
    {
        //캐릭터별로 선택 버튼이 따로 있는지, 아니면 캐릭터를 선택하고 결정 버튼 하나만 클릭할지는 아직 미정
    }

    public void OnClickStartButton() //게임시작 버튼
    {
        //인트로창을 닫고 플레이창을 열기
        SetIntroUI(false);
        SetPlayUI(false);

        //게임시작 로직

    }

    public void OnClickRestartButton() //다시하기 버튼
    {
        //게임시작 로직
    }

    public void OnClickGotoTitleButton() //메인화면(타이틀 돌아가기) 버튼
    {
        SetIntroUI(true);
        SetPlayUI(false);
        SoundManager.Instance.ChangeBGM(SoundManager.Instance.introBGM);
    }

}