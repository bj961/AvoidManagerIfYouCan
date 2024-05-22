using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle2PUI : MonoBehaviour
{
    Transform player2UI;

    private void Awake()
    {
        player2UI = gameObject.transform.Find("Player2UI");
    }

    private void OnEnable()
    {
        GameMode gameMode = GameManager.Instance.CurrentGameMode;
        switch (gameMode)
        {
            case GameMode.SinglePlayer:
                //gameObject.transform.Find("Player2UI").gameObject.SetActive(false);
                player2UI.gameObject.SetActive(false);
                break;
            case GameMode.MultiPlayer:
                player2UI.gameObject.SetActive(true);
                break;
        }
    }
}
