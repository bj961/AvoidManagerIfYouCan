using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    /** ��Ʈ�� ȭ�� ���� **/

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

    /** ��Ʈ�� ȭ�� �� **/






    /** ���� ���� ȭ�� ���� **/

    // RetryButton
    public void RetryButton()
    {
        GameManager.Instance.RestartGame();
    }

    // ���θ޴� ��ư
    public void MainMenuButton()
    {
        GameManager.Instance.ResetGame();
    }

    /** ���� ���� ȭ�� �� **/

}
