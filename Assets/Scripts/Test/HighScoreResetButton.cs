using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreResetButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ResetHighScore);
    }

    void ResetHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            float zero = 0f;
            PlayerPrefs.SetFloat("highScore", zero);
        }
    }
}
