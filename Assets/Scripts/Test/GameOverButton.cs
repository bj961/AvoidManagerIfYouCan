using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverButton : MonoBehaviour
{

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GameOver);
    }

    void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}
