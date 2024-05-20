using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject IntroUI; //?¸íŠ¸ë¡œì°½
    [SerializeField] GameObject PlayUI; //ê²Œì„ ?Œë ˆ?´ì°½
    [SerializeField] GameObject SelectCharUI; //ìºë¦­??? íƒì°?
    [SerializeField] GameObject GameOverUI; //ê²Œì„?¤ë²„ì°?

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

    //?ì—…ì°??´ê¸° & ?«ê¸°
    public void OpenPopup(GameObject gameObject) //?ì—…ì°??´ê¸°
    {
        gameObject.SetActive(true);
    }
    public void ClosePopup(GameObject gameObject) //?ì—…ì°??«ê¸°
    {
        gameObject.SetActive(false);
    }

    //?¹ì • ì°??´ê¸° & ?«ê¸°
    public void SetIntroUI(bool isActive) //?¸íŠ¸ë¡œì°½
    {
        IntroUI.gameObject.SetActive(isActive);
    }

    public void SetPlayUI(bool isActive) //?Œë ˆ?´ì°½
    {
        PlayUI.gameObject.SetActive(isActive);
    }

    public void SetSelectCharUI(bool isActive) //ìºë¦­?°ì„ ?ì°½
    {
        SelectCharUI.gameObject.SetActive(isActive);
    }

    public void SetGameOverUI(bool isActive) //ê²Œì„?¤ë²„ì°?
    {
        GameOverUI.gameObject.SetActive(isActive);
    }

    //ë²„íŠ¼ ?´ë¦­ ?´ë²¤??
    public void OnClickDecideButton() //ìºë¦­?°ì„ ??ê²°ì • ë²„íŠ¼
    {
        //ìºë¦­?°ë³„ë¡?? íƒ ë²„íŠ¼???°ë¡œ ?ˆëŠ”ì§€, ?„ë‹ˆë©?ìºë¦­?°ë? ? íƒ?˜ê³  ê²°ì • ë²„íŠ¼ ?˜ë‚˜ë§??´ë¦­? ì????„ì§ ë¯¸ì •
    }

    public void OnClickStartButton() //ê²Œì„?œì‘ ë²„íŠ¼
    {
        //?¸íŠ¸ë¡œì°½???«ê³  ?Œë ˆ?´ì°½???´ê¸°
        SetIntroUI(false);
        SetPlayUI(false);

        //ê²Œì„?œì‘ ë¡œì§

    }

    public void OnClickRestartButton() //?¤ì‹œ?˜ê¸° ë²„íŠ¼
    {
        //ê²Œì„?œì‘ ë¡œì§
    }

    public void OnClickGotoTitleButton() //ë©”ì¸?”ë©´(?€?´í? ?Œì•„ê°€ê¸? ë²„íŠ¼
    {
        SetIntroUI(true);
        SetPlayUI(false);
        SoundManager.Instance.ChangeBGM(SoundManager.Instance.introBGM);
    }

}