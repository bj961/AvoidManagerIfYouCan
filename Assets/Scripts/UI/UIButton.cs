using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    /** 인트로 화면 시작 **/

    //StartSingleButton
    public void SingleModeButton()
    {
        GameManager.Instance.CurrentGameMode = GameMode.SinglePlayer;
        GameManager.Instance.SelectCharacterState();
    }

    //StartMultiButton
    public void MultiModeButton()
    {
        GameManager.Instance.CurrentGameMode = GameMode.MultiPlayer;
        GameManager.Instance.SelectCharacterState();
    }

    /** 인트로 화면 끝 **/






    /** 게임 종료 화면 시작 **/

    // RetryButton
    public void RetryButton()
    {
        GameManager.Instance.RestartGame();
    }

    // 메인메뉴 버튼
    public void MainMenuButton()
    {
        GameManager.Instance.ResetGame();
    }

    /** 게임 종료 화면 끝 **/

}
