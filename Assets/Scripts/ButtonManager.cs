using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public List<Button> buttons;
    public Button startGameButton; 
    private List<Button> selectedButtons = new List<Button>();
    private int maxSelectedButtons = 2;

    GameObject selectedCharacterPrefab1;
    GameObject selectedCharacterPrefab2;

    void Start()
    {
        switch (GameManager.Instance.CurrentGameMode)
        {
            case GameMode.SinglePlayer:
                maxSelectedButtons = 1;
                break;
            case GameMode.MultiPlayer:
                maxSelectedButtons = 2;
                break;
        }

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }

        startGameButton.onClick.AddListener(OnStartGameButtonClick); 
    }

    private void OnButtonClick(Button clickedButton)
    {
        if (selectedButtons.Contains(clickedButton))
        {
            selectedButtons.Remove(clickedButton);
            clickedButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            if (selectedButtons.Count < maxSelectedButtons)
            {
                selectedButtons.Add(clickedButton);
                UpdateButtonColors();
            }
        }
        Debug.Log("Selected Buttons: " + selectedButtons.Count);
    }

    private void UpdateButtonColors()
    {
        for (int i = 0; i < selectedButtons.Count; i++)
        {
            if (i == 0)
            {
                selectedButtons[i].GetComponent<Image>().color = Color.red;
            }
            else if (i == 1)
            {
                selectedButtons[i].GetComponent<Image>().color = Color.green;
            }
        }
    }

    private void OnStartGameButtonClick()
    {
        // TODO: UI 교체
        Debug.Log("게임창으로 UI 교체 활성화");
    }
}
