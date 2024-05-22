using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public void SingleModeButton()
    {
        GameManager.Instance.CurrentGameMode = GameMode.SinglePlayer;
        GameManager.Instance.SelectCharacterState();
    }

    public void MultiModeButton()
    {
        GameManager.Instance.CurrentGameMode = GameMode.MultiPlayer;
        GameManager.Instance.SelectCharacterState();
    }

    public void RetryButton()
    {
        GameManager.Instance.RestartGame();
    }

    public void MainMenuButton()
    {
        GameManager.Instance.ResetGame();
    }
}
